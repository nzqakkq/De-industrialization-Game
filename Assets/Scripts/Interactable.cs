using UnityEngine;

public class Interactable : MonoBehaviour
{
    public CharacterMovement movementScript;
    public MouseRotate mouseScript;
    public GameObject puzzleCanvas;
    public GameObject factorySmoke;
    public GameObject factoryBoxParticles;
    public PlayerPoint playerPoint;
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
        else if (tag == "Factory")
        {
            // Disable Factory Smoke and the box particles (since new scene is not loaded for this)
            factorySmoke.SetActive(false);
            factoryBoxParticles.SetActive(false);
            this.GetComponent<Interactable>().enabled = false;
            this.GetComponent<Outline>().enabled = false;

            playerPoint.AddPoint();
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
