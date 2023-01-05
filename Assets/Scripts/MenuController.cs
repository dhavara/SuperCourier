using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Exit()
    {
        gameManager.MenuControllerEvent("Exit");
        Application.Quit();
    }

    public void LevelSelect()
    {
        gameManager.MenuControllerEvent("LevelSelect");
    }

    public void ContinueGame()
    {
        gameManager.MenuControllerEvent("Continue");
    }
}
