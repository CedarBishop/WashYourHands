using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void TurnOffAudio ()
    {
        audioSource.volume = 0.0f;
    }

    public void TurnOnAudio ()
    {
        audioSource.volume = 1.0f;
    }
}
