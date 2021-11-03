using UnityEngine;

public class NameFollow : MonoBehaviour
{
    [SerializeField] bool _followPlayerUsername = true;
    Transform _camera;

    void Start()
    {
        _camera = Camera.main.transform;
    }

    void Update()
    {
        if (_followPlayerUsername)
        {
            transform.LookAt(transform.position + _camera.rotation * Vector3.forward, _camera.rotation * Vector3.up);
        }
    }
}
