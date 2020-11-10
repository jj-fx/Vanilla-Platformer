using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int _maxLives = 3;
    public int Lives { get; private set; }
    public event Action<int> OnLivesChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Lives = _maxLives;
        }

    }

    internal void KillPlayer()
    {
        Lives--;
        Debug.Log(Lives);
        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if (Lives <= 0)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Lives = _maxLives;
        SceneManager.LoadScene(0);
    }
}
