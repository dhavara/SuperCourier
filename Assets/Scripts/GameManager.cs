using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int unlockedLevel = 1;
    private int indexedLevel = 0;
    private int jumpCount = 0;
    
    public PlayerController playerController;
    
    public AudioSource audioSource;
    public AudioClip clipClick;

    // winning mechanisms
    private bool isDelivered = false;
    private bool isJerrycan = true;
    private int collectableAmount = 0; 

    // Start is called before the first frame update
    void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("Player_level", 1);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(audioSource.gameObject);
    }

    public void MenuControllerEvent(string action)
    {
        if (action == "Exit")
        {
            audioSource.PlayOneShot(clipClick);
        }
        else if (action == "LevelSelect")
        {
            audioSource.PlayOneShot(clipClick);
            SceneManager.sceneLoaded += SceneManager_onSceneLoaded;
            SceneManager.LoadScene("MenuLevel");
        }
        else if (action == "Continue")
        {
            audioSource.PlayOneShot(clipClick);
            SceneManager.sceneLoaded += SceneManager_onSceneLoaded;
            SceneManager.LoadScene("Level_"+unlockedLevel);
            indexedLevel = unlockedLevel;
            audioSource.Stop();
        }
    }

    public void LevelSelectorEvent(int level)
    {
        audioSource.PlayOneShot(clipClick);
        SceneManager.sceneLoaded += SceneManager_onSceneLoaded;
        indexedLevel = level;
        SceneManager.LoadScene("Level_"+level);
        audioSource.Stop();
    }

    public void LevelSelector()
    {
        foreach (var btn in FindObjectsOfType<Button>())
        {
            if(unlockedLevel >= btn.gameObject.GetComponent<PlayScript>().level)
            {
                btn.interactable = true;

            }
        }
    }

    private void SceneManager_onSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Level_"+indexedLevel)
        {
            playerController = FindObjectOfType<PlayerController>();
            playerController.onCollisionEnter = PlayerController_onCollisionEnter;

            GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");
            if (collectables.Length > 0)
            {
                collectableAmount = collectables.Length;
                playerController.customer.SetActive(false);
            }
            else
            {
                collectableAmount = collectables.Length;
                playerController.customer.SetActive(true);
            }

            GameObject jerrycan = GameObject.FindGameObjectWithTag("Jerrycan");
            if (jerrycan != null)
            {
                isJerrycan = false;
            }
        }
        else if (scene.name == "MenuLevel")
        {
            LevelSelector();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerController.Move(1f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerController.Move(-1f);
            }
            else {
                playerController.Move(0f);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCount < 2) {
                    jumpCount++;
                    playerController.Jump();
                }
            }
        }
    }

    private void PlayerController_onCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            collectableAmount--;
            playerController.audioMoney.Play();
            if (collectableAmount == 0)
            {
                playerController.customer.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("Jerrycan"))
        {
            Destroy(collision.gameObject);
            isJerrycan = true;
            playerController.audioMoney.Play();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.audioDead.Play();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            playerController.customer.SetActive(true);
            if (isDelivered && isJerrycan)
            {
                if (indexedLevel == 5 && unlockedLevel == 5)
                {
                    SceneManager.LoadScene("EndGame");
                }
                else
                {
                    if (indexedLevel < unlockedLevel)
                    {
                        indexedLevel++;
                        SceneManager.LoadScene("Level_"+indexedLevel);
                    }
                    else
                    {
                        if (unlockedLevel != 5)
                        {
                            unlockedLevel++;
                        }
                        indexedLevel = unlockedLevel;
                        PlayerPrefs.SetInt("Player_level", unlockedLevel);
                        SceneManager.LoadScene("Level_"+indexedLevel);
                    }
                }
            }
        }

        if (collision.gameObject.CompareTag("Customer"))
        {
            playerController.customer.SetActive(false);
            isDelivered = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level_" + indexedLevel);
    }

}
