using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float speed = 5f;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisible())
        {
            Destroy(gameObject);
        }

        if (stop == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    bool IsVisible()
    {
        // Calculate the object's viewport position
        if (this.transform.position.x < -12)
        {
            return true;
        }
        return false;
    }

    public void Stop()
    {
        stop = true;
    }

}
