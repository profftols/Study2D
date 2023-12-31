using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoverEnemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private Player _player;

    private Animator _animator;
    private SpriteRenderer _sprite;
    private Transform[] _points;
    private int _currentPoint;
    private bool _isPlayerDetected;


    private void Start()
    {
        _points = new Transform[_path.childCount];
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator.SetFloat(AnimatorData.Enemy.Speed, _speed * Time.deltaTime);
        
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        CheckPlayer();

        if (_isPlayerDetected == false)
        {
            Patrolling();
        }
        else
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void CheckPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.position + _player.transform.position,
            _distance, _layer);

        if (hit)
        {
            _isPlayerDetected = true;
        }
        else
        {
            _isPlayerDetected = false;
        }
    }

    private void Patrolling()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (_currentPoint > 0)
        {
            _sprite.flipX = false;
        }
        else
        {
            _sprite.flipX = true;
        }
        
        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}