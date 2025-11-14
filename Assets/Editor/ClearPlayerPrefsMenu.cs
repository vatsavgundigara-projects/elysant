using UnityEditor;
using UnityEngine;

public static class ClearPlayerPrefsMenu
{
    [MenuItem("Tools/Clear PlayerPrefs %#d")] // Shortcut: Ctrl+Shift+D (Windows) / Cmd+Shift+D (Mac)
    public static void ClearAllPlayerPrefs()
    {
        if (EditorUtility.DisplayDialog(
            "Clear PlayerPrefs",
            "Are you sure you want to delete all PlayerPrefs data?",
            "Yes", "No"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log(" All PlayerPrefs have been cleared successfully!");
        }
    }
}
