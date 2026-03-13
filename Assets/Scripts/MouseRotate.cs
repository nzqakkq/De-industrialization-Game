using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private float clampedRotation = 0f;
    public Transform playerBody;
    // Start is called before the first frame update
    private void Start()
    {
        //so the cursor does not move during gameplay
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        //get bearings for mouse movement at each frame
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //add the y change to the rotation, negative because axes are inverted for some reason
        clampedRotation -= mouseY;
        //this hard sets the mouseY value between angles so the player can't rotate too far back
        clampedRotation = Mathf.Clamp(clampedRotation, -90f, 90f);

        //rotates the camera vertically relative to the position of the player
        transform.localRotation = Quaternion.Euler(clampedRotation, 0f, 0f);

        //rotates the player horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
