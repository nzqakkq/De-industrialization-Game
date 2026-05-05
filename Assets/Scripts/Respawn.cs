using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public void OnRespawnClick(Button respawnButton)
    {
        //reload the scene upon clicking the respawn button
        foreach (var obj in FindObjectsOfType<GameObject>())
        {
            if (obj.scene.name == "DontDestroyOnLoad")
            {
                Destroy(obj);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
