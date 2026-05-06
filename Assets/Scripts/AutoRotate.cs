using UnityEngine;

class AutoRotate : MonoBehaviour
{

    public float rotateSpeed = 100f;
    public float bobHeight = 0.3f;
    public float bobSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        // Store original position
        startPos = transform.position;
    }
    void Update()
    {
        // Spin Object
        transform.Rotate(0f, 100f * Time.deltaTime, 0f, Space.Self);

        // Bob up and down using sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}