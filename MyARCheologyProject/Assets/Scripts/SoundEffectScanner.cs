using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectScanner : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip scanningSound;

    public void playScanningSound()
    {   
        audioSource.clip = scanningSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void stopScanningSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
    }
}
