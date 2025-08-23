using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    // Diseñado para controlar el comportamiento de una bala en el juego.
    public float speed = 2; //Esta variable pública determina la velocidad a la que se moverá la bala
    public float lifeTime = 2; //Esta variable pública especifica el tiempo de vida de la bala.
                               //Después de un cierto período de tiempo, la bala se destruirá automáticamente.
    public bool left; //Esta variable pública determina la dirección en la que se moverá inicialmente la bala

    private void Start()
    {
        Destroy(gameObject, lifeTime); //Se encarga de programar la destrucción de la bala después de un tiempo igual a lifeTime
    }

    private void Update() //Este método se ejecuta en cada fotograma del juego y controla el movimiento de la bala.
    {
        //Comprueba el valor de la variable left. Si es true, la bala se mueve hacia la izquierda
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); //la bala se mueve hacia la izquierda
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //Si es false, la bala se mueve hacia la derecha
        }
    }
}
