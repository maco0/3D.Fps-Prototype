using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class TARGOT : MonoBehaviour
{
    public ParticleSystem OUCH;
    public float health = 100f;
    public AudioSource oof;
    float current;
   public Slider slidera;
    PlayerStats player;
    public ParticleSystem DEATH;
    void Start()
    {
        current = health;
    }
    void Update()
    {
        slidera.value = current;
    }

    void oofPlay()
    {
        oof.Play();
    }
    public void TakeDamage(float amount)
    {
        OUCH.Play();
        oofPlay();
        current -= amount;
        if(current<= 0)
        {
            NotLive();
           
        }
    }
    public void NotLive()
    {
        
        DEATH.Play();
        Destroy(gameObject,0.4f);
       
    }
}
