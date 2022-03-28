using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class ColliderController : MonoBehaviour
{
    public static ColliderController Instance;

    [SerializeField] GameObject enemiesParent;
    [SerializeField] CinemachineVirtualCameraBase vcam;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        EnabledOpenClose(transform.gameObject, enemiesParent, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy"|| other.tag == "Obstacle")
        {
            EnabledOpenClose(transform.gameObject, enemiesParent, false);

            ButtonController.Instance.restartBut.gameObject.SetActive(true);
        }
        else if (other.tag=="Finish")
        {
            
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            enemiesParent.SetActive(false);
            vcam.m_Priority = 15;

            GetComponent<PlayerController>().enabled = false;
            transform.GetChild(0).GetComponent<Animator>().SetBool("dance", true);

            LevelController.Instance.LevelCompleted();

        }
        
    }

    public void EnabledOpenClose(GameObject player,GameObject enemiesParent, bool isEnabled)
    {
        player.GetComponent<PlayerController>().enabled = isEnabled;
        player.transform.GetChild(0).GetComponent<Animator>().enabled = isEnabled;

        for (int i = 0; i < enemiesParent.transform.childCount; i++)
        {
            enemiesParent.transform.GetChild(i).GetComponent<NavMeshAgent>().enabled = isEnabled;
            enemiesParent.transform.GetChild(i).GetComponent<NavMeshFollow>().enabled = isEnabled;
            enemiesParent.transform.GetChild(i).GetChild(0).GetComponent<Animator>().enabled = isEnabled;
        }
    }

    

}
