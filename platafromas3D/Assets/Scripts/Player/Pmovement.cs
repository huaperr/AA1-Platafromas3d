using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pmovement : MonoBehaviour
{
    public static Pmovement Instance;


    public Camera mainCamera;

    private float speed = 5.0f;
    private float crouchSpeed = 2.5f;
    private float baseSpeed = 5f;
    public float runSpeedMultiplier = 2f;

    private float rotation = 50.0f;

    private float maxJumps = 3f;
    private float jumps = 0f;
    public float jumpForce = 5f;

    public Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float gravity = 20.0f;

    void Start()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
        controller = GetComponent<CharacterController>();
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

        // Mueve el CharacterController
        if (controller.isGrounded)
        {
            moveDirection = movement * speed;

            if (Input.GetButtonDown("Jump") && jumps > 0)
            {
                moveDirection.y = jumpForce;
                jumps--;
            }
        }

        // Aplica la gravedad manualmente
        moveDirection.y -= gravity * Time.deltaTime;

        // Mueve el CharacterController
        controller.Move(moveDirection * Time.deltaTime);

        // Gira el objeto hacia la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion nuevaRotacion = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, nuevaRotacion, rotation * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= runSpeedMultiplier;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = baseSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed = crouchSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = baseSpeed;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "floor")
        {
            jumps = maxJumps;
        }
        if (hit.collider.tag == "wall")
        {
            jumps += 1;
        }
    }


}
