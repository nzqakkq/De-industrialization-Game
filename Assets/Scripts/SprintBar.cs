using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    public Slider slider;
    public CharacterMovement characterMovement;
    private void Update()
    {
        float timeSinceDash = characterMovement.timeSinceDash;
        float dashCooldown = characterMovement.dashCooldown;

        slider.value = Mathf.Min((timeSinceDash / dashCooldown) * 100f, 100f);
    }
}
