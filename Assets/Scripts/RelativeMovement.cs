using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Vector3 leftPos;
    [SerializeField] private Vector3 rightPos;
    [SerializeField] private Vector3 midPos;

    public float moveSpeed = 6.0f;
    public float gravity = -9.8f;
    public float jumpForce = 10f;
   
    private Animator _animator;
    private Rigidbody _rb;
    private CharacterController _charController;

    
    private Vector3 vector;
    private bool _isJumping;
    

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _rb = this.GetComponent<Rigidbody>();
        _animator.SetBool("Run", true);
        vector = new Vector3(3, 0, 0);
    }

    private void Update()
    {

        Vector3 movement = new Vector3(0, 0, moveSpeed);
        Vector3 leftborder = new Vector3(leftPos.x, 0, 0);
        Vector3 rightborder = new Vector3(rightPos.x, 0, 0);
        Vector3 middleborder = new Vector3(midPos.x, 0, 0);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        leftborder = transform.TransformDirection(leftborder);
        rightborder = transform.TransformDirection(rightborder);
        middleborder = transform.TransformDirection(middleborder);

        _charController.Move(movement);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && _charController.transform.position.x != leftborder.x
            && _charController.transform.position.x == middleborder.x)
        {
            _charController.Move(-vector);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && _charController.transform.position.x != leftborder.x
            && _charController.transform.position.x == rightborder.x)
        {
            _charController.Move(-vector);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _charController.transform.position.x != rightborder.x
            && _charController.transform.position.x == middleborder.x)
        {
            _charController.Move(vector);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && _charController.transform.position.x != rightborder.x
            && _charController.transform.position.x == leftborder.x)
        {
            _charController.Move(vector);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isJumping)
        {
            Jump(movement);
        }


    }

    public void FixedUpdate()
    {
        _isJumping = !CheckCollisionOverlap();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lose")
        {
            moveSpeed = 0;
            _animator.SetBool("Run", false);
        }
    }

    private void Jump(Vector3 vec)
    {
        Debug.Log("Jump");
        //vec.y = 10 * 5 * Time.deltaTime;
        //_charController.Move(vec);


        transform.Translate(Vector3.up * 0.2f);
        _rb.AddForce(transform.up * 14f, ForceMode.Impulse);

        _isJumping = true;
        _animator.SetBool("Jump", true);
    }

    public bool CheckCollisionOverlap()
    {
        Vector3 point;
        point = this.transform.position;
        return Physics.OverlapSphere(point, 0.1f , 3).Length > 0;
    }
}
