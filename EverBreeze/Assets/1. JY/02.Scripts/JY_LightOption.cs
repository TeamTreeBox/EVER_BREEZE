using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_LightOption : MonoBehaviour
{
    public Slider slider;
    public Light ScreenLight;

    private void Start()
    {
        slider.value = 0.59f;
    }

    public void Update()
    {
        ScreenLight.intensity = slider.value;
    }
}
