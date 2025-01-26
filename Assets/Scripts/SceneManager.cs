using UnityEngine;


/// <summary>
/// A utility class to load a scene.
/// </summary>
public class SceneManager : MonoBehaviour
{
    [SerializeField]
    string LevelName = "Demo";

    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
    }
}
