using UnityEngine;

public class PlayerPrefsHandler : MonoBehaviour
{
    private const string CURRENT_LEVEL_KEY = "CurrentLevel";

    /// <summary>
    /// Saves the current level number to PlayerPrefs.
    /// </summary>
    /// <param name="levelIndex">The level index to save.</param>
    public static void SetCurrentLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(CURRENT_LEVEL_KEY, levelIndex);
        PlayerPrefs.Save(); // ensure data is written to disk
        Debug.Log($"[PlayerProgress] Saved Current Level: {levelIndex}");
    }

    /// <summary>
    /// Returns the saved current level index.
    /// Defaults to 0 if no data exists.
    /// </summary>
    public static int GetCurrentLevel()
    {
        int level = PlayerPrefs.GetInt(CURRENT_LEVEL_KEY, 0);
        Debug.Log($"[PlayerProgress] Loaded Current Level: {level}");
        return level;
    }

    /// <summary>
    /// Clears all saved progress (useful for debugging or reset button).
    /// </summary>
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(CURRENT_LEVEL_KEY);
        PlayerPrefs.Save();
        Debug.Log("[PlayerProgress] Progress Reset.");
    }
}