using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public Button resetLevelBtn;
    public Button nextLevelBtn;



    // Start is called before the first frame update
    void Start()
    {
        // Add listeners at runtime
        if (resetLevelBtn != null)
            resetLevelBtn.onClick.AddListener(RestartLevel);

        if (nextLevelBtn != null)
            nextLevelBtn.onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void NextLevel()
    {
        PlayerPrefsHandler.SetCurrentLevel(PlayerPrefsHandler.GetCurrentLevel()+ 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
