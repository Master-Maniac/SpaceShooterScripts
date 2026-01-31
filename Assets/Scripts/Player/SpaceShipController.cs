using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private UiController uiController;

    private readonly int lowestSpeed = 50;
    private int topSpeed = 200;
    [SerializeField] private int movementSpeed = 2;
    [SerializeField] private float sideRotaionSpeed =2;
    [SerializeField] private float upRotationSpeed =2;

    private float yaw;
    private float pitch;
    Quaternion defaultRotation;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        defaultRotation = transform.localRotation;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _Input();
        Movement();
        Rotation();
    }
    private void _Input()
    {
        yaw += Input.GetAxis("Horizontal") * sideRotaionSpeed * Time.deltaTime;
        pitch -= Input.GetAxis("Vertical") * upRotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) IncreaseSpeed();
        if (Input.GetKey(KeyCode.E)) DecreaseSpeed();
    }

    private void Movement()
    {
       transform.position +=  transform.forward*movementSpeed*Time.deltaTime;
     
    }
    private void Rotation()
    {

        transform.localRotation =
          Quaternion.Euler(pitch, yaw, 0f);
    }
    private void IncreaseSpeed()
    {
        if (movementSpeed >= topSpeed) return;
        movementSpeed += 1;
        uiController.AdjustSpeed(movementSpeed,topSpeed);
    }
    private void DecreaseSpeed()
    {
        if (movementSpeed <= lowestSpeed) return;
        movementSpeed -= 1;
        uiController.AdjustSpeed(movementSpeed, topSpeed);
    }

}
