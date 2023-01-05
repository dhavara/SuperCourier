using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Restart()
    {
        gameManager.RestartLevel();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
