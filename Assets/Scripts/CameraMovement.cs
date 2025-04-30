using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Key")]
    public Transform playerTransform;
    [Tooltip("LLamar posición de Oskar")]

    public Vector3 offset;
    [Tooltip("Donde aparece la cámara (normalmente 0,0)")]

    public Vector2 maxPosition;
    [Tooltip("Posición limite arriba a la derecha")]

    public Vector3 minPosition;
    [Tooltip("Posición limite abajo izquierda")]

    public float interpolationRatio = 0.5f;
    [Tooltip("Delay que hay entre el personaje y la cámara")]

    void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; //para que la cámara sepa a quién perseguir
    }

    void FixedUpdate()
    {
        if(playerTransform == null) //si no hay player (que muera) no continua
        {
            return;
        }
        Vector3 desiredPosition = playerTransform.position + offset; //donde estemos todo el rato nos sigue, actualice todo el rato
        float clampX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x); //formula matemática que decide posición min y max de cámara de L y R
        float clampY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y); //formula matemática que decide posición min y max de cámara de arriba y abajo
        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z); //formula que crea un limite en X e Y
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio); //finaliza los limites de la cámara
        transform.position = lerpedPosition; //posición cámara esté siempre dentro de los limites       
    }
}
