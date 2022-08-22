using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public bool playing;
    AudioSource audiosource;

    public static BGM instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
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
