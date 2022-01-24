using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Synchronization.Editor
{
    [CustomEditor(typeof(Project))]
    [CanEditMultipleObjects]
    public class ProjectCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            List<Project> projects = targets.OfType<Project>().ToList();
            
            
            DrawDefaultInspector();
            if (GUILayout.Button("Sync Framework To Project"))
                foreach (Project project in projects)
                    project.Synchronize();

            
            if (GUILayout.Button("Replace .gitignore file"))
                foreach (Project project in projects)
                    project.ReplaceGitIgnoreFile();
            
            if (GUILayout.Button("Open Folder"))
                foreach (Project project in projects)
                    project.OpenFolder();
        }
    }
}