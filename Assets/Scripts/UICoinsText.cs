using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI _tmPro;

    private void Awake()
    {
        _tmPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
        _tmPro.text = GameManager.Instance.Coins.ToString();
    }

    private void HandleOnCoinsChanged(int coins)
    {
        _tmPro.text = coins.ToString();
    }
}
