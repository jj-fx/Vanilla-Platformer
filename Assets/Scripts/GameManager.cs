using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _maxLives = 3;

    public int Lives { get; private set; }
    public GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            Lives = _maxLives;
            DontDestroyOnLoad(gameObject);
        }

    }

    internal static void KillPlayer()
    {
        SceneManager.LoadScene(0);
    }
}
