using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlayerController _player;
    private GameStats _game;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private float _speed;
    Vector3 _startPos;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _game = FindObjectOfType<GameStats>();
        _minSpeed += _game.MultipleDifficult;
        _maxSpeed += _game.MultipleDifficult;
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _startPos = transform.position;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z), _speed*Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(_startPos.x*-1, transform.position.y, transform.position.z), _speed*Time.deltaTime);
        if (transform.position.x == _player.transform.position.x)
        {
            Destroy(GetComponent<Platform>());
            _game.ScoreUp(2);
        }
    }
}
