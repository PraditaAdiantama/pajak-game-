using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    private bool isDragging = false;
    public Vector3[] textPositions;
    public GameObject dialog, spawner;
    private Vector3 offset;
    private Camera mainCamera;
    private string finalText = "pajak";
    private Animator animator;
    private string currentText = "";

    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().isKinematic = false;
        PlayerPrefs.SetInt("wordCount", 0);
    }

    void OnMouseDown()
    {
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z;

            float objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            float objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;

            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth / 2;
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - objectWidth / 2;
            float minY = -0.91f;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - objectHeight / 2;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.transform.tag;

        if (tag == "missile")
        {
            animator.SetTrigger("Damaged");
            Destroy(other.gameObject);
            StartCoroutine(Wait());
        }
        else
        {
            if (finalText[currentText.Length].ToString().Trim() == tag)
            {
                other.transform.position = textPositions[currentText.Length];
                other.gameObject.GetComponent<MissileScript>().Stop();
                currentText += tag;
                PlayerPrefs.SetInt("wordCount", currentText.Length);
                if (currentText == "pajak")
                {
                    dialog.GetComponent<DialogScript>().Play();
                    spawner.SetActive(false);
                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        animator.SetTrigger("Stop");
    }
}
