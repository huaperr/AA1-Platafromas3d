using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    private float jumpForce = 10f; // Ajusta este valor según tus necesidades

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("maricon");
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            }
        }
    }
}