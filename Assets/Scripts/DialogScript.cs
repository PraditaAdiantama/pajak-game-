using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public TextMeshProUGUI characterLabelTMP, messageTMP;
    public float textDelay = 0.1f;
    public string[] messages;
    public GameObject parent;
    private AudioSource audioSource;
    public GameObject targetScene, disabledScene, transition;
    public bool autoPlay = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(autoPlay)
        {
            Play();
        }
    }

    public void Play()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(TypingText());
    }


    private IEnumerator TypingText()
    {
        foreach (string message in messages)
        {
            string[] dialog = message.Split(":");
            characterLabelTMP.text = dialog[0];

            for (int i = 0; i < dialog[1].Length; i++)
            {
                messageTMP.text += dialog[1][i];

                yield return new WaitForSeconds(textDelay);
            }

            yield return new WaitForSeconds(2);
            messageTMP.text = "";
            characterLabelTMP.text = "";
        }

        if (targetScene != null)
        {
            targetScene.SetActive(true);
        }
        if (disabledScene != null)
        {
            disabledScene.SetActive(false);
        }
        if (transition != null)
        {
            transition.GetComponent<TransitionScript>().PlayAnim();
        }
        parent.SetActive(false);
    }
}