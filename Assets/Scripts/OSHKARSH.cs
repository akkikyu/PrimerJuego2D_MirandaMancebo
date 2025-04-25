using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSHKARSH : MonoBehaviour
{
    [Header("Physics, RigidBody, GroundSensor, BoxCollider")]
    public Rigidbody2D rigidBody;
    private SpriteRenderer _spriteRenderer;
    public GrowndSensor _groundSensor;
    private BoxCollider2D _boxCollider;

    [Header("Key")]
    [SerializeField]private float inputHorizontal;

    [Header("Run")]
    public float playerSpeed = 5;
    public int direction = 1;

    [Header("Jump")]
    public float jumpForce = 25;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GrowndSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded == true)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = new  Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
    }

    void Movement()
    {
        if(inputHorizontal > 0)
        {
           transform.rotation = Quaternion.Euler(0, 0, 0);
            //_animator.SetBool("IsRunning", true); 
        }

      else if(inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //_animator.SetBool("IsRunning", true);       
        }
      /*else
        {
            _animator.SetBool("IsRunning", false);
        }
        */
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
