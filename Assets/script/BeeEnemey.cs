using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    public float detectionRadius = 5f; // Radio de b�squeda
    public Transform beeStinger; // Transform del aguij�n de la abeja (puede ser una parte del modelo o un objeto vac�o)
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
            PointAtPlayer(); // Mantener a la abeja girada hacia el jugador mientras est� en el trigger
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del trigger, puedes detener la rotaci�n
        if (other.CompareTag("Player"))
        {
            playerTransform = null; // Dejar de referenciar al jugador
        }
    }

    void PointAtPlayer()
    {
        if (playerTransform != null)
        {
            // Calculamos la direcci�n hacia el jugador
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0f; // Hacemos que la rotaci�n solo se haga en el plano horizontal (eje Y)

            // Si la direcci�n al jugador no es cero, hacemos que la abeja apunte hacia �l
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                // Rotaci�n suave hacia el jugador
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Puedes ajustar la velocidad aqu�
            }
        }
    }
}
