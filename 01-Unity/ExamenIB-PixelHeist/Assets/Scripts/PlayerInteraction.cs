using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    private bool objetivoConseguido = false; // Indica si el objetivo fue conseguido.
    public Text messageText;
    
    [SerializeField] private float tiempoAdicional;

    private bool hasLlave = false;

    private void Start()
    {
        ShowMessage("Mision: Roba la caja fuerte y sal sin ser descubierto.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el jugador toca un objeto con la etiqueta "objetivo".
        if (collision.gameObject.CompareTag("objetivo"))
        {
            objetivoConseguido = true;
            ShowMessage("¡Objetivo conseguido vuelve a la salida!");
            Destroy(collision.gameObject); 
        }

        // Verifica si el jugador toca la salida.
        if (collision.gameObject.CompareTag("salida"))
        {
            if (objetivoConseguido)
            {
                ShowMessage("¡Ganaste el juego!");
                
                Time.timeScale = 0; // Detener el tiempo del juego

                StartCoroutine(ReloadLevelAfterDelay(3f));
            }
            else
            {
                ShowMessage("No puedes salir sin completar el objetivo.");
            }
        }
        
        // Verifica si el jugador tiene la llave para abrir la puerta
        if (collision.gameObject.CompareTag("llave"))
        {
            hasLlave = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("puerta") && hasLlave)
        {
            collision.gameObject.SetActive(false);
        }
        
        // Verificar si el jugador recoge un reloj
        if (collision.gameObject.CompareTag("reloj")) 
        {
            collision.gameObject.SetActive(false);
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
            {
                timer.tiempo += tiempoAdicional;
            }
        }
    }
    
    private void ShowMessage(string message)
    {
        messageText.text = message; 
        Invoke("ClearMessage", 3f);
    }
    
    private void ClearMessage()
    {
        messageText.text = ""; 
    }
    
    private IEnumerator ReloadLevelAfterDelay(float delay)
    {
        // Espera por el tiempo especificado
        yield return new WaitForSecondsRealtime(delay);
        
        Time.timeScale = 1; // Restaurar el tiempo a su valor normal

        // Reiniciar el nivel (escena actual)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}