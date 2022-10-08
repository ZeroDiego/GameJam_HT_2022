using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    private float maxHP;

    private Slider slider;

    private void Start()
    {
        maxHP = PlayerResource.Instance.hitPoints;
        slider = GetComponent<Slider>();
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }

    private void Update()
    {
        slider.value = PlayerResource.Instance.hitPoints;
    }
}
