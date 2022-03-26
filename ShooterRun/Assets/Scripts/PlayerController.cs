using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInputs playerInputs;

    float limitX=10f;
    float xAxis;
    float speed=10f;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }
    private void Start()
    {
       
        playerInputs.PlayerMovement.Movement.performed += OnMoveX;

        playerInputs.PlayerMovement.Fire.started += OnFire;
        playerInputs.PlayerMovement.Fire.canceled += OffFire;
  
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime*-1));
    }


    void OnMoveX(InputAction.CallbackContext context)
    {
        if (Input.GetMouseButton(0))
        {
            xAxis = context.ReadValue<float>();
            transform.position -= new Vector3(xAxis / 6, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitX, limitX), transform.position.y, transform.position.z);  
        }

    }

    void OnFire(InputAction.CallbackContext context)
    {      
        InvokeRepeating(nameof(Fire), 0.1f, 1f);       
    }

    void OffFire(InputAction.CallbackContext context)
    {
        CancelInvoke(nameof(Fire));
    }

    void Fire()
    {
        Debug.Log("Ateş ediliyor");
    }
    

    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

}