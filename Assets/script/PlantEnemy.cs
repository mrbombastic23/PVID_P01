using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    //En resumen, este script controla el disparo periódico de un objeto en el juego,
    //reproduce una animación de ataque y crea balas en un punto de lanzamiento específico cuando se cumple el tiempo de espera establecido.

    private float waitedTime; //Esta variable privada almacena el tiempo que se ha esperado desde el último disparo.
    public float waitTimeToAttack = 3f; //Esta variable pública determina cuanto tiempo debe esperar el objeto entre cada disparo.
    public Animator animator; //Referencia al componente Animator que se utiliza para controlar las animaciones del objeto
    public GameObject bulletPrefab; //Prefab del proyectil (objeto de juego) que se instanciará como una bala cuando el objeto dispare. (GameObject)
    public Transform punto_lanzamiento; //Esto se utiliza para determinar la posición inicial y la dirección de la bala.

    private void Start()
    {
        waitedTime = waitTimeToAttack; //Esto asegura que el objeto espere el tiempo correcto antes de su primer disparo.
    }

    private void Update()
    {
        if (waitedTime <= 0) //Comprueba si waitedTime es menor o igual a 0. Si es así, significa que ha pasado el tiempo de espera y el objeto debe disparar.
        {
            waitedTime = waitTimeToAttack; //Se reinicia
            animator.Play("attack"); //Reproduce una animación llamada "attack" a través del componente animator
            Invoke("LanzarBala", 0.5f); //Invoca la función "LanzarBala()" con un retraso de 0.5 segundos usando Invoke().
        }
        else
        {
            waitedTime -= Time.deltaTime; //Se actualiza el tiempo de espera
        }
    }

    //Esta función se encarga de crear y lanzar la bala
    private void LanzarBala()
    {
        GameObject newBullet; //Crea una nueva instancia del prefab Bullet
        newBullet = Instantiate(bulletPrefab, punto_lanzamiento.position, punto_lanzamiento.rotation); //Define la dirección en la que la bala se lanzará
    }
}
