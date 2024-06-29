using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(audioSource);
    }

    public void Mute()
    {
        string soundStatus = PlayerPrefs.GetString("soundSetting");

        animator.SetTrigger("Mute");

        if (soundStatus == "mute")
        {
            PlayerPrefs.SetString("soundSetting", "play");
            audioSource.Play();
        }
        else
        {
            PlayerPrefs.SetString("soundSetting", "mute");
            audioSource.Pause();
        }
    }
}
