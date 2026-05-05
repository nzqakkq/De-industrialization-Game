using UnityEngine;
using TMPro;
public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        // Enable Interaction Text
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        // Disable Interaction Text
        interactionText.gameObject.SetActive(false);
    }

}