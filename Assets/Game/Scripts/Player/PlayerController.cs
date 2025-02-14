using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [Header("Player controller preferences")]
    [SerializeField] private bool _canMove = true;

    [Header("Player speed preferences")]
    [SerializeField] private float _playerSpeed;

    [Header("Player other preferences")]
    [SerializeField] private float _gravity;

    [Header("Camera follow preferences")]
    [SerializeField] private float _cameraFollowSpeed;

    private Movement _playerMovement;
    private PlayerInput _playerInput;
    private CameraFollow _playerCamera;
    private AnimationPlayer _playerAnimationPlayer;
    private TriggerBox _playerTriggerBox;

    private void Start()
    {
        InitializedComponents();
    }

    private void InitializedComponents()
    {
        _playerMovement = GetComponent<Movement>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimationPlayer = GetComponent<AnimationPlayer>();
        _playerTriggerBox = GetComponent<TriggerBox>();
        _playerCamera = GameObject.FindWithTag("PlayerCamera").GetComponent<CameraFollow>();

        _playerMovement.Initialize();
        _playerAnimationPlayer.Initialize();
        _playerTriggerBox.Initialized();
    }

    private void Update()
    {
        AllPlayerController();
    }

    private void AllPlayerController()
    {
        if (_canMove) {
            PlayerPCInputMove();
            PlayerCameraFollow();
            PlayerAnimation();
        }
    }

    private void PlayerPCInputMove()
    {
        _playerMovement.PlayerMove(_playerInput.PCInput(_playerSpeed), _gravity);
    }

    private void PlayerCameraFollow()
    {
        _playerCamera.FollowCamera(_cameraFollowSpeed);
    }

    private void PlayerAnimation()
    {
        _playerAnimationPlayer.RunAnimation(_playerInput.PCInput(_playerSpeed)); ;
    }
}
