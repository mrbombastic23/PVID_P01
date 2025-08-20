using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static bool isGround; // para averiguar si est� en el suelo

    private void OnTriggerEnter2D(Collider2D collision) // Cuando colisiona con alg�n objeto
    {
        // Comprobar si el objeto tiene la etiqueta "Suelo"
        if (collision.CompareTag("Suelo"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Comprobar si el objeto que sale tiene la etiqueta "Suelo"
        if (collision.CompareTag("Suelo"))
        {
            isGround = false;
        }
    }
}
