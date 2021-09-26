using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MulaiPermainan2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

