using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    private int golpes = 0;
    private void OnCollisionEnter(Collision other)
    {
        golpes++;
        Debug.Log("El jugador ha golpeado " + golpes + " veces");
    }
}
