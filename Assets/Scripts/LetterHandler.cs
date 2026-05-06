using UnityEngine;
using UnityEngine.UI;

class LetterHandler : MonoBehaviour
{
    public Button emptyButton;

    public CharacterMovement movementScript;
    public MouseRotate mouseScript;
    public GameObject letterCanvas;
    private void exitLetter()
    {
        movementScript.enabled = true;
        mouseScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        letterCanvas.SetActive(false);
    }

    public void OnExitClick(Button pauseButton)
    {
        exitLetter();
    }
}