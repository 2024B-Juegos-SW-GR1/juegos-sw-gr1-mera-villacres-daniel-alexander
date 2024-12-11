using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private Transform lanternTransform; 
    public Text messageText;

    private Light2D lanternLight;
    
    private void Start()
    {
        lanternLight = lanternTransform.GetComponentInChildren<Light2D>();
    }
    
    private void Update()
    {
        if (IsPlayerInRange())
        {
            AlertPlayerFound();
        }
    }

    private bool IsPlayerInRange()
    {
        if (lanternLight == null) return false; 

        // Comprobar si el jugador está dentro del rango de la linterna
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verificar si está dentro del rango de la linterna
        if (distanceToPlayer <= lanternLight.pointLightInnerRadius)  // Usamos el radio interior de la luz
        {
            // Detectar si el jugador está dentro del cono de luz de la linterna
            Vector2 directionToPlayer = (player.position - lanternTransform.position).normalized;

            // Obtener la dirección en la que la linterna está apuntando, tomando en cuenta su rotación
            Vector2 lanternDirection = lanternTransform.up; 

            // Calcular el ángulo entre la dirección de la linterna y el jugador
            float angle = Vector2.Angle(lanternDirection, directionToPlayer); 

            // Definir el rango de detección como un ángulo de 45 grados (esto se puede ajustar)
            float detectionAngle = 45f;

            if (angle <= detectionAngle)
            {
                // Verificar si el jugador está en la sombra usando un Raycast
                RaycastHit2D hit = Physics2D.Raycast(lanternTransform.position, directionToPlayer, distanceToPlayer);

                if (hit.collider != null && hit.collider.CompareTag("scenography"))
                {
                    return false; 
                }
                return true;
            }
        }

        return false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void AlertPlayerFound()
    {
        ShowMessage("¡Te han encontrado!");
        
        Time.timeScale = 0; // Detener el tiempo del juego

        StartCoroutine(ReloadLevelAfterDelay(3f));
    }
    
    private void ShowMessage(string message)
    {
        messageText.text = message;
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
