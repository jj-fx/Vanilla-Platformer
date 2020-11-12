using System.Collections;
using UnityEngine;

public class UIPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _title;

    public void StartGame()
    {
        StartCoroutine(WaitToLoadLevel(1f));
    }

    private IEnumerator WaitToLoadLevel(float time)
    {
        GetComponent<Animator>().SetTrigger("Play");
        _settingsButton.GetComponent<Animator>().SetTrigger("Play");
        _background.GetComponent<Animator>().SetTrigger("Hide");
        _title.GetComponent<Animator>().SetTrigger("Hide");

        yield return new WaitForSeconds(time);

        GameManager.Instance.GoToNextLevel();
    }
}
