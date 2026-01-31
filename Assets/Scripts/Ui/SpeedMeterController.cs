using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeterController : MonoBehaviour
{
    [SerializeField] private Image speedMeterImage;
    private float lastValue = 0;
    private float r = 0,g= 0;

    // Start is called before the first frame update
    internal void AdjustSpeed(int speed,int topSpeed)
    {
        float value = (speed*1.0f) / (topSpeed*1.0f);
        speedMeterImage.fillAmount = value;
        if (value > 0.5f) speedMeterImage.color = Color.green;
        else speedMeterImage.color = Color.red;
    }
}
