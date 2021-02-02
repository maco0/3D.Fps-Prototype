using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
   
   
    public void PLAYDemo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   

    public void PLAYLevel1()
    {
        Time.timeScale = 1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    public void Quit()
    {
        Application.Quit();
    }

    
}
