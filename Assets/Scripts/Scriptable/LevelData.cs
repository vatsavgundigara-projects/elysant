using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Layout Settings")]
    [Tooltip("Total number of cards (must be even).")]
    public int totalCards;

    [Tooltip("Number of rows in the grid layout.")]
    public int rows;

    [Tooltip("Number of columns in the grid layout.")]
    public int columns;

    [Header("Level Num")]
    [Tooltip("Level Number")]
    public string levelNo  ;

    [Tooltip("Level difficulty rating for progression.")]
    public int difficulty = 1;
}
