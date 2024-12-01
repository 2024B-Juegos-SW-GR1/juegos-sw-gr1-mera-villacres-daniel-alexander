using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEEE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");
        if (other.tag == "Paquete")
        {
            Debug.Log("Paquete recogido");
        }
        if (other.tag == "Cliente")
        {
            Debug.Log("Paquete entregado");
        }
    }
}
