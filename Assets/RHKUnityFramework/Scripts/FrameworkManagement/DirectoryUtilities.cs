using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace RHKUnityFramework.Scripts.FrameworkManagement
{
    public static class DirectoryUtilities
    {
        public static string UnityAssetsFolder => Application.dataPath;
        public static string UnityProjectFolder => Path.GetFullPath(Path.Combine(UnityAssetsFolder, "../"));
        public static string OutsideUnityProjectFolder => Path.GetFullPath(Path.Combine(UnityProjectFolder, "../"));
        public static string RhkUnityFrameworkSourceFolder => Path.Combine(OutsideUnityProjectFolder, "RHKUnityFramework", "Assets", "RHKUnityFramework");
        public static string LocalRhkUnityFrameworkFolder => Path.Combine(UnityAssetsFolder, "RHKUnityFramework");


        public static void ReplaceDirectory( string sourceDir, string destinationDir, HashSet<string> pathsToExclude = null)
        {
            if (Directory.Exists(destinationDir))
            {
                Directory.Delete(destinationDir, true);
                Debug.Log("Deleted directory: " + destinationDir);
            }

            CopyDirectory(sourceDir, destinationDir, pathsToExclude);
        }

        public static void CopyDirectory(string sourceDir, string destinationDir, HashSet<string> pathsToExclude = null)
        {
	        sourceDir = Path.GetFullPath(sourceDir);//fix any slashes in the wrong direction
	        destinationDir = Path.GetFullPath(destinationDir);//fix any slashes in the wrong direction
	        

	        if (pathsToExclude == null)
                pathsToExclude = new HashSet<string>();


            // Create subdirectory structure in destination
            foreach (string dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                if(pathsToExclude.Any(p=> dir.Contains(p)) == false)
                    Directory.CreateDirectory(Path.Combine(destinationDir, dir.Substring(sourceDir.Length + 1)));
            }

            foreach (string fileName in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                if(pathsToExclude.Any(p=> fileName.Contains(p)) == false)
                    File.Copy(fileName, Path.Combine(destinationDir, fileName.Substring(sourceDir.Length + 1)), true);
            }

            Debug.Log("Copied " + sourceDir + " to " + destinationDir);
        }
        
        /// <summary>
        /// Retrieve list of names of all files nested within a directory.
        /// </summary>
        public static List<string> GetFilesRecursivelyInDirectory(this string directory)
        {
            List<string> files = new List<string>();
            foreach (string dir in Directory.EnumerateDirectories(directory))
            {
                files.AddRange(GetFilesRecursivelyInDirectory(dir));
            }

            files.AddRange(Directory.EnumerateFiles(directory));
            return files;
        }
    }
}
