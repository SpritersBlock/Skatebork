using UnityEngine;
using System.Collections;

public class PlayerMovement_2 : MonoBehaviour
{
    public float walkSpeed = 2;
    //[HideInInspector]
    public float gravity = -12;
    public float jumpHeight;
    [Range(0, 1)]
    public float airControlPercent;
    [HideInInspector]
    public bool invincible;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    [HideInInspector]
    public bool hasFood;
    bool doubleJumpOn;
    bool canCancelJump = true;
    [HideInInspector]
    public bool firstFood = true;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;
    public float iFramesDuration;

    public float gravityMin;
    public float gravityMed;
    public float gravityMax;
    
    public JaeGameManager gm;
    Transform cameraT;
    [HideInInspector]
    public CharacterController controller;
    public ParticleSystem skidPFX;
    public ParticleSystem skidPFX2;
    public GameObject playerAnimNull;
    private Animator anim;
    public PoofSpawner poofSpawner;

    [HideInInspector]
    public Vector2 inputDir;

    void Start()
    {
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        anim = playerAnimNull.GetComponent<Animator>();
    }

    void Update()
    {
        // input
        if (gm.gameOn)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            inputDir = input/*.normalized*/; //Commented this out to get that gradual acceleration effect. 

            //Move(inputDir); //Commented this out because it's done in FixedUpdate() instead.

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (controller.isGrounded)
                {
                    Jump(1);
                }
                else if (doubleJumpOn)
                {
                    Jump(1.3f);
                }
            }

            if (Input.GetKeyUp(KeyCode.Space) && velocityY > 0 && canCancelJump)
            {
                if (!doubleJumpOn)
                {
                    //velocityY = -3; //Cuts a jump short.
                    if (gravity != gravityMax)
                    {
                        gravity = gravityMax;
                    }
                }
            }

            float groundedFloat = anim.GetFloat("GroundedFloat");

            var em = skidPFX.GetComponent<ParticleSystem>().emission;
            var em2 = skidPFX2.GetComponent<ParticleSystem>().emission;
            if (controller.isGrounded)
            {
                em.enabled = true;
                em2.enabled = true;
                if (!canCancelJump)
                {
                    canCancelJump = true;
                }
                if (doubleJumpOn)
                {
                    doubleJumpOn = false;
                    //print(doubleJumpOn);
                }
                if (anim.GetFloat("GroundedFloat") > 0)
                {
                    anim.SetFloat("GroundedFloat", groundedFloat -= 10f * Time.deltaTime);
                }
                
                if (gravity != gravityMed)
                {
                    gravity = gravityMed;
                }
                
                //Debug.Log("IS GROUNDED");
            }
            else if (!controller.isGrounded)
            {
                em.enabled = false;
                em2.enabled = false;
                if (anim.GetFloat("GroundedFloat") < 1)
                {
                    anim.SetFloat("GroundedFloat", groundedFloat += 10f * Time.deltaTime);
                }
                //Debug.Log("IS NOT GROUNDED");
            }
        }
    }

    private void FixedUpdate()
    {
        Move(inputDir);

        if (velocityY <= 0.3f && velocityY >= -0.3f && !controller.isGrounded) //If the player is around about the apex of their jump.
        {
            Debug.Log("WORKING");
            //velocityY = -2;
            gravity = gravityMin;
        } else
        {
            if (gravity != gravityMed)
            {
                gravity = gravityMed;
            }
        }
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
        //print(velocityY);
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
        //print("AAHH");
        float jumpVelocity = Mathf.Sqrt(-1.6f * gravity * jumpHeight * jumpMult);
        velocityY = jumpVelocity;
        if (jumpMult != 1)
        {
            if (doubleJumpOn && jumpMult == 1.3f)
            {
                doubleJumpOn = false;
                canCancelJump = false;
                FindObjectOfType<AudioPlayer>().Play("DJump");
                poofSpawner.SpawnPoofRing(transform.position, gameObject.transform);
                anim.SetTrigger("DoubleJump");
            }
            else
            {
                canCancelJump = false;
                FindObjectOfType<AudioPlayer>().Play("Stun");
                FindObjectOfType<AudioPlayer>().Play("SquealFast");
                FindObjectOfType<AudioPlayer>().Play("Splat");
                doubleJumpOn = true;
                anim.SetTrigger("Jump");
                //print(doubleJumpOn);
            }
        }
        else
        {
            FindObjectOfType<AudioPlayer>().Play("Jump");
            anim.SetTrigger("Jump");
        }
        
        //print(jumpVelocity);
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

    public void TakeDamage()
    {
        if (!invincible)
        {
            //health--;
            gm.playerHealth--;
            gm.UpdateHealth();
            if (gm.playerHealth > 0)
            {
                StartCoroutine("IFrames", iFramesDuration);
            }
            else
            {
                //Whatever happens when the player dies. Leaving the below line for DEBUG PURPOSES ONLY
                gm.ChangeTrolleyTargetsToBoss();
                PlayerDie();
                //StartCoroutine("IFrames", iFramesDuration);
            }
        }
    }

    IEnumerator IFrames(float time)
    {
        invincible = true;
        //anim.SetBool("Invincible", true);
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= time)
        {
            invincible = false;
            //anim.SetBool("Invincible", false);
            yield return null;
        }
    }

    public void PlayerDie()
    {
        invincible = true;
        
        ItemController[] foodInScene;
        foodInScene = FindObjectsOfType<ItemController>();

        if (hasFood)
        {
            for (int i = 0; i < foodInScene.Length; i++)
            {
                if (foodInScene[i].isHeld == true)
                {
                    foodInScene[i].isHeld = false;
                    foodInScene[i].rb.isKinematic = false;
                    foodInScene[i].rb.useGravity = true;
                }
            }
        }
        
        gameObject.SetActive(false);
    }
}
