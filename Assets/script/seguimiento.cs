using UnityEngine;

public class seguimiento : MonoBehaviour
{
    public Transform player;             // Referencia al jugador (asignado en el editor)
    public float smoothSpeed = 0.125f;   // Suavizado del movimiento de la c�mara
    public Vector3 offset;              // Distancia entre la c�mara y el jugador (ajustar seg�n sea necesario)

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("No se ha asignado el jugador al CameraFollow.");
            return;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Calculamos la posici�n deseada para la c�mara con un desplazamiento
        Vector3 desiredPosition = player.position + offset;

        // Suavizamos el movimiento de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
