using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    //Con character controller funcioanaba mal
    private Rigidbody rb;
    private float y;
    private float z = 50000000000000;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            rb.AddForce(0, y, z);
        }
    }
}
