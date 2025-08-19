using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static bool isGround; // para averiguar si está en el suelo

    private void OnTriggerEnter2D(Collider2D collision) // Cuando colisiona con algún objeto
    {
        isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }

}
