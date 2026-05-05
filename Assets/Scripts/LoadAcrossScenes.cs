using UnityEngine;

public class LoadAcrossScenes : MonoBehaviour
{
    void Awake() 
    {
        DontDestroyOnLoad(this);
    }

}
