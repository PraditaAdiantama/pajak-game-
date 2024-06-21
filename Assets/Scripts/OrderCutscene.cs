using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class OrderCutscene : MonoBehaviour
{
    private PlayableDirector thisPlayableDirector;

    public Canvas orderCanvas;
    public CanvasGroup button;

    private void Awake()
    {
        orderCanvas.enabled = false;
        thisPlayableDirector = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        thisPlayableDirector.stopped += OnPlayableDirectorStoppped;
    }

    private void OnPlayableDirectorStoppped(PlayableDirector playable)
    {
        if (playable == thisPlayableDirector)
        {
            orderCanvas.enabled = true;
            button.alpha = 0;
        }
    }
}
