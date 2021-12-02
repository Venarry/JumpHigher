using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private bool _isStarted;
    private bool _isDie;
    Vector3 _currentPosition;
    Vector3 _startPos;
    private void Start()
    {
        //SpawnPlatform();
        _startPos = _spawnPoint.transform.position;
        
    }

    public void GameIsStarted()
    {
        StartCoroutine(Spawner());
    }
    public void PlayerIsDie()
    {
        _isDie = true;
    }

    public void SpawnPlatform()
    {
        /*if (_isStarted && !_isDie)
        {         
            Instantiate(_platforms[Random.Range(0,_platforms.Length)], _spawnPoint.position, Quaternion.identity);
            _currentPosition.y += 0.5f;
            if (Random.Range(0, 2) == 0) _currentPosition.x = 15;
            else _currentPosition.x = -15;
            _spawnPoint.position = new Vector3(_currentPosition.x, _currentPosition.y, 0);
        }*/
    }
    public IEnumerator Spawner()
    {
        if (!_isDie)
        {
            int i = Random.Range(0, _platforms.Length);
            if (Random.Range(0, 2) == 0) _currentPosition.x = _startPos.x;
            else _currentPosition.x = -_startPos.x;
            Instantiate(_platforms[i], _spawnPoint.position, Quaternion.identity);
            if (i == 0)
            {
                _currentPosition.y += 0.5f;
            }
            else _currentPosition.y += 1;


            _spawnPoint.position = new Vector3(_currentPosition.x, _currentPosition.y, 0);
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            StartCoroutine(Spawner());
        }
    }
}
