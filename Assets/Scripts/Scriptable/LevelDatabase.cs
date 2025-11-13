using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelDatabase", menuName = "Game/Level Database", order = 2)]
public class LevelDatabase : ScriptableObject
{
    [Header("All Level Configurations")]
    public List<LevelData> levels = new List<LevelData>();

    public LevelData GetLevel(int index)
    {
        if (index < 0 || index >= levels.Count)
        {
            Debug.LogWarning($"Invalid level index: {index}");
            return null;
        }
        return levels[index];
    }
}
