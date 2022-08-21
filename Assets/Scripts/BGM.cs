using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public bool playing;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        audiosource = GetComponent<AudioSource>();
    }

    public void TogglePlaying()
    {
        playing = !playing;
        if (playing)
        {
            audiosource.Play();
        }
        else
        { 
            audiosource.Stop();
        }
    }

}
