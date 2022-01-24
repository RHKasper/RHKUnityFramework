using System.IO;
using UnityEditor;
using UnityEngine;

namespace Synchronization.Editor
{
    public static class NewProjectMenuItem
    {
        private static string ProjectsPath => Path.Combine("Assets", "Projects");
        
        [MenuItem("RHK Framework/Create New Project")]
        static void CreateNewProject()
        {
            Project project = ScriptableObject.CreateInstance<Project>();
            AssetDatabase.CreateAsset(project, Path.Combine(ProjectsPath, "New Project.asset"));
            AssetDatabase.SaveAssets();
            EditorGUIUtility.PingObject(project);
        }
    }
}