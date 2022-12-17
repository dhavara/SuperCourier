using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text Easy;
    public Text Hard;
    public GlobalVariable global;
    // Start is called before the first frame update
    void Start()
    {
        Easy.text = global.getSkorEasy().ToString();
        Hard.text = global.getSkorHard().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
