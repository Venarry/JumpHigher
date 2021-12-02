using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Platform _platform;
    private Platform[] _newPlatforms;
    private GameStats _game;
    private Animator _animator;

    private bool _isDie;
    private float _fallSpeed;

    [SerializeField] private float _fallForce;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGround;
    [SerializeField] private UnityEvent _die;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private AudioSource _jump;
    [SerializeField] private AudioSource _land;


    private void Start()
    {
        //Time.timeScale = 1.1f;
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        Invoke("SoundJumpStarted", 0.1f);
    }

    private void SoundJumpStarted()
    {
        _land.gameObject.SetActive(true);
    }

    public void Jump()
    {
        if (_isGround && !_isDie)
        {
            _jump.Play();
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _fallSpeed = _jumpForce;
            _animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        if (!_isGround && !_isDie)
        {
            _fallSpeed -= _fallForce * Time.deltaTime;
            _rigidBody.velocity = new Vector3(0, _fallSpeed, 0);
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    public void GameStarted()
    {
        _game = FindObjectOfType<GameStats>();
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGround = true;
        if (collision.gameObject.TryGetComponent(out _platform))
        {
            Destroy(_platform);
            _game.ScoreUp(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _land.Play();
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other.CompareTag("Die"))
        {
            _rigidBody.freezeRotation = false;
            _rigidBody.AddForce(new Vector3(transform.position.x - other.transform.position.x, 0.2f, 0) * 6, ForceMode.Impulse);
            _newPlatforms = FindObjectsOfType<Platform>();
            for (int i=0;i<_newPlatforms.Length;i++)
                Destroy(_newPlatforms[i]);
            _die.Invoke();
            _restartButton.SetActive(true);
            _isDie = true;
        }
    }

    
}
