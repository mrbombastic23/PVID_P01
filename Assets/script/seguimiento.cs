using UnityEngine;

public class seguimiento : MonoBehaviour
{
    public Transform player;             // Referencia al jugador (asignado en el editor)
    public float smoothSpeed = 0.125f;   // Suavizado del movimiento de la cámara
    public Vector3 offset;              // Distancia entre la cámara y el jugador (ajustar según sea necesario)

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

        // Calculamos la posición deseada para la cámara con un desplazamiento
        Vector3 desiredPosition = player.position + offset;

        // Suavizamos el movimiento de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posición de la cámara
        transform.position = smoothedPosition;
    }
}
