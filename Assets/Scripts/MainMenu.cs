using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public CursorMode cursorMode = CursorMode.Auto;

    public void PlayGame(){
        SceneManager.LoadScene("DungeonScene");
    }

    public void PlayGame2(){
        SceneManager.LoadScene("ForestScene");
    }

    public void PlayGame3(){
        SceneManager.LoadScene("TownScene");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}