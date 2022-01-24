using System;
using System.IO;
using RHKUnityFramework.Scripts.FrameworkManagement;
using UnityEditor;
using UnityEngine;

namespace RHKUnityFramework.Editor
{
    public static partial class SyncBackToFramework
    {
        public static void SyncLocalChanges(string sourcePath, string targetPathFromReposFolder)
        {
            
            if(Directory.Exists(sourcePath) == false)
                LogDirectoryDoesNotExist(sourcePath, true);
            
            string path1 = Path.Combine(DirectoryUtilities.OutsideUnityProjectFolder, targetPathFromReposFolder);
            if (Directory.Exists(path1))
            {
                DirectoryUtilities.CopyDirectory(sourcePath, path1);
                return;
            }

            string path2 = Path.GetFullPath(Path.Combine(DirectoryUtilities.OutsideUnityProjectFolder, "../", targetPathFromReposFolder));
            if (Directory.Exists(path2))
            {
                DirectoryUtilities.CopyDirectory(sourcePath, path2);
                return;
            }
            
            LogDirectoryDoesNotExist(path1);
            LogDirectoryDoesNotExist(path2);
        }
        
        
        [MenuItem("RHK Framework/Sync local changes to RHK Unity Framework")]
        private static void SyncLocalChangesToRHKUF()
        {
            if(RhkFrameworkManagement.IsRhkFrameworkProject)
                throw new Exception("Can't copy from RHK Framework to itself");
            
            SyncLocalChanges(DirectoryUtilities.LocalRhkUnityFrameworkFolder, DirectoryUtilities.RhkUnityFrameworkSourceFolder);
        }

        private static void LogDirectoryDoesNotExist(string path, bool throwException = false)
        {
            string message = "Directory: " + path + " does not exist";
            if(throwException)
                throw new DirectoryNotFoundException(message);
            else
                Debug.LogError(message);
        }
    }
}