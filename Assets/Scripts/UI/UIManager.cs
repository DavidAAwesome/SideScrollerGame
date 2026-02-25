using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public enum UIScreen
    {
        HUD,
        Pause,
        Death
    }

    [Header("Panels")]
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;

    public UIScreen CurrentScreen { get; private set; }
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        Time.timeScale = 1f;
        Debug.Log($"TimeScale = {Time.timeScale}" );
        IsPaused = false;
    }
    

    public void Show(UIScreen screen)
    {
        CurrentScreen = screen;

        hudPanel.SetActive(screen == UIScreen.HUD);
        pausePanel.SetActive(screen == UIScreen.Pause);
        deathPanel.SetActive(screen == UIScreen.Death);

        // Pausing rules
        if (screen == UIScreen.Pause || screen == UIScreen.Death)
            SetPaused(true);
        else
            SetPaused(false);
    }
    
    

    public void TogglePause()
    {
        // Don’t pause in main menu or death screen
        if (CurrentScreen == UIScreen.Death)
            return;

        if (IsPaused) Show(UIScreen.HUD);
        else Show(UIScreen.Pause);
    }

    public void SetPaused(bool paused)
    {
        IsPaused = paused;
        Time.timeScale = paused ? 0f : 1f;
        Debug.Log($"TimeScale = {Time.timeScale}" );
    }

    void OnPause()
    {
        UIManager.Instance.TogglePause();
    }
    
    // ----- Button hooks -----
    public void OnPausePressed()
    {
        UIManager.Instance.TogglePause();
    }
    
    public void OnResumePressed()
    {
        Show(UIScreen.HUD);
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        Debug.Log($"TimeScale = {Time.timeScale}" );
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1f;
        Debug.Log($"TimeScale = {Time.timeScale}" );
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowDeathScreen()
    {
        Show(UIScreen.Death);
    }
}