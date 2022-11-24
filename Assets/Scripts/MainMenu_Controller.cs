using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu_Controller : MonoBehaviour
{
    [Header("Create New Game")]
    public string _newGameLevel;
    private string levelToLoad;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
