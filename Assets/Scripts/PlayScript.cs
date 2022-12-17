using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //! Level Easy (Pindahkan ke scene Level Easy)
    public void easyGame()
    {
        SceneManager.LoadScene("LevelEasy");
    }

    //! Level Hard (Pindahkan ke scene Level Hard)
    public void hardGame()
    {
        SceneManager.LoadScene("LevelHard");
    }

    //! Exit (Keluar dari aplikasi)
    public void Exit()
    {
        Application.Quit();
    }
}
