using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;
    private static AudioSource instance;

    private void Awake()
    {
        // Implement Singleton pattern
        if (instance == null)
        {
            instance = audioSource;
            DontDestroyOnLoad(audioSource);  // Use gameObject to persist the entire object
        }
        else if (instance != audioSource)
        {
            Destroy(instance.gameObject);  // Destroy duplicate instance
        }

        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Initialize the audioSource based on the sound setting
        string soundStatus = PlayerPrefs.GetString("soundSetting");

        if (soundStatus == "mute")
        {
            audioSource.Pause();
            animator.SetTrigger("Mute");
        }
        else
        {
            audioSource.Play();
        }
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
