using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Click;
    public void ExitButton()
    {
        AudioSource.PlayOneShot(Click);
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        AudioSource.PlayOneShot(Click);
        SceneManager.LoadScene("MenuLevel");
    }
}
