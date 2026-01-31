using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private SpeedMeterController speedMeterController;
    // Start is called before the first frame update
    internal void AdjustSpeed(int speed,int topSpeed)=>speedMeterController.AdjustSpeed(speed, topSpeed);
}
