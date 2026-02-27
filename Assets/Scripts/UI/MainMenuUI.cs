using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public void OnPlayPressed()
    {
        SceneManager.LoadScene("MovingPlatform");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}