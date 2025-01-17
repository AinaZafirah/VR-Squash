using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip myAudioClip;
    public string targetTag = "Ball";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && myAudioSource != null)
        {
            myAudioSource.PlayOneShot(myAudioClip);
        }
    }
}
