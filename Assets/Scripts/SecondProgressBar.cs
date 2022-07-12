using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondProgressBar : MonoBehaviour
{
    public Slider secondProgressSlider;
    void Awake()
    {
        secondProgressSlider = GetComponent<Slider>();
    }
}
