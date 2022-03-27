using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"|| other.tag == "Obstacle")
        {

            transform.GetChild(0).GetComponent<Animator>().SetBool("die", true);
            GetComponent<PlayerController>().enabled = false;
            
            //Level restart
        }
        
    }


}
