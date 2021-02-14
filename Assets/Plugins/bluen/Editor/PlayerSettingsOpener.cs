using UnityEditor;

namespace bluen.Editor
{

    public static class PlayerSettingsOpener
    {
        [MenuItem("Tools/bluen/Open Player Settings")]
        private static void OpenPlayerSettings()
        {
            EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
        }
    }
}