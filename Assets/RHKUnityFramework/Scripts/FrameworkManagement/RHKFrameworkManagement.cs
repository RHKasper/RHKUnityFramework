using UnityEngine;

namespace RHKUnityFramework.Scripts.FrameworkManagement
{
    public static class RhkFrameworkManagement
    {
        public static bool IsRhkFrameworkProject => Application.productName == "RHK Unity Framework";
    }
}