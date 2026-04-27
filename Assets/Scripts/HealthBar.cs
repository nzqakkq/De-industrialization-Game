using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private float targetHealth;
    [SerializeField] private float drainSpeed = 500f;

    private void Start()
    {
        targetHealth = slider.maxValue;
        slider.value = targetHealth;
    }

    private void Update()
    {
        if (slider.value > targetHealth)
        {
            slider.value -= drainSpeed * Time.deltaTime;
            
            if (slider.value < targetHealth)
                slider.value = targetHealth;
        }
    }

    public void SetHealth(float health)
    {
        targetHealth = health;
    }
}