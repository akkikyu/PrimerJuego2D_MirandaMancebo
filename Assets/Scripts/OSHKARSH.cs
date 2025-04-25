using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSHKARSH : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int direction = 1;
    public Rigidbody2D rigidBody;
    private float inputHorizontal;
    private SpriteRenderer _spriteRenderer;
    public GrowndSensor _groundSensor;
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GrowndSensor>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
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


}
