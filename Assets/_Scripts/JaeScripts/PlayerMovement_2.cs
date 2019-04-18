using UnityEngine;
using System.Collections;

public class PlayerMovement_2 : MonoBehaviour
{

    public float walkSpeed = 2;
    //public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    [Range(0, 1)]
    public float airControlPercent;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    //Animator animator;
    Transform cameraT;
    CharacterController controller;
    public ParticleSystem skidPFX;
    public ParticleSystem skidPFX2;

    void Start()
    {
        //animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input/*.normalized*/;
        bool running = Input.GetKey(KeyCode.LeftShift);

        Move(inputDir);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (controller.isGrounded)
            {
                Jump(1);
            }
        }

        var em = skidPFX.GetComponent<ParticleSystem>().emission;
        var em2 = skidPFX2.GetComponent<ParticleSystem>().emission;
        if (controller.isGrounded)
        {
            em.enabled = true;
            em2.enabled = true;
            //Debug.Log("IS GROUNDED");
        } else if (!controller.isGrounded)
        {
            em.enabled = false;
            em2.enabled = false;
            //Debug.Log("NOPE");
        }
        // animator
        //float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }

    void Move(Vector2 inputDir)
    {
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        float targetSpeed = walkSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

    }

    public void Jump(float jumpMult)
    {
        print("AAHH");
        float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight * jumpMult);
        velocityY = jumpVelocity;
    }

    float GetModifiedSmoothTime(float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }

        if (airControlPercent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }
}
