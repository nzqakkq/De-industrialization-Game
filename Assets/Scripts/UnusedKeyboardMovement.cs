using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    //this
    Transform playerCameraTransform;
    //set the movement speed of the character, can be changed in editor
    [SerializeField] private float moveSpeed = 20;


    // Start is called before the first frame update
    private void Start()
    {
        //find the Main Camera object; if it exists, assign its transform to playerCameraTransform
        GameObject targetObject = GameObject.Find("Main Camera");
        if (targetObject != null) {
            playerCameraTransform = targetObject.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //input vector for WASD
        Vector2 wasdVector = new Vector2(0, 0);

        //sprint button to multiply speed by 1.5 WIP WIP WIP
        float sprintMultiplier = 1f;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { 
            sprintMultiplier = 1.5f; 
        }

        //assign value for each WASD input
        if (Input.GetKey(KeyCode.W)) {
            wasdVector.y += 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            wasdVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            wasdVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            wasdVector.x += 1;
        }

        //normalization to unit vector so speed is constant
        wasdVector = wasdVector.normalized;

        //transform to 3D
        Vector3 movementVector = new Vector3(wasdVector.x, 0, wasdVector.y);

        //problem with rotating vector based on camera is vertical camera angle, so following is done:
        //make a normalized vector based on camera that is only where the camera is pointing with no upwards direction
        Vector3 cameraForward = playerCameraTransform.forward;
        cameraForward.y = 0f;
        cameraForward = cameraForward.normalized;
        //create the rotation quaternion that is independent of vertical camera angle
        Quaternion rotationQuaternion = Quaternion.LookRotation(cameraForward);


        //rotate the vector based on player camera angle
        movementVector = rotationQuaternion * movementVector;

        //translate the player based on movementVector and moveSpeed independent of frame rate
        transform.position += movementVector * moveSpeed * sprintMultiplier * Time.deltaTime;
    }
}
