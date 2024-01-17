using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private int _maxJump;

    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody2D;
    private float _jump = 2.5f;
    private int _countJump;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(AnimatorData.Player.Speed, 0);
        float move = _speedMove * Time.deltaTime;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Run(move);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _countJump = 0;
        }
    }

    private void Run(float move)
    {
        _animator.SetFloat(AnimatorData.Player.Speed, move);

        if (Input.GetKey(KeyCode.D))
        {
            _sprite.flipX = false;
            transform.Translate(move, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _sprite.flipX = true;
            transform.Translate(-move, 0, 0);
        }
    }

    private void Jump()
    {
        if (_maxJump >= _countJump)
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jump), ForceMode2D.Impulse);
            _countJump++;
        }
    }
}