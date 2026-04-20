using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //basic movement
    [SerializeField] CharacterController controller; //references PLayerController's Character Controller
    [SerializeField] private float baseSpeed = 30f; //base movement speed without modifiers

    //gravity
    private Vector3 fallingVelocity;
    [SerializeField] private float gravity = -9.81f;

    //ground check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.4f;
    private LayerMask groundMask;
    private bool isGrounded;

    //jump
    [SerializeField] private float jumpHeight = 10f;

    //dash
    [SerializeField] private float dashPower = 50f;
    [SerializeField] private float dashDeceleration = -1f;
    private Vector3 dashVector;
    private Vector3 dashDirectionNormalized;
    [SerializeField] private float dashCooldown = 2f;
    private float timeSinceDash = 0f;

    //TO DO
    //Wall climb
    //Wall jump
    //Variable jump height

    // Start is called before the first frame update
    void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        //checks if an invisible sphere at the position of groundCheck with radius checkRadius is touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundMask);
        if (isGrounded && fallingVelocity.y < 0)
        {
            //a small value will force player to stick to ground even if sphere triggers before
            fallingVelocity.y = -1f;
        }

        //getting input from player over movement controls
        float sideMove = Input.GetAxis("Horizontal");
        float forwardMove = Input.GetAxis("Vertical");

        //move the character based on input, multiply by baseSpeed and make it fps independent
        Vector3 move = transform.forward * forwardMove + transform.right * sideMove;
        move *= baseSpeed * Time.deltaTime;
        controller.Move(move);

        //check if jump key is pressed down and player on floor, if yes then jump a set distance using v = sqrt(-2gh)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
        }

        //add downwards velocity based on gravity; displacement is proportional to gt^2
        fallingVelocity.y += gravity * Time.deltaTime;

        //handle dash cooldown; if dash is possible, then add to dashVector. Also find last dash direction and save it.
        if (Input.GetButtonDown("Dash") && timeSinceDash >= dashCooldown)
        {
            timeSinceDash = 0f;
            dashDirectionNormalized = transform.forward * forwardMove + transform.right * sideMove;
            dashDirectionNormalized = dashDirectionNormalized.normalized;
            dashVector += dashDirectionNormalized * dashPower * Time.deltaTime;
        }
        else
        {
            timeSinceDash += Time.deltaTime;
        }

        //apply the fallingVelocity and dashVector to the movement
        controller.Move(fallingVelocity * Time.deltaTime);
        controller.Move(dashVector);

        //decrease the dash velocity until it reaches 0 then stop
        dashVector += dashDeceleration * dashDirectionNormalized * Time.deltaTime;
        if (dashVector.normalized == -1 * dashDirectionNormalized) dashVector *= 0;
    }

    //for debug: displays the groundCheck sphere
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
