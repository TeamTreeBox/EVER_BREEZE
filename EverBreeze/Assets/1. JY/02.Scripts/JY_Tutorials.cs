using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Tutorials : MonoBehaviour
{
    public GameObject tutorialUI;

    void Start()
    {
        tutorialUI.SetActive(true);
    }

    public void OnTutorialQuit()
    {
        tutorialUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
