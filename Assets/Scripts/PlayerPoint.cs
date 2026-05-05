using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    private float currentPoint;

    private void Start()
    {
        // Set Player health to maximum on start
        currentPoint = 0;
    }

    public void AddPoint()
    {
        currentPoint += 1;
        CheckGameWin();
    }

    public void CheckGameWin()
    {
        if (currentPoint == 2)
        {
            // handle win here
        }
        ;
    }
}