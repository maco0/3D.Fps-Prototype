using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winSc : MonoBehaviour
{
   
    public void win()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
}
