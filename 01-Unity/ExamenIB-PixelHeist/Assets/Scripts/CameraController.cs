using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Referencia al jugador

    [SerializeField]
    private float minY = 0f; // Límite mínimo de la cámara

    [SerializeField]
    private float maxY = 161f; // Límite máximo de la cámara

    private void Update()
    {
        // Obtener la posición actual de la cámara
        Vector3 cameraPosition = transform.position;

        // Actualizar la posición Y de la cámara para que siga al jugador
        float targetY = player.position.y;

        // Limitar la posición Y al rango definido por minY y maxY
        targetY = Mathf.Clamp(targetY, minY, maxY);

        // Actualizar la posición de la cámara, solo en el eje Y
        transform.position = new Vector3(cameraPosition.x, targetY, cameraPosition.z);
    }
}
