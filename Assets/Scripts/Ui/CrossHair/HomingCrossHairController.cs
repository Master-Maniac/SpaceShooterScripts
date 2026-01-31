using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCrossHairController : MonoBehaviour
{
    public RectTransform boundingBox;
    public RectTransform crosshair;
    [SerializeField] private Vector2 offsetX, offsetY;

    public float sensitivity = 1f;
    RaycastHit hit;
    void Update()
    {
        // Mouse movement since last frame
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Move crosshair by delta
        Vector2 newPos = crosshair.localPosition;
        newPos += new Vector2(mouseX, mouseY);

        // Clamp inside bounding box
        Rect bounds = boundingBox.rect;
        newPos.x = Mathf.Clamp(newPos.x, bounds.xMin + offsetX[0], bounds.xMax + offsetX[1]);
        newPos.y = Mathf.Clamp(newPos.y, bounds.yMin + offsetY[0], bounds.yMax + offsetY[1]);

        crosshair.localPosition = newPos;

        _Input();
    }
    private void _Input()
    {
        if (Input.GetKey(KeyCode.Mouse0)) Shoot();

    }
    private void Shoot()
    {

        Ray ray = new Ray(crosshair.localPosition, crosshair.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.Log("Hit at distance: " + hit.distance);
        }
        Debug.DrawLine(
     ray.origin,
     ray.origin + ray.direction * 100f,
     Color.green
 );

    }
}
