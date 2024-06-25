using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    private bool isDragging = false;
    public GameObject[] hearths;
    private Vector3 offset;
    private Camera mainCamera;
    private string finalText = "PAJAK";
    private int health = 3;
    private string currentText = "";

    void Start()
    {
        mainCamera = Camera.main;
        GetComponent<Rigidbody2D>().isKinematic = false;
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
            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight / 2;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - objectHeight / 2;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.transform.tag;

        if(tag == "missile")
        {
            Destroy(hearths[health - 1]);
            health -= 1;
        }else
        {
            
        }
    }
}
