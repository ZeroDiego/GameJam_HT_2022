using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Time : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        text.text = "" + Mathf.FloorToInt(timer);
    }
}
