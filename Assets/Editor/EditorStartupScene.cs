using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class EditorStartupScene
{
    static EditorStartupScene()
    {
        string scenePath = "Assets/Scenes/Main.unity";
        if (EditorSceneManager.GetActiveScene().path != scenePath)
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}
