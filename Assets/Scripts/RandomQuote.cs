using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomQuote : MonoBehaviour
{
    public string[] quotes;
    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        int index = Random.Range(0, quotes.Length - 1);

        text.text = quotes[index];
    }
}
