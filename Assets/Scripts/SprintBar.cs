using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Slider slider;
    public CharacterMovement characterMovement;
    private void Update()
    {
        // Get the time since dash
        float timeSinceDash = characterMovement.timeSinceDash;

        // Get the dash cooldown
        float dashCooldown = characterMovement.dashCooldown;

        // Update the slider according to the dash cooldown
        slider.value = Mathf.Min((timeSinceDash / dashCooldown) * 100f, 100f);
    }
}
