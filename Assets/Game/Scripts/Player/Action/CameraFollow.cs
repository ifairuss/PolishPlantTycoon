using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        _offset = _target.position - transform.position;
    }

    public void FollowCamera(float cameraSpeed)
    {
        transform.position = Vector3.Lerp(transform.position, _target.position - _offset, cameraSpeed * Time.deltaTime);
    }
}
