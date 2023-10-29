using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_attack : MonoBehaviour
{

    public float cappy_count = 3;
    public GameObject cappy;
    // Update is called once per frame
    void Update()
    {
           
            if (cappy_count >= 0)
            {
                cappy_count -= 1 *  Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
            if (cappy_count <= 0)
                    {
                        GameObject clone;
                        clone = Instantiate(cappy, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
                        cappy_count = 1.5f;
                    }

            }
        
    }
}
