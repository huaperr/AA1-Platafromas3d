using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pmovement : MonoBehaviour
{

    public Camera mainCamera;
        
    private float speed = 5.0f;
    private float baseSpeed = 5f;
    private float maxSpeed = 10f;
    public float runSpeedMultiplier = 5f;

    private float rotation = 2.0f;

    private float maxJumps = 3f;
    private float jumps = 0f;
    public float jumpForce = 5f;

    private float gravityScale = 5f;

    private static float globalGravity = -9.81f;

    private bool isGrounded;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumps = maxJumps;
    }

    void Update()
    {
        /*
         //Gravedad

        // Obtén la dirección de movimiento desde las entradas de teclado o joystick
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento en función de la cámara
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movimiento = forward * moveVertical + right * moveHorizontal;

        // Aplica el movimiento al Rigidbody
        rb.velocity = movimiento * speed;

        // Gira el objeto hacia la dirección de movimiento
        if (movimiento != Vector3.zero)
        {
            Quaternion nuevaRotacion = Quaternion.LookRotation(movimiento);
            rb.rotation = Quaternion.Slerp(rb.rotation, nuevaRotacion, rotation * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= runSpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }
        */
       

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            rb.AddForce(new Vector2(0, 100), ForceMode.Impulse);
            jumps--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "floor")
        {
            jumps = maxJumps;
        }
    }


}
