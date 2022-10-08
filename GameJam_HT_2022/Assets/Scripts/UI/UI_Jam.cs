using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Jam : MonoBehaviour
{
    public PlayerResource playerJam;

    private float maxJam;

    private Slider slider;

    private void Start()
    {
        maxJam = playerJam.jam;
        slider = GetComponent<Slider>();
        slider.maxValue = maxJam;
    }

    private void Update()
    {
        slider.value = playerJam.jam;
    }
}
