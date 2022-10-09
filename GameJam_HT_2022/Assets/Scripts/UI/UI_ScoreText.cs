using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScoreText : MonoBehaviour
{
    [SerializeField] private Text text;

    private void OnEnable()
    {
        text = GetComponent<Text>();
    }
    public void SetText()
    {
        text.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
}