using UnityEngine;

public class Background : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void LateUpdate()
    {
        transform.position = _camera.transform.position * 0.15f;
    }
}
