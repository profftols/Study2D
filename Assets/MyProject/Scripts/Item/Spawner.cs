using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _points;
    [SerializeField] private Pizza _pizzaSpawn;

    private Transform[] _paths;
    private int _currentPoint;
    private float _waitTime = 3;
    
    private void Start()
    {
        _paths = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
        {
            _paths[i] = _points.GetChild(i);
        }

        StartCoroutine(Spawning());
    }
    
    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_waitTime);
        
        while (_currentPoint < _points.childCount)
        {
            var path = _paths[_currentPoint];
            _currentPoint++;

            Instantiate(_pizzaSpawn, path);

            if (_paths.Length == _currentPoint)
            {
                StopCoroutine(Spawning());
            }
            
            yield return wait;
        }
    }
}
