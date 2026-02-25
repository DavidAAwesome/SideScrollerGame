using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    public void OnPlayPressed()
    {
        SceneManager.LoadScene("UIScene");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}