using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Key")]
    public Transform playerTransform;
    [Tooltip("")]

    public Vector3 offset;
    [Tooltip("")]

    public Vector2 maxPosition;
    [Tooltip("")]

    public Vector3 minPosition;
    [Tooltip("")]

    public float interpolationRatio = 0.5f;
    [Tooltip("")]

    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; //para que la cámara sepa a quién perseguir
    }

    void FixedUpdate()
    {
        if(playerTransform == null)
        {
            return;
        }
        Vector3 desiredPosition = playerTransform.position + offset;

        float clampX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        float clampY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);

        transform.position = lerpedPosition;
        
    }
}
