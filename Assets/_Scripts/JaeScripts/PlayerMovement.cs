using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool canMove;
    public bool movingForward;
    public bool movingBackward;

    private float moveSpeed;
    public float speedMultiplier; // Controls how fast the player can move, because it multiplies the Vertical axis in Unity's input manager
    private float turnSpeed;
    public float turnMultiplier;

    private Rigidbody rb;

    //Vector2 input;
    
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
        //input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        CalculateMovement();
	}

    void CalculateMovement()
    {
        if (canMove)
        {
            #region Moving Forward + Backward
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
            moveSpeed = Input.GetAxis("Vertical") * speedMultiplier;
            turnSpeed = Input.GetAxis("Horizontal") * turnMultiplier;

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.localEulerAngles += new Vector3(0, turnSpeed * Time.deltaTime, 0);
            
        }
    }
}
