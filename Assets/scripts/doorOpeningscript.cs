using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class doorOpeningscript : MonoBehaviour
{
    [SerializeField]
    GameObject hodor;
    bool isopened = false;
    public ParticleSystem press;
    public AudioSource kira;
  public  void hit(bool x)
    {
        if (!isopened)
        {
            if (x == true)
            {
                kira.Play();
                press.Play();
                Destroy(hodor);
                isopened = true;
            }
        }
    }

}