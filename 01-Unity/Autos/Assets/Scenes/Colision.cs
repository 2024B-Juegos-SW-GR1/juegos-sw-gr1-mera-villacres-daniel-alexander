using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private bool hasPackage;
    [SerializeField] private float destroyDelay = 0.5f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEEE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");
        if (other.tag == "Paquete" && hasPackage == false)
        {
            Debug.Log("Paquete recogido");
            hasPackage = true;
            spriteRenderer.color = Color.red;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Cliente" && hasPackage == true)
        {
            Debug.Log("Paquete entregado");
            hasPackage = false;
            spriteRenderer.color = Color.green;
        }
    }
}
