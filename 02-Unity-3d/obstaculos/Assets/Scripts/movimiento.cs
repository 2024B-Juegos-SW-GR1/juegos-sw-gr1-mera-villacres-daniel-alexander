using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 1.5f;
    void Start()
    {
        ImprimirInstrucciones();
    }
    void ImprimirInstrucciones()
    {
        Debug.Log("Bienvenido al Juego!");
        Debug.Log("Mueve usando las flechas o wasd");
        Debug.Log("No te metas dentro de los objetos!");
    }
    void MoverAlJugador()
    {
        float movimientoX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float movimientoY = 0f;
        float movimientoZ = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        transform.Translate(movimientoX, movimientoY, movimientoZ);
    }
    void Update()
    {
        MoverAlJugador();
    }
}
