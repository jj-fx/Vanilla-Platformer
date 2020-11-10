using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI _tmPro;

    private void Awake()
    {
        _tmPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        _tmPro.text = GameManager.Instance.Lives.ToString();
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        _tmPro.text = livesRemaining.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= HandleOnLivesChanged;
    }
}
