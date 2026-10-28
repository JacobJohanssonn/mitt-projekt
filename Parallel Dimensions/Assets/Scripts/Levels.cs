using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void Level(string level)
    {
        PlayerPrefs.SetString("SceneToLoad", level);
        SceneManager.LoadScene("LoadingScreen");
    }
}
