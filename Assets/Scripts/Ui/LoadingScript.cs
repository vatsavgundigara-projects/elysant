using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour
{
    public Button playBtn;

    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(()=> LoadGameScene("GameplayScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    /// <summary>
    /// Call this to start loading the next scene async
    /// </summary>
    public void LoadGameScene(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }
}
