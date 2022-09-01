using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_ValumManager : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    private void Start()
    {
        slider.value = 0.59f;
    }

    public void Update()
    {
        audioSource.volume = slider.value;
    }
}
