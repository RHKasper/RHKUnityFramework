#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections.Generic;
using System.IO;
using RHKUnityFramework.FrameworkManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Synchronization
{
    [CreateAssetMenu(menuName = "Project", order = 0)]
    public class Project : ScriptableObject
    {
        [Tooltip("The Unity project path relative to the folder containing RHKUnityFramework Unity project")]
        public string unityProjectPath;
        public List<Object> assetsToIgnore;
        
        
        //========== Public Methods ===================================================================================
        public void Synchronize()
        {
            CopyDirectoryFromFrameworkToProject("RHKUnityFramework");
        }

        public void ReplaceGitIgnoreFile()
        {
            string sourcePath = Path.Combine(DirectoryUtilities.UnityProjectFolder, ".gitignore");
            string targetPath = Path.Combine(GetFullPath(),".gitignore");
            
            string contents = File.ReadAllText(sourcePath);
            File.WriteAllText(targetPath, contents);
            Debug.Log("Replaced " + targetPath + " with " + sourcePath);
        }
        
        public void OpenFolder()
        {
            System.Diagnostics.Process.Start("open", $"-R \"{GetFullPath()}\"");
        }

        //========== Private Methods ==================================================================================
        private string GetFullPath()
        {
            string outside = DirectoryUtilities.OutsideUnityProjectFolder;
            string fullPath = Path.Combine(outside, unityProjectPath);
            fullPath = Path.GetFullPath(fullPath);
            return fullPath;
        }
        private string GetAssetsPath()
        {
            return Path.Combine(GetFullPath(), "Assets");
        }

        private void CopyDirectoryFromFrameworkToProject(string directoryPathFromAssets)
        {
#if UNITY_EDITOR
            string targetProjectAssetsPath = GetAssetsPath();
            
            string frameworkPath = Path.GetFullPath(Path.Combine(Application.dataPath, directoryPathFromAssets));
            string targetPath = Path.Combine(targetProjectAssetsPath, directoryPathFromAssets);

            if (Directory.Exists(targetProjectAssetsPath) == false)
                throw new Exception("Target directory does not exist. Path: " + targetProjectAssetsPath);
            
            HashSet<string> pathsToExclude = new HashSet<string>();
            foreach (Object asset in assetsToIgnore)
            {
                if(asset == null)
                    continue;
                
                string projectFolder = DirectoryUtilities.UnityProjectFolder;
                string filePath = Path.GetFullPath(Path.Combine(projectFolder, AssetDatabase.GetAssetPath(asset)));
                pathsToExclude.Add(filePath);
                pathsToExclude.Add(filePath + ".meta");
            }

            DirectoryUtilities.ReplaceDirectory(frameworkPath,targetPath, pathsToExclude);
#else
            Debug.LogError("CopyDirectoryFromFrameworkToProject works only in the editor!");
#endif
        }
    }
}