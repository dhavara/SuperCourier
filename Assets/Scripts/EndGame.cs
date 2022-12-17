using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! Menu (Pindahkan ke scene Menu)
    public void Menu()
    {
        SceneManager.LoadScene(4);
    }
}
