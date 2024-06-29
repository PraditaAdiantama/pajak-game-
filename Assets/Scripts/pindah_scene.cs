using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pindah_scene : MonoBehaviour
{
    public float delayBeforeSwitch = 3f;
    public int targetScene;

    void Start()
    {
        if (delayBeforeSwitch > 0)
        {
            Invoke("LoadScene1", delayBeforeSwitch);
        }
        // Jika delayBeforeSwitch <= 0, pindah scene secara langsung
        else
        {
            LoadScene1();
        }
        
    }

     public void LoadScene1()
    {
        SceneManager.LoadScene(targetScene);
    }


}
