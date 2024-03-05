using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void GoToWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void GoToLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }
    public void GoToLose()
    {
        SceneManager.LoadScene("LoseScene");
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
