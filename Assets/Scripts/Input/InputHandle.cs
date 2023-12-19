using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    public static InputHandle Instance;
    public float horizontal;
    public float vertical;

    public bool Jump;


    private void Awake()
    {
        if (InputHandle.Instance == null)
        {
            InputHandle.Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        MoveInput();
        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w");
            Jump = true;
        }
    }

    private void MoveInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
}
