using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Pizza _pizzaSpawn;

    private Transform[] _paths;
    private int _currentPoint;
    private float _waitTime = 3;
    
    private void Start()
    {
        _paths = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _paths[i] = _point.GetChild(i);
        }

        StartCoroutine(SpawnTimer());
    }
    
    private IEnumerator SpawnTimer()
    {
        var wait = new WaitForSeconds(_waitTime);
        
        while (_currentPoint < _point.childCount)
        {
            var path = _paths[_currentPoint];
            _currentPoint++;

            Instantiate(_pizzaSpawn, path);

            if (_paths.Length == _currentPoint)
            {
                StopCoroutine(SpawnTimer());
            }
            
            yield return wait;
        }
    }
}
