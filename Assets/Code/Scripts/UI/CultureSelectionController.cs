using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CultureSelectionController : MonoBehaviour
{
    [Header("Cards")]
    [SerializeField] private Button _minangkabauCard;
    [SerializeField] private Button _culture2Card;
    [SerializeField] private Button _culture3Card;

    [Header("Navigation")]
    [SerializeField] private Button _backButton;

    private void Awake()
    {
        if (_minangkabauCard != null) _minangkabauCard.onClick.AddListener(OnMinangkabauSelected);
        if (_backButton != null) _backButton.onClick.AddListener(OnBackClicked);

        // Coming soon cards are not interactable
        if (_culture2Card != null) _culture2Card.interactable = false;
        if (_culture3Card != null) _culture3Card.interactable = false;
    }

    private void OnDestroy()
    {
        if (_minangkabauCard != null) _minangkabauCard.onClick.RemoveListener(OnMinangkabauSelected);
        if (_backButton != null) _backButton.onClick.RemoveListener(OnBackClicked);
    }

    private void OnMinangkabauSelected()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnBackClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
