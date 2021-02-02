using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public float PlayerHealth = 100f;
   
    public float currentHealth;
    public Slider hp;
    public ParticleSystem bleed;
    bool ded = false;
    void Start()
    {
        currentHealth = PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = currentHealth;
    }

    public void minusHealth(float scale)
    {
        if (currentHealth > 0)
        {
            bleed.Play();
            currentHealth -= scale;
        }
        else
        {
            Death();
            SceneManager.LoadScene(3);
        }
    }

    void Death()
    {
        currentHealth = 0;
        ded = true;
        
    }



}
