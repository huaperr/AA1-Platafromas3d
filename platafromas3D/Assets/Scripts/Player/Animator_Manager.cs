using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Manager : MonoBehaviour
{

    private Animator animator;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float totalSpeed = (controller.velocity.magnitude) / 10;


        if (totalSpeed < 0)
        {
            totalSpeed *= -1;
        }

        animator.SetFloat("Blend", totalSpeed);

        animator.SetFloat("Jump", controller.velocity.y);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("crounched", true);
        }
        else
        {
            animator.SetBool("crounched", false);
        }
    }
}
