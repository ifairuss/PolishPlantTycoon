using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _playerCharacterController;
    private Transform _playerRotation;

    private float _smoothVelosity;

    public void Initialize()
    {
        _playerCharacterController = GetComponent<CharacterController>();
        _playerRotation = GameObject.FindWithTag("PlayerSkin").GetComponent<Transform>();
    }

    public void PlayerMove(Vector3 direction, float gravity)
    {
        if (!_playerCharacterController.isGrounded) { direction.y -= gravity * Time.deltaTime; }

        _playerCharacterController.Move(direction);

        if (Mathf.Abs(direction.x) == 0 && Mathf.Abs(direction.z) == 0) { return; }

        float playerRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(_playerRotation.eulerAngles.y, playerRotation, ref _smoothVelosity, 0.1f);
        _playerRotation.rotation = Quaternion.Euler(0, angle, 0);
    }


}
