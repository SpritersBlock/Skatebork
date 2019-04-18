using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour {

    public bool canMove;
    public bool movingForward;
    public bool movingBackward;

    private float moveSpeed;
    public float speedMultiplier; // Controls how fast the player can move, because it multiplies the Vertical axis in Unity's input manager
    private float turnSpeed;
    public float turnMultiplier;
    public float standUpTime;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public float gravity = -12;
    public float jumpHeight = 1;
    [Range(0, 1)]
    public float airControlPercent;

    float currentSpeed;
    float velocityY;
    //float gravity = 14.0f;
    public float jumpForce;

    [HideInInspector]
    //public Rigidbody rb;
    public Transform cameraT;
    CharacterController controller;

    Vector2 input;
    
    void Start () {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}
	
	void Update () {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        CalculateMovement();
	}

    void CalculateMovement()
    {
        //if (canMove)
        //{
            #region Moving Forward + Backward Bools
            if (Input.GetAxis("Vertical") > 0)
            {
                if (!movingForward)
                {
                    movingForward = true;
                }
                if (movingBackward)
                {
                    movingBackward = false;
                }
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (!movingBackward)
                {
                    movingBackward = true;
                }
                if (movingForward)
                {
                    movingForward = false;
                }
            }
            else if (Input.GetAxis("Vertical") == 0)
            {
                if (movingForward)
                {
                    movingForward = false;
                }
                if (movingBackward)
                {
                    movingBackward = false;
                }
            }
            #endregion
            if (movingForward || movingBackward)
            {
                moveSpeed += 1;
            }
            moveSpeed = Input.GetAxis("Vertical") * speedMultiplier;
            turnSpeed = Input.GetAxis("Horizontal") * turnMultiplier * Mathf.Abs(moveSpeed);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (Input.GetAxis("Vertical") > 0)
            {
                float targetRotation = Mathf.Atan2 (input.x, input.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            } else if (Input.GetAxis("Vertical") < 0)
            {
                //Buggy
                //float targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
            }

            if ((transform.localEulerAngles.z >= 80 ) || (transform.localEulerAngles.z <= -80))
            {
                //StartCoroutine(StandUp(transform.localEulerAngles.z, 0, standUpTime)); //Buggy
            }
        //}


        velocityY += Time.deltaTime * gravity;
        
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }

    IEnumerator StandUp(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;
        Debug.Log("AAA + " + transform.localEulerAngles.z);

        while (timer < time)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Lerp(start, end, timer / time));
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }
    }

    public void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }
}
