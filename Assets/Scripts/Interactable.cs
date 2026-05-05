using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public CharacterMovement movementScript;
    public MouseRotate mouseScript;
    public GameObject puzzleCanvas;

    public float playerReach = 100f;
    Outline outline;
    public string message;

    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact(string tag)
    {
        if (tag == "Puzzle")
        {
            movementScript.enabled = false;
            mouseScript.enabled = false;

            //Enable the puzzle panel
            puzzleCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

}
