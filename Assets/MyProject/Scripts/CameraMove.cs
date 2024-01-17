using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _playerTarget;

    private float _distance = 0;
    private float _maxDistance = 17.73f;

    private void LateUpdate()
    {
        if (_playerTarget.transform.position.x >= transform.position.x && transform.position.x <= _maxDistance)
        {
            transform.Translate(_playerTarget.transform.position.x * Time.deltaTime, 0, 0);
        }

        if (_playerTarget.transform.position.x >= _distance && _playerTarget.transform.position.x <= transform.position.x)
        {
            transform.Translate(-_playerTarget.transform.position.x * Time.deltaTime, 0, 0);

            if (_playerTarget.transform.position.x == _distance)
            {
                transform.Translate(_playerTarget.transform.position.x, 0, 0);
            }
        }
    }
}