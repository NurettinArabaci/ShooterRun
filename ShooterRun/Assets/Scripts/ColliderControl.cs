using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            other.GetComponent<BoxCollider>().enabled = false;
            
        }
        else if (other.tag == "Floor")
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            objectPooling.BackToPool(transform.gameObject, "Bullet");
        }
        
    }*/
}
