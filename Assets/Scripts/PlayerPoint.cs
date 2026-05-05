using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    private float currentPoint;
    public GameObject credits;
    public GameObject UI;
    public PlayerHealth playerHealth;
    public CharacterMovement characterMovement;

    private void Start()
    {
        // Set Player health to maximum on start
        currentPoint = 0;
    }

    public void AddPoint()
    {
        currentPoint += 1;
        CheckGameWin();
    }

    public void CheckGameWin()
    {
        if (currentPoint == 2)
        {
            // Pause all movement and malaise, turn off UI and activate credits
            characterMovement.enabled = false;
            playerHealth.malaiseRate = 0f;
            UI.SetActive(false);
            credits.SetActive(true);
        }
        ;
    }
}