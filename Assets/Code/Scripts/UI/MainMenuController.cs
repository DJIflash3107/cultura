using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        if (_startButton != null) _startButton.onClick.AddListener(OnStartClicked);
        if (_exitButton != null) _exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    {
        if (_startButton != null) _startButton.onClick.RemoveListener(OnStartClicked);
        if (_exitButton != null) _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnStartClicked()
    {
        SceneManager.LoadScene("CultureSelection");
    }

    private void OnExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
