using UnityEngine;

public class limite : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en contacto es un personaje u otro objeto específico
        // Aquí puedes comprobar el tag o el nombre del objeto si lo deseas, pero por ahora destruimos todo
        if (other.CompareTag("Player") || other.CompareTag("Enemigo") || other.CompareTag("Object"))
        {
            Destroy(other.gameObject);  // Destruye el objeto que colisiona
        }
    }
}
