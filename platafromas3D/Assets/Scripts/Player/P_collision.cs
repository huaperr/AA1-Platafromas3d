using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_collision : MonoBehaviour
{
    public float coin_count = 8;
    public Rigidbody player;
    private float y = 100, z = 100;
    private void Update()
    {
        if (coin_count == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }

        if (hit.collider.tag == "Player")
        {
            player.AddForce(0, y, z);
        }

        if (hit.collider.tag == "cappy")
        {
            player.AddForce(0, y, z);
        }
    }
}
