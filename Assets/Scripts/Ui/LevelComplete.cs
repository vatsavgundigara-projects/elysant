using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelCompletePanel : BasePanel
{
    [Header("Buttons")]
    public Button resetLevelBtn;
    public Button nextLevelBtn;

   
    protected override void Awake()
    {
        base.Awake();

        if (resetLevelBtn != null)
            resetLevelBtn.onClick.AddListener(RestartLevel);

        if (nextLevelBtn != null)
            nextLevelBtn.onClick.AddListener(NextLevel);
    }

    private void RestartLevel()
    {
        int currentLevel = PlayerPrefsHandler.GetCurrentLevel();

        if(currentLevel < GameManager.Instance.levelDatabase.levels.Count)
         PlayerPrefsHandler.SetCurrentLevel(currentLevel - 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        int nextLevel = PlayerPrefsHandler.GetCurrentLevel();
        PlayerPrefsHandler.SetCurrentLevel(nextLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
