using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //! Play Again (Pindahkan ke scene Level Easy)
    public void Play1()
    {
        
        SceneManager.LoadScene(0);
    }

    //! Play Again (Pindahkan ke scene Level Hard)
    public void Play2()
    {
        SceneManager.LoadScene(1);
    }

    //! Menu (Pindahkan ke scene Menu)
    public void Menu()
    {
        SceneManager.LoadScene(4);
    }
}
