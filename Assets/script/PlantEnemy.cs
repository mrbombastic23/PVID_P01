using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    //En resumen, este script controla el disparo peri�dico de un objeto en el juego,
    //reproduce una animaci�n de ataque y crea balas en un punto de lanzamiento espec�fico cuando se cumple el tiempo de espera establecido.

    private float waitedTime; //Esta variable privada almacena el tiempo que se ha esperado desde el �ltimo disparo.
    public float waitTimeToAttack = 3f; //Esta variable p�blica determina cuanto tiempo debe esperar el objeto entre cada disparo.
    public Animator animator; //Referencia al componente Animator que se utiliza para controlar las animaciones del objeto
    public GameObject bulletPrefab; //Prefab del proyectil (objeto de juego) que se instanciar� como una bala cuando el objeto dispare. (GameObject)
    public Transform punto_lanzamiento; //Esto se utiliza para determinar la posici�n inicial y la direcci�n de la bala.

    private void Start()
    {
        waitedTime = waitTimeToAttack; //Esto asegura que el objeto espere el tiempo correcto antes de su primer disparo.
    }

    private void Update()
    {
        if (waitedTime <= 0) //Comprueba si waitedTime es menor o igual a 0. Si es as�, significa que ha pasado el tiempo de espera y el objeto debe disparar.
        {
            waitedTime = waitTimeToAttack; //Se reinicia
            animator.Play("attack"); //Reproduce una animaci�n llamada "attack" a trav�s del componente animator
            Invoke("LanzarBala", 0.5f); //Invoca la funci�n "LanzarBala()" con un retraso de 0.5 segundos usando Invoke().
        }
        else
        {
            waitedTime -= Time.deltaTime; //Se actualiza el tiempo de espera
        }
    }

    //Esta funci�n se encarga de crear y lanzar la bala
    private void LanzarBala()
    {
        GameObject newBullet; //Crea una nueva instancia del prefab Bullet
        newBullet = Instantiate(bulletPrefab, punto_lanzamiento.position, punto_lanzamiento.rotation); //Define la direcci�n en la que la bala se lanzar�
    }
}
