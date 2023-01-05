using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //! Level Easy (Pindahkan ke scene Level Easy)
    public void play()
    {
        SceneManager.LoadScene("Level_"+level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
