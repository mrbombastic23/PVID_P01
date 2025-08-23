using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    // Dise�ado para controlar el comportamiento de una bala en el juego.
    public float speed = 2; //Esta variable p�blica determina la velocidad a la que se mover� la bala
    public float lifeTime = 2; //Esta variable p�blica especifica el tiempo de vida de la bala.
                               //Despu�s de un cierto per�odo de tiempo, la bala se destruir� autom�ticamente.
    public bool left; //Esta variable p�blica determina la direcci�n en la que se mover� inicialmente la bala

    private void Start()
    {
        Destroy(gameObject, lifeTime); //Se encarga de programar la destrucci�n de la bala despu�s de un tiempo igual a lifeTime
    }

    private void Update() //Este m�todo se ejecuta en cada fotograma del juego y controla el movimiento de la bala.
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
