using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Jam : MonoBehaviour
{
    private float maxJam;

    private Slider slider;

    private void Start()
    {
        maxJam = PlayerResource.Instance.jam;
        slider = GetComponent<Slider>();
        slider.maxValue = maxJam;
        slider.value = maxJam;
    }

    private void Update()
    {
        slider.value = PlayerResource.Instance.jam;
    }
}
