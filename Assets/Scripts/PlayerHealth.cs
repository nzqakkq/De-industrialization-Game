using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public float malaiseRate = 0.1f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        currentHealth -= malaiseRate * Time.deltaTime;
        healthBar.SetHealth(Mathf.Max(currentHealth, 0));

        if (currentHealth <= 0 || transform.position.y < 840)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }
}