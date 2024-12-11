using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA; // Primer punto de patrullaje
    [SerializeField] private Transform pointB; // Segundo punto de patrullaje
    [SerializeField] private bool moveHorizontally = true; // Determina si el movimiento es horizontal o vertical
    [SerializeField] private float speed = 10f; // Velocidad de movimiento
    [SerializeField] private float rotationSpeed = 200f; // Velocidad de rotación
    [SerializeField] private float rotationOffset = -90f; // Ajuste de rotación inicial del sprite

    private Vector3 targetPosition; 
    private bool movingToPointB = true; // Controla si el enemigo se dirige al punto B o A

    void Start()
    {
        if (movingToPointB)
            targetPosition = pointB.position;
        else
            targetPosition = pointA.position;
    }

    void Update()
    {
        MoveEnemy();

        // Cambiar dirección cuando el enemigo llega a un punto
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Si se mueve hacia el punto A, va al punto B, y viceversa
            if (movingToPointB)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }

            // Cambiar el sentido de movimiento
            movingToPointB = !movingToPointB;
        }
        
        RotateEnemy();
    }

    void MoveEnemy()
    {
        // Mover al enemigo solo en el eje seleccionado (horizontal o vertical)
        if (moveHorizontally)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    
    private void RotateEnemy()
    {
        // Obtener la dirección del movimiento (de la posición actual a la de destino)
        Vector3 direction = targetPosition - transform.position;

        if (direction != Vector3.zero)
        {
            // Calcular el ángulo hacia la dirección del movimiento
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset;

            // Rotar suavemente hacia la dirección del objetivo
            float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);

            // Aplicar la rotación
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    
}
