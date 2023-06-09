using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public bool canFinish;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;
    float m_Timer;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
            if(other.GetComponent<PlayerController>().hasKey){
                canFinish = true;
        }
        }
        
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            if(canFinish){
                EndLevel();
            }
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        Cursor.lockState = CursorLockMode.Confined; 
        SceneManager.LoadScene("MainMenuFinal");

    }
}
