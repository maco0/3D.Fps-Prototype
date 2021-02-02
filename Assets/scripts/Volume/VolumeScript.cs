using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class VolumeScript : MonoBehaviour
{
    public AudioMixer audioMix;
    public void SetVolume(float volume)
    {
        audioMix.SetFloat("Diabolic", volume);
    }
}
