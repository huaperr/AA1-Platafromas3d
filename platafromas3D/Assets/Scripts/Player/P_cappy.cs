using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_cappy : MonoBehaviour
{

    bool go;

    GameObject player;
    GameObject cappy;

    Transform itemToRotate;

    Vector3 locationInFrontOfPlayer;


    // Use this for initialization
    void Start()
    {
        go = false;

        player = GameObject.Find("Mario");
        cappy = GameObject.Find("Cappy");


        itemToRotate = gameObject.transform.GetChild(0);     

       
        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 5f;

        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }
    void Update()
    {
        itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);

        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 40);         
        }

        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 40); 
        }

        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
        
            Destroy(this.gameObject);
        }
    }
