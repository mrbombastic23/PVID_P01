using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float detectionRadius = 5f; // Radio de búsqueda
    public Transform beeStinger; // Transform del aguijón de la abeja (puede ser una parte del modelo o un objeto vacío)
    private Transform playerTransform; // Transform del jugador

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;  // Guardamos la referencia del jugador
            PointAtPlayer(); // Gira la abeja hacia el jugador
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Verificar si el objeto con el que seguimos colisionando es el jugador
        if (other.CompareTag("Player"))
        {
            PointAtPlayer(); // Mantener a la abeja girada hacia el jugador mientras está en el trigger
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del trigger, puedes detener la rotación
        if (other.CompareTag("Player"))
        {
            playerTransform = null; // Dejar de referenciar al jugador
        }
    }

    void PointAtPlayer()
    {
        if (playerTransform != null)
        {
            // Calculamos la dirección hacia el jugador
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0f; // Hacemos que la rotación solo se haga en el plano horizontal (eje Y)

            // Si la dirección al jugador no es cero, hacemos que la abeja apunte hacia él
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                // Rotación suave hacia el jugador
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Puedes ajustar la velocidad aquí
            }
        }
    }
}
