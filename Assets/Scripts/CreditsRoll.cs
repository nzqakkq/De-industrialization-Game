using UnityEngine;

public class CreditsRoll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    private void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
