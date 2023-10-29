using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_rotation : MonoBehaviour
{
    public float rotateSpeed = 1;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
