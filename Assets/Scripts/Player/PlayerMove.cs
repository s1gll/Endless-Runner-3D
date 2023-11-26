using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private  float _directionSpeed = 4f;
    [SerializeField] private  float _jumpForce = 5f;
    [SerializeField] private AudioSource _gameOverSound;

    [SerializeField] private  Animator _anim;

    private bool _canMove = false;
    public bool IsGameOver{get; private set;}=false;

    private CharacterController _controller;
    private float _verticalVelocity = 0f; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        GameEvents.OnCountdownFinished += EnableMovement;
    }

    private void Update()
    {
        if (_canMove)
        {
            _anim.SetBool("isRuning", true);

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 moveDirection = Vector3.right * horizontalInput;

            if (CanMoveHorizontally(moveDirection))
            {
                MoveHorizontally(moveDirection);
            }
            else
            {
                MoveForward();
            }

            ApplyGravity();

            if (Input.GetButtonDown("Jump") && _controller.isGrounded)
            {
                Jump();
            }
        }
    }

    private bool CanMoveHorizontally(Vector3 moveDirection)
    {
        Vector3 nextPosition = transform.position + moveDirection * Time.deltaTime * _directionSpeed;

        return nextPosition.x >= LevelBoundary.LeftSide && nextPosition.x <= LevelBoundary.RightSide;
    }

    private void MoveForward()
    {
        Vector3 forwardDirection = Vector3.forward;
        _controller.Move(forwardDirection * Time.deltaTime * _moveSpeed);
    }

    private void MoveHorizontally(Vector3 moveDirection)
    {
        _controller.Move(moveDirection * Time.deltaTime * _directionSpeed + Vector3.forward * Time.deltaTime * _moveSpeed);
    }

    private void ApplyGravity()
    {
        if (!_controller.isGrounded)
        {
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            _verticalVelocity = 0f;
        }

        Vector3 gravityVector = Vector3.up * _verticalVelocity;
        _controller.Move(gravityVector * Time.deltaTime);
    }

    private void Jump()
    {
        _anim.SetBool("IsJumping", true);
        _verticalVelocity = _jumpForce;
    }

    private void EnableMovement()
    {
        _canMove = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            _canMove = false;
            _gameOverSound.Play();
            _anim.SetBool("isRuning", false);
            _anim.SetBool("IsHited", true);
            IsGameOver=true;
        }
        else if (hit.gameObject.CompareTag("Ground"))
        {
            _anim.SetBool("IsJumping", false);
        }
    }
}
