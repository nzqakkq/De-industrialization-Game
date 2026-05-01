using UnityEngine;

public class PuzzleInteract : MonoBehaviour
{
    public CharacterMovement movementScript;
    public MouseRotate mouseScript;
    public GameObject puzzleCanvas;

    private void OnMouseDown()
    {
        //Disable scripts for mouse motion and keyboard movement
        movementScript.enabled = false;
        mouseScript.enabled = false;

        //Enable the puzzle panel
        puzzleCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
}
