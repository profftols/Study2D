using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    
    private Animator _animator;
    private SpriteRenderer _sprite;
    private float _jump = 7;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(AnimatorData.Player.Speed, 0);
        float move = _speedMove * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetFloat(AnimatorData.Player.Speed, move);
            _sprite.flipX = false;
            transform.Translate(move, 0 , 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat(AnimatorData.Player.Speed, move);
            _sprite.flipX = true;
            transform.Translate(-move, 0 , 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, _jump*Time.deltaTime, 0);
        }
    }
}
