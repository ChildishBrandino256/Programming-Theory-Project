using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioClip implode;
    [SerializeField] AudioClip explode;
    void Start()
    {
        StartCoroutine(playEngineSound()); //ABSTRACTION
    }

    IEnumerator playEngineSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = implode;
        audio.pitch = 2;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length / 2);
        audio.pitch = 1;
        audio.clip = explode;
        audio.Play();
    }
}
