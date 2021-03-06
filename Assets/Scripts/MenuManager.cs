using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool isEscapeToExit;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                BackToMenu();
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main1");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void playlvl2()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
