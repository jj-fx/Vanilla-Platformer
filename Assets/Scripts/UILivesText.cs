using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI _tmPro;

    private void Awake()
    {
        _tmPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _tmPro.text = GameManager.Instance.Lives.ToString();
    }
}
