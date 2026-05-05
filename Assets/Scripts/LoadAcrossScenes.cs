using UnityEngine;

public class LoadAcrossScenes : MonoBehaviour
{
    private static LoadAcrossScenes instance;

    void Awake() 
    {
        DontDestroyOnLoad(this);
    }

}
