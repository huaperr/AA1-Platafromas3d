using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class P_collisions : MonoBehaviour
{
    private float coin_count = 8;


    public float impulseForce = 1000f;
    public Vector3 impulseDirection = Vector3.up;

    bool plataform;

    CharacterController ch;

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if(hit.collider.tag == "enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            coin_count -= 1;
            Destroy(other.gameObject);

            if (coin_count == 0)
            {
                SceneManager.LoadScene("victory");
            }
        }

        if (other.tag == "plataform")
        {
            ch.Move(new Vector3(0,100,0));
        }
    }

    
}
