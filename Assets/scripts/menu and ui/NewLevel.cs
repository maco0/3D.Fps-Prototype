using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewLevel : MonoBehaviour
{
     public void scene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);

    }
}
