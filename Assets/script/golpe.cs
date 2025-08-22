using System.Collections;
using UnityEngine;

public class golpe : MonoBehaviour
{
    public int vidas = 3; // N�mero de vidas del jugador
    public Sprite[] sprites; // Array con los sprites del coraz�n (13 sprites en total)
    private SpriteRenderer spriteRenderer;

    private bool recibiendoGolpe = false; // Para evitar m�ltiples colisiones simult�neas
    private bool muerto = false; // Si el personaje est� muerto

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarCorazon(); // Mostrar el primer sprite de vida
    }

    // Funci�n para recibir da�o
    public void RecibirDa�o()
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

        // Despu�s de 1 segundo, permitir que reciba otro golpe
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
        // Acci�n cuando el jugador muere (por ejemplo, desactivar el personaje)
        Debug.Log("�El jugador ha muerto!");

        // Reproduce los sprites de muerte consecutivos
        StartCoroutine(AnimacionMuerte());
    }

    private IEnumerator AnimacionMuerte()
    {
        // Despu�s de que el jugador muere, reproducimos los �ltimos sprites r�pidamente
        for (int i = 4; i < sprites.Length; i++) // Empieza desde el cuarto sprite
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(0.1f); // Tiempo entre cada sprite (r�pido)
        }

        // Despu�s de la animaci�n de muerte, puedes desactivar el personaje o hacer algo m�s
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
            RecibirDa�o();
        }
    }

    // Actualiza el sprite del coraz�n seg�n las vidas
    private void ActualizarCorazon()
    {
        // Inicializa el sprite del coraz�n con el primer sprite
        if (vidas > 0)
        {
            spriteRenderer.sprite = sprites[3 - vidas]; // Primeros 3 sprites para las vidas
        }
        else
        {
            spriteRenderer.sprite = sprites[3]; // Si el personaje ya est� muerto
        }
    }
}

