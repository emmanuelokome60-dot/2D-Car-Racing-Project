using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 5f;

    public float rotationSpeed = 200f;


    private Rigidbody2D rb;

    float moveInput, turnInput;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = -Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * moveInput * speed;
        rb.angularVelocity = turnInput * rotationSpeed;
    }

}
