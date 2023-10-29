using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c_collision : MonoBehaviour
{
    private float coin_count = 8;

    private void Update()
    {
        if (coin_count == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            coin_count -= 1;
            Destroy(gameObject);
        }
    }
}
