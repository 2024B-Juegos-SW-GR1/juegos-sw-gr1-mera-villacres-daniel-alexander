using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // Velocidad de movimiento del personaje

    [SerializeField]
    private float rotationSpeed = 200f; // Velocidad de rotación del personaje

    [SerializeField]
    private float rotationOffset = -90f; // Ajuste de rotación inicial del sprite (por ejemplo, si apunta al eje X en lugar de Y)

    private Vector2 movement; 

    private void Update()
    {
        // Capturar la entrada del teclado
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");  

        // Normalizar el movimiento para evitar velocidades diagonales más rápidas
        movement = movement.normalized;

        MoveCharacter();

        RotateCharacter();
    }

    private void MoveCharacter()
    {
        transform.Translate(movement * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void RotateCharacter()
    {
        if (movement != Vector2.zero)
        {
            // Calcular el ángulo hacia la dirección del movimiento
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg + rotationOffset;
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);

            // Aplicar la rotación
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}