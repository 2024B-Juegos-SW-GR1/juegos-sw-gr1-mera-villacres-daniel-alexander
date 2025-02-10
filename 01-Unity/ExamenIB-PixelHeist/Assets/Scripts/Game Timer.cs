using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCronometro;
    [SerializeField] public float tiempo;
    [SerializeField] private GameObject tiempoTerminado;
    
    public Text messageText;

    private bool tiempoDetenido;
    private int tiempoMinutos, tiempoSegundos, tiempoDecimas;

    void Cronometro()
    {
        if (!tiempoDetenido)
        {
            tiempo -= Time.deltaTime;
        }

        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimas = Mathf.FloorToInt((tiempo % 1) * 100);

        textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoDecimas);

        if (tiempo <= 0)
        {
            tiempoDetenido = true;
            tiempo = 0;
            tiempoTerminado.SetActive(true);
            
            ShowMessage("¡Se ha terminado el tiempo!");
                
            Time.timeScale = 0; // Detener el tiempo del juego

            StartCoroutine(ReloadLevelAfterDelay(3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro();
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
