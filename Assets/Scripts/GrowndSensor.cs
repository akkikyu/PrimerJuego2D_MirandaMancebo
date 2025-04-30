using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowndSensor : MonoBehaviour
{
  [Header("Static Ground")]
  private Rigidbody2D _rigidBodyGSensor;
  
  [Header("Oshkarsh Jump")] 
  public bool isGrounded;
  public float jumpForce = 12;


  void Awake()
  {
    _rigidBodyGSensor = GetComponentInParent<Rigidbody2D>();
  }
    
  void OnTriggerEnter2D(Collider2D collider)
  {
    if(collider.gameObject.layer == 3)
    {
      isGrounded = true;
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
