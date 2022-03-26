using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ColliderControl : MonoBehaviour
{
    ObjectPooling objectPooling;

    private void Awake()
    {
        objectPooling = ObjectPooling.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
            other.transform.GetChild(0).GetComponent<Animator>().SetBool("die", true);
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<NavMeshFollow>().enabled = false;
            other.GetComponent<NavMeshAgent>().enabled = false;


        }
        else if (other.tag == "Floor")
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
        }
    }
    
}
