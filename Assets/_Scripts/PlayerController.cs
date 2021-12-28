using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameManager GameManager;

    [SerializeField, Range(0f, 100f)]
    private float MaxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    private float MaxAcceleration = 10f;

    [SerializeField, Range(0f, 100f)]
    private float MaxAirAcceleration = 1f;

    [SerializeField, Range(0f, 10f)]
    private float JumpHeight = 2f;

    [SerializeField, Range(0, 5)]
    private int MaxAirJumps = 1;

    private Vector3 _velocity;
    private Vector3 _desiredVelocity;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    private bool _desiredJump;
    private bool _onGround;
    private int _jumpPhase;

    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = transform;
    }

    private void Update()
    {
        var playerInput = Vector2.zero;
        if (!StateManager.IsLocked)
        {
            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.y = Input.GetAxis("Vertical");
            playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        }

        _desiredVelocity = _playerTransform.right * playerInput.x + _playerTransform.forward * playerInput.y;
        _desiredVelocity *= MaxSpeed;
        _desiredJump |= Input.GetButtonDown("Jump");

        _animator.SetBool("Walking", _desiredVelocity.sqrMagnitude > 0);
    }

    private void FixedUpdate()
    {
        UpdateState();
        float acceleration = _onGround ? MaxAcceleration : MaxAirAcceleration;
        float maxSpeedChange = acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, maxSpeedChange);
        _velocity.z = Mathf.MoveTowards(_velocity.z, _desiredVelocity.z, maxSpeedChange);

        if (_desiredJump)
        {
            _desiredJump = false;
            Jump();
        }

        _rigidbody.velocity = _velocity;
        _onGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOverTrigger"))
        {
            GameManager.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void UpdateState()
    {
        _velocity = _rigidbody.velocity;
        if (_onGround)
        {
            _jumpPhase = 0;
        }
    }

    private void EvaluateCollision(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            var normal = collision.GetContact(i).normal;
            _onGround |= normal.y >= 0.9f;
        }
    }

    private void Jump()
    {
        if (_onGround || _jumpPhase < MaxAirJumps)
        {
            _jumpPhase++;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics.gravity.y * JumpHeight);
            if (_velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - _velocity.y, 0f);
            }

            _velocity.y += jumpSpeed;
        }
    }
}
