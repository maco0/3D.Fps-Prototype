using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public static bool isPaused = false;
    public GameObject pausemenuUI;
     void Start()
    {
       
        cursor(true);
        isPaused = false;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           

            if (isPaused)
            {
                resume();
            }
            else
            { 
                pause();
            }
            
        }
    }
    public void resume()
    {
        

        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        cursor(true);
    }

    public void pause()
    {

        pausemenuUI.SetActive(true);
        cursor(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void quite()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void cursor(bool cursorLocked)
    {
        if (cursorLocked)
        {
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

  
    
}
