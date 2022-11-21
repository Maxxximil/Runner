using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;
    //private Animator _animator;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, moveSpeed, 0);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

    }
}
