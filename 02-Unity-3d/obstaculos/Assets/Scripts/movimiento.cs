using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidad = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float movimientoY = 0f;
        float movimientoZ = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        transform.Translate(movimientoX, movimientoY, movimientoZ);
    }
}
