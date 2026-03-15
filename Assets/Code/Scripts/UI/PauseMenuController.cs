using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    [Header("Buttons")]
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private bool _isPaused;

    private void Awake()
    {
        if (_resumeButton != null) _resumeButton.onClick.AddListener(OnResumeClicked);
        if (_restartButton != null) _restartButton.onClick.AddListener(OnRestartClicked);
        if (_quitButton != null) _quitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnDestroy()
    {
        if (_resumeButton != null) _resumeButton.onClick.RemoveListener(OnResumeClicked);
        if (_restartButton != null) _restartButton.onClick.RemoveListener(OnRestartClicked);
        if (_quitButton != null) _quitButton.onClick.RemoveListener(OnQuitClicked);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            TogglePause();
    }

    private void TogglePause()
    {
        SetPaused(!_isPaused);
    }

    private void SetPaused(bool paused)
    {
        _isPaused = paused;
        _pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;

        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
    }

    private void OnResumeClicked()
    {
        SetPaused(false);
    }

    private void OnRestartClicked()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuitClicked()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }
}
