using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de Unity (1 referencia de recurso) 0 referencias
public class Recoleccion : MonoBehaviour
{
    // Start is called before the first frame update

    // Mensaje de Unity 1 objetos
    private void OnTriggerEnter2D(Collider2D collision) // M�todo para saber si el objeto asignado con el script est� colisionando con otro objeto
    {
        if (collision.transform.CompareTag("Player")) // Si colisi�n valida si el objeto colisionando tiene un tag con el nombre "Player"
        {
            GetComponent<SpriteRenderer>().enabled = false; // Esto sirve para obtener del objeto asignado con el script extrayendo el componente en este caso SpriteRenderer
                                                            // dentro de su atributo enabled colocar "false", para hacer que invisible el objeto.
            gameObject.transform.GetChild(0).gameObject.SetActive(true); // Esta l�nea de c�digo se utiliza para activar el primer hijo del objeto
                                                                         // en el que se encuentra el Script. Puede ser �til, por ejemplo, para mostrar u ocultar partes espec�ficas de un objeto o
                                                                         // para controlar la visibilidad de ciertos elementos del juego en funci�n de la l�gica del juego o las interacciones del jugador.
            Invoke("CollectedFruit", 0.5f); // Esto sirve para programar la llamada a la funci�n "CollectedFruit" despu�s de un breve retraso de 0.5 segundos.
        }
    }

    public void CollectedFruit()
    {
        Destroy(gameObject); // Destruye el objeto que se hizo invisible o desactiva en este caso el SpriteRenderer
    }
}
