using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    string LevelName;

    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
    }
}
