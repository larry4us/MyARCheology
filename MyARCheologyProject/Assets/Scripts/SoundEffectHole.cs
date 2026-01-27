using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectHole : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip digSound1, digSound2;

    public void playRandomDigSound()
    {
        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            audioSource.clip = digSound1;
        }
        else
        {
            audioSource.clip = digSound2;
        }

        audioSource.Play();
    }
}
