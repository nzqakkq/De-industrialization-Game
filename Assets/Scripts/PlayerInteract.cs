using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float playerReach = 100f;
    Interactable currentInteractable;

    void Update()
    {
        string tag = CheckInteraction();

        /*
            Check if interactable object exists, and 'I' key is pressed
        */
        if (Input.GetKeyDown(KeyCode.I) && currentInteractable != null)
        {
            currentInteractable.Interact(tag);
        }
    }

    string CheckInteraction()
    {
        // Detecting if the interactable object is being pointed to by the camera using "RayCasting"
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        /*
            In-built function that checks whether the ray is hitting anything; 
            playerReach is used to determine how far the player can interact from (by creating a ray that is only that long)
        */
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            // Checks if the object being hit has the "Puzzle" or "Factory" tag
            if (hit.collider.tag == "Puzzle" || hit.collider.tag == "Factory")
            {
                // Get interactable component on the object
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                /*
                    If 2 interactable objects are next to each other
                    to prevent the outline from displaying on the first interactable object when moving to the second
                    this check is made
                */
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                // Checks if the interactable object is enabled, if it is, it displays outline, otherwise it disables it
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }

            return hit.collider.tag;
        }
        else
        {
            DisableCurrentInteractable();
        }

        return "";
    }

    /*
        When an interactable object is detected, this method is called to:
            - Enable Outline
            - Display Interaction Message
    */
    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message ?? "");
    }

    /*
        When an interactable object is no longer being pointed at, this method is called to:
            - Disable Outline
            - Disable Display Interaction Message
    */
    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
