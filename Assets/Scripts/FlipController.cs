using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    [SerializeField] private float flipPower = 20;
    [SerializeField] private float maxAngleSide = 56;
    [SerializeField] private float maxAngleUp = 10;
    [SerializeField] private float lerpingSpeed = 5f;
    private float yaw;
    private float pitch;
    private float currentAngleX,currentAngleY ;
    
    // Start is called before the first frame update

    
    void Update()
    {
        _Input();
        SpaceShipFlip();
    }
    private void _Input()
    {
        yaw = Input.GetAxis("Horizontal") ;
        pitch = Input.GetAxis("Vertical");
    }
    private void SpaceShipFlip()
    {
        CalculateAngle();
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(currentAngleY, 0f, currentAngleX),lerpingSpeed*Time.deltaTime);



       // transform.localRotation = horFlip;
    }
    private void CalculateAngle()
    {
        currentAngleX = yaw * maxAngleSide*-1f;
        currentAngleY = pitch * maxAngleUp*-1f;
       
    }
}
