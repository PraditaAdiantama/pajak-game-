using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject transition;

    void OnMouseDown()
    {
        transition.GetComponent<TransitionScript>().PlayAnim();
    }
}
