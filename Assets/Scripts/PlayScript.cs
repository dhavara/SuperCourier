using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    private GameManager gameManager;
    public int level;
    
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    public void Play()
    {
        gameManager.LevelSelectorEvent(level);
    }
}
