using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _direction;

    public Vector3 PCInput(float speed)
    {
        float directionX = Input.GetAxis("Vertical") * speed;
        float directionY = Input.GetAxis("Horizontal") * speed;

        Mathf.Clamp(speed, 0, speed);

        _direction = (transform.TransformDirection(Vector3.forward) * directionX) +
                      (transform.TransformDirection(Vector3.right) * directionY);

        return _direction * Time.deltaTime;
    }
}
