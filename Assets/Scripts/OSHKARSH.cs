using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSHKARSH : MonoBehaviour
{
    [Header("Physics, RigidBody, GroundSensor, BoxCollider")]
    [SerializeField] private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    public GrowndSensor _groundSensor;
    private BoxCollider2D _boxCollider;
    private bool _alreadyPlaying = false;

    [Header("Animator")]
    [SerializeField] private Animator _animator;

    [Header("Key")]
    [SerializeField] private float inputHorizontal;

    [Header("Run")]
    public float playerSpeed = 5;
    public int direction = 1;
    [SerializeField] private AudioSource _runSound;
    public AudioClip runFX;

    [Header("Jump")]
    public float jumpForce = 8;
    private AudioSource _jumpSound;
    public AudioClip jumpFX;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _particleSystem;
    private Transform _particleTransform;
    private Vector3 _particlePosition;

    /*[Header("Dash")] //cambiar a nombre Oshkar y terminar de poner el dash
    [SerializeField] private float _dashForce = 20;
    [SerializeField] private float _dashDuration = 0.5f;
    [SerializeField] private float _dashCoolDown = 1;
    private bool _canDash = true;
    private bool _isDashing = false;
    */


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GrowndSensor>();
        _animator = GetComponent<Animator>();
        _jumpSound = GetComponent<AudioSource>();
        _jumpSound.clip = jumpFX;
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _particleTransform = _particleSystem.transform;
        _particlePosition = _particleTransform.localPosition;

    }

    void Start()
    {
        _runSound.loop = true;
        _runSound.clip = runFX;
    }
    
    void Update()
    {
        Jump();
        PlayerStepsSounds();
    }

    void FixedUpdate()
    {
        Movement(); 
    }

    void Movement()
    {
        _rigidBody.velocity = new  Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, _rigidBody.velocity.y);

        if(inputHorizontal > 0)
        {
           transform.rotation = Quaternion.Euler(0, 0, 0);
           _animator.SetBool("IsRunning", true); 
        }

      else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);       
        }
      else
        {
            _animator.SetBool("IsRunning", false);
        }

        inputHorizontal = Input.GetAxisRaw("Horizontal");
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded == true)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsJumping", true);
            _jumpSound.PlayOneShot(jumpFX);
        }
        _animator.SetBool("IsJumping", !_groundSensor.isGrounded);
    }

    void PlayerStepsSounds()
    {
        if(_groundSensor.isGrounded && Input.GetAxisRaw("Horizontal") != 0 && !_alreadyPlaying)
        {
            _particleTransform.SetParent(gameObject.transform);
            _particleTransform.localPosition = _particlePosition;
            _particleTransform.rotation = transform.rotation;
            _runSound.Play();
            _particleSystem.Play();
            _alreadyPlaying = true;
        }
        else if(!_groundSensor.isGrounded || Input.GetAxisRaw("Horizontal") == 0)
        {
            _particleTransform.SetParent(null); //cuando salte dejará de ser hijo nadie y se quitará
            _runSound.Stop();
            _particleSystem.Stop();
            _alreadyPlaying = false;
        }
    }

}
