using UnityEngine;

public class captura : MonoBehaviour
{
    public float speed = 2f;                        // Velocidad de patrullaje
    public BoxCollider2D patrolArea;                // �rea donde se mueve (colocada en el editor)
    public float followSpeed = 3f;                  // Velocidad al perseguir al jugador
    public Transform player;                        // Referencia al jugador (asignado en el editor)

    private Rigidbody2D rb;
    private Vector2 leftLimit;
    private Vector2 rightLimit;
    private bool movingRight = true;
    private bool isChasing = false;                 // Estado de persecuci�n

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (patrolArea == null)
        {
            Debug.LogError("No se asign� el �rea de patrulla (BoxCollider2D)");
            return;
        }

        Bounds bounds = patrolArea.bounds;
        leftLimit = new Vector2(bounds.min.x, transform.position.y);
        rightLimit = new Vector2(bounds.max.x, transform.position.y);
    }

    void FixedUpdate()
    {
        if (patrolArea == null) return;

        if (isChasing)
        {
            FollowPlayer();  // Si estamos persiguiendo, seguimos al jugador
        }
        else
        {
            Move();  // Si no estamos persiguiendo, continuamos patrullando
        }
    }

    void Move()
    {
        float moveDir = movingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDir * speed, 0f);

        // Cambiar de direcci�n si alcanza los l�mites
        if (movingRight && transform.position.x >= rightLimit.x)
            movingRight = false;
        else if (!movingRight && transform.position.x <= leftLimit.x)
            movingRight = true;
    }

    void FollowPlayer()
    {
        // Mover al enemigo hacia el jugador
        float directionToPlayer = player.position.x - transform.position.x;
        if (directionToPlayer > 0)
        {
            rb.velocity = new Vector2(followSpeed, rb.velocity.y);  // Mover a la derecha
        }
        else if (directionToPlayer < 0)
        {
            rb.velocity = new Vector2(-followSpeed, rb.velocity.y);  // Mover a la izquierda
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;  // Empieza a perseguir cuando el jugador entra en el �rea
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // El enemigo no volver� a patrullar, se quedar� persiguiendo al jugador
            // Si quieres agregar alguna condici�n para que se detenga o regrese a patrullar, lo podr�as hacer aqu�
            // En este caso, simplemente se mantiene persiguiendo.
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja los l�mites de patrulla en el editor
        if (patrolArea != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(patrolArea.bounds.min.x, transform.position.y - 0.5f),
                            new Vector2(patrolArea.bounds.min.x, transform.position.y + 0.5f));
            Gizmos.DrawLine(new Vector2(patrolArea.bounds.max.x, transform.position.y - 0.5f),
                            new Vector2(patrolArea.bounds.max.x, transform.position.y + 0.5f));
        }
    }
}
