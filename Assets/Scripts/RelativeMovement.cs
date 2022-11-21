using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Vector3 leftPos;
    [SerializeField] private Vector3 rightPos;
    [SerializeField] private Vector3 midPos;

    private float laneOffset = 3f;
    private float laneChangeSpeed = 30;
    public float moveSpeed = 6.0f;
    public float gravity = -9.8f;
    float pointStart;
    float pointFinish;
    bool isMoving = false;
    Coroutine MovingCoroutine;
    //public float leftPos = 3f;
    //public float rightPos = -3f;
    //public float midPos = 0f;

    private CharacterController _charController;
    Rigidbody rb;
    Vector3 targetVelocity;
    Vector3 targetPos;
    //private Animator _animator;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {

        Vector3 movement = new Vector3(0, moveSpeed, 0);
        Vector3 leftborder = new Vector3(leftPos.x, 0, 0);
        Vector3 rightborder = new Vector3(rightPos.x, 0, 0);
        Vector3 middleborder = new Vector3(midPos.x, 0, 0);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        leftborder = transform.TransformDirection(leftborder);
        rightborder = transform.TransformDirection(rightborder);
        middleborder = transform.TransformDirection(middleborder);

        _charController.Move(movement);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_charController.transform.position.x != leftborder.x)
            {
                if (_charController.transform.position.x != rightborder.x)
                {
                    leftborder.x -= _charController.transform.position.x;
                    _charController.Move(leftborder);
                }
                else
                {
                    middleborder.x -= _charController.transform.position.x + 3;
                    _charController.Move(middleborder);
                    //middleborder.x -= _charController.transform.position.x;
                    //transform.position = middleborder;
                    //_charController.Move(middleborder);
                    //Debug.Log("Right pos");
                }
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_charController.transform.position != rightborder)
            {
                rightborder.x -= _charController.transform.position.x;
                _charController.Move(rightborder);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_charController.transform.position != middleborder)
            {
                middleborder.x -= _charController.transform.position.x;
                _charController.Move(middleborder);
            }
        }
    }

    //private void Update()
    //{
    //    Vector3 movement = new Vector3(0, moveSpeed, 0);
    //    movement *= Time.deltaTime;
    //    movement = transform.TransformDirection(movement);
    //    _charController.Move(movement);
    //    if (Input.GetKey(KeyCode.LeftArrow) && pointFinish > -laneOffset)
    //    {
    //        MoveHorizontal(-laneChangeSpeed);
    //    }
    //    if (Input.GetKey(KeyCode.RightArrow) && pointFinish < laneOffset)
    //    {
    //        MoveHorizontal(laneChangeSpeed);
    //    }
    //}



    //void MoveHorizontal(float speed)
    //{
    //    pointStart = pointFinish;
    //    pointFinish += Mathf.Sign(speed) * laneOffset;

    //    if (isMoving)
    //    {
    //        StopCoroutine(MovingCoroutine);
    //        isMoving = false;
    //    }

    //    MovingCoroutine = StartCoroutine(MoveCoroutine(speed));


    //}

    //IEnumerator MoveCoroutine(float vectorX)
    //{
    //    isMoving = true;
    //    while(Mathf.Abs(pointStart - transform.position.x) < laneOffset)
    //    {
    //        yield return new WaitForFixedUpdate();

    //        rb.velocity = new Vector3(vectorX, rb.velocity.y, 0);
    //        float x = Mathf.Clamp(transform.position.x, Mathf.Min(pointStart, pointFinish), Mathf.Max(pointStart, pointFinish));
    //        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    //    }
    //    rb.velocity = Vector3.zero;
    //    transform.position = new Vector3(pointFinish, transform.position.y, transform.position.z);
    //    isMoving = false;
    //}
}
