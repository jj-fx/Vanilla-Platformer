using UnityEngine;

public class RunLoopAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        _audioSource.enabled = true;
    }

    public void StopAudio()
    {
        _audioSource.enabled = false;
    }
}
