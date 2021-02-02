using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class trap : MonoBehaviour
{
    public AudioSource rick;
    public AudioSource kickstart;
    private void Start()
    {
        kickstart.Play();
    }
    public void rickPlay()
    {
        kickstart.Stop();
        rick.Play();
    }
    
}
