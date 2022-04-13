using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoProgressUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetProgress(float progress)
    {
        _slider.value = progress;
    }
}
