using UnityEngine;

public class LoadAcrossScenes : MonoBehaviour
{
    public GameObject gameObject;

    void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }

}
