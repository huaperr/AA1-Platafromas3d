using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Manager : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float aux = (rb.velocity.z + rb.velocity.x) / 10;
        
        if(aux < 0 ) 
        {
            aux *= -1;
        }
        animator.SetFloat("Blend", aux);
        animator.SetFloat("Jump", rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crounched", true);
        }
        else
        {
            animator.SetBool("crounched", false);
        }

        
    }
}
