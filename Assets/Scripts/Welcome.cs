using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public int targetScene;

    public void Play()
    {
        SceneManager.LoadScene(7);
    }
}