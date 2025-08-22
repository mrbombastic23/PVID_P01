using System.Collections;
using UnityEngine;

public class golpe : MonoBehaviour
{
    public int vidas = 3; // Número de vidas del jugador
    public Sprite[] sprites; // Array con los sprites del corazón (13 sprites en total)
    private SpriteRenderer spriteRenderer;

    private bool recibiendoGolpe = false; // Para evitar múltiples colisiones simultáneas
    private bool muerto = false; // Si el personaje está muerto

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarCorazon(); // Mostrar el primer sprite de vida
    }

    // Función para recibir daño
    public void RecibirDaño()
    {
        if (recibiendoGolpe || muerto) return;

        recibiendoGolpe = true;

        // Si el jugador tiene vidas restantes
        if (vidas > 0)
        {
            vidas--;
            CambiarSpriteCorazon();
        }

        // Verificar si el jugador ha muerto
        if (vidas <= 0)
        {
            Muerte();
        }

        // Después de 1 segundo, permitir que reciba otro golpe
        StartCoroutine(EsperarRecibirGolpe());
    }

    private void CambiarSpriteCorazon()
    {
        // Los 3 primeros sprites corresponden a cada vida perdida
        if (vidas > 0)
        {
            spriteRenderer.sprite = sprites[3 - vidas]; // Primeros 3 sprites para las vidas
        }
        else
        {
            spriteRenderer.sprite = sprites[3]; // Muestra el sprite de muerte
        }
    }

    private void Muerte()
    {
        muerto = true;
        // Acción cuando el jugador muere (por ejemplo, desactivar el personaje)
        Debug.Log("¡El jugador ha muerto!");

        // Reproduce los sprites de muerte consecutivos
        StartCoroutine(AnimacionMuerte());
    }

    private IEnumerator AnimacionMuerte()
    {
        // Después de que el jugador muere, reproducimos los últimos sprites rápidamente
        for (int i = 4; i < sprites.Length; i++) // Empieza desde el cuarto sprite
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(0.1f); // Tiempo entre cada sprite (rápido)
        }

        // Después de la animación de muerte, puedes desactivar el personaje o hacer algo más
        gameObject.SetActive(false); // Desactivar el personaje
    }

    private IEnumerator EsperarRecibirGolpe()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de permitir recibir otro golpe
        recibiendoGolpe = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Comprobar si el objeto con el que colisiona tiene el tag "Enemigo"
        if (col.collider.CompareTag("Enemigo"))
        {
            RecibirDaño();
        }
    }

    // Actualiza el sprite del corazón según las vidas
    private void ActualizarCorazon()
    {
        // Inicializa el sprite del corazón con el primer sprite
        if (vidas > 0)
        {
            spriteRenderer.sprite = sprites[3 - vidas]; // Primeros 3 sprites para las vidas
        }
        else
        {
            spriteRenderer.sprite = sprites[3]; // Si el personaje ya está muerto
        }
    }
}

