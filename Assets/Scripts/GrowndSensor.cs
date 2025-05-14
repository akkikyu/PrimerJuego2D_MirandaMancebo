using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowndSensor : MonoBehaviour
{
  [Header("Static Ground")]
  private Rigidbody2D _rigidBodyGSensor;
  
  [Header("Oskar Jump")] 
  public bool isGrounded;
  public float jumpForce = 12;

  [Header("Double Jump")]
  public bool canDoubleJump = true;


  void Awake()
  {
    _rigidBodyGSensor = GetComponentInParent<Rigidbody2D>();
  }
    
  void OnTriggerEnter2D(Collider2D collider)
  {
    if(collider.gameObject.layer == 3)
    {
      isGrounded = true;
      canDoubleJump = true;
    }
  }

  void OnTriggerStay2D(Collider2D collider)
  {
    if(collider.gameObject.layer == 3)
    {
      isGrounded = true;
    }
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    if(collider.gameObject.layer == 3)
    {
      isGrounded = false;
    }
  }

}
