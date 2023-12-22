using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    public static InputHandle Instance;
    private PlayerControls playerControls;

    public float horizontal;
    public float vertical;

    public bool Jump;


    private void Awake()
    {
        if (InputHandle.Instance == null)
        {
            InputHandle.Instance = this;
            playerControls = new PlayerControls();
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        MoveInput();
        JumpInput();
    }

    private void JumpInput()
    {
        playerControls.PlayerMovement.Jump.performed += InputAction => Jump = true;
    }

    private void MoveInput()
    {
        playerControls.PlayerMovement.Left.started += InputAction => horizontal = -1;
        playerControls.PlayerMovement.Left.canceled += InputAction => horizontal = 0;
        playerControls.PlayerMovement.Right.started += InputAction => horizontal = 1;
        playerControls.PlayerMovement.Right.canceled += InputAction => horizontal = 0;
    }

    public void SetHorizontal()
    {
        
    }
}
