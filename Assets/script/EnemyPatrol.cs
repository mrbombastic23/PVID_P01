using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;                        // Velocidad del enemigo
    public BoxCollider2D patrolArea;                // Área donde se mueve (colocada en el editor)

    private Rigidbody2D rb;
    private Vector2 leftLimit;
    private Vector2 rightLimit;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (patrolArea == null)
        {
            Debug.LogError("No se asignó el área de patrulla (BoxCollider2D)");
            return;
        }

        Bounds bounds = patrolArea.bounds;
        leftLimit = new Vector2(bounds.min.x, transform.position.y);
        rightLimit = new Vector2(bounds.max.x, transform.position.y);
    }

    void FixedUpdate()
    {
        if (patrolArea == null) return;

        Move();
    }

    void Move()
    {
        float moveDir = movingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDir * speed, 0f);

        // Cambiar de dirección si alcanza los límites
        if (movingRight && transform.position.x >= rightLimit.x)
            movingRight = false;
        else if (!movingRight && transform.position.x <= leftLimit.x)
            movingRight = true;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja los límites de patrulla en el editor
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
