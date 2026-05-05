using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public float malaiseRate = 0.1f;
    private float currentHealth;

    private void Start()
    {
        // Set Player health to maximum on start
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        // Malaise Rate: The player looses health over time as the game progress
        currentHealth -= malaiseRate * Time.deltaTime;
        healthBar.SetHealth(Mathf.Max(currentHealth, 0));

        // Check if player health is less than 0, or if the player entered water (y < 840) and kill the player
        if (currentHealth <= 0 || transform.position.y < 840)
        {
            KillPlayer();
        }
    }


    public void KillPlayer()
    {
        // Sets current health to 0
        currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }
}