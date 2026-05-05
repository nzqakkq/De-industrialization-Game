using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float targetHealth;
    [SerializeField] private float drainSpeed = 500f;

    private void Start()
    {
        // Set health bar UI to maximum
        targetHealth = slider.maxValue;
        slider.value = targetHealth;
    }

    private void Update()
    {
        // Animation to show health bar is draining instead of just jumping to new value
        if (slider.value > targetHealth)
        {
            slider.value -= drainSpeed * Time.deltaTime;

            if (slider.value < targetHealth)
                slider.value = targetHealth;
        }
    }

    // Method called by external scripts to set player health
    public void SetHealth(float health)
    {
        targetHealth = health;
    }
}