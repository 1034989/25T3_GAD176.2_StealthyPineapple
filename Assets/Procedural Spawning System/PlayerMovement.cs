using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 5f;
    public float speedAcceleration = 5f;

    private float targetSpeed;
    private float currentSpeed;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();

        currentSpeed = baseSpeed;
        targetSpeed = baseSpeed;
    }

    void Update()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Smoothly interpolate current speed toward target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * speedAcceleration);

        Vector3 velocity = direction * currentSpeed;
        if (velocity.magnitude > 0)
        {
            velocity = transform.TransformDirection(velocity);
            controller.Move(velocity * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        targetSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        targetSpeed = baseSpeed;
    }
}
