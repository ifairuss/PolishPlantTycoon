using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator _playerAnimator;

    public void Initialize()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void RunAnimation(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > 0.01f || Mathf.Abs(direction.z) > 0.01f)
        {
            _playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            _playerAnimator.SetBool("isRunning", false);
        }
    }
}
