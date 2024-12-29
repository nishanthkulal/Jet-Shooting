using UnityEngine;

public class AstroidColison : MonoBehaviour
{
    private bool audioplay = true;
    private SpriteRenderer spriteRenderer; // To access the material color
    private Collider2D collider2D; // To access and disable the collider

    private void Awake()
    {
        // Initialize references
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    public void OnEnable()
    {
        EventHandler.OnGameEnd += DistroyAllCoilders;
    }

    public void OnDisable()
    {
        EventHandler.OnGameEnd -= DistroyAllCoilders;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object has the tag "Bullate"
        if (collision.gameObject.CompareTag("Bullate"))
        {
            if (audioplay)
            {
                audioplay = false;
                EventHandler.AstroidCollision(gameObject.GetComponent<AudioSource>());
            }

            Debug.Log("Bullate hit");

            // Optionally, destroy the bullet if desired
            Destroy(collision.gameObject);

            // Reduce alpha and disable collider
            ReduceAlphaAndDisableCollider();

            Invoke(nameof(ColiderDestroyDelay), 0.5f);
        }
    }

    private void ReduceAlphaAndDisableCollider()
    {
        // Reduce the alpha to zero
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 0f; // Set alpha to zero
            spriteRenderer.color = color;
        }

        // Disable the collider
        if (collider2D != null)
        {
            collider2D.enabled = false;
        }
    }

    private void ColiderDestroyDelay()
    {
        EventHandler.ColiderDestroy(1);
        Destroy(gameObject);
    }

    private void DistroyAllCoilders() => Destroy(gameObject);
}
