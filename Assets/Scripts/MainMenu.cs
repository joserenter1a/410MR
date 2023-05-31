using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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