using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public int targetScene;
    private Animator animator;
    public bool startAnimation = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (startAnimation)
        {
            animator.SetTrigger("End");
        }
    }

    public void PlayAnim()
    {
        animator.enabled = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(targetScene);
    }
}
