using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pmovement : MonoBehaviour
{

    public Camera mainCamera;
        
    private float speed = 5.0f;
    private float crouchSpeed = 2.5f;
    private float baseSpeed = 5f;
    private float maxSpeed = 10f;
    public float runSpeedMultiplier = 5f;

    private float rotation = 50.0f;

    private float maxJumps = 3f;
    private float jumps = 0f;
    public float jumpForce = 5f;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumps = maxJumps;
    }

    void Update()
    {

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

        Vector3 movement = forward * moveVertical + right * moveHorizontal;

        // Aplica el movimiento al Rigidbody
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        // Gira el objeto hacia la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion nuevaRotacion = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(rb.rotation, nuevaRotacion, rotation * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= runSpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            speed = crouchSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = baseSpeed;
        }
        

        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode.Impulse);
            Debug.Log(jumps);
            jumps--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "floor")
        {
            jumps = maxJumps;
        }
        if(collision.collider.tag == "wall")
        {
            jumps += 1;
        }
    }


}
