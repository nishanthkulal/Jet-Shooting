using System.Collections;
using UnityEngine;

public class BullateMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed at which the bullet moves
    [SerializeField] private float destroyXPosition = 9.26f; // X position to destroy the bullet

    void OnEnable()
    {
        // Start the coroutine when the bullet is enabled
        StartCoroutine(MoveBullet());
    }

    IEnumerator MoveBullet()
    {
        while (true)
        {
            // Move the bullet to the right
            transform.position += Vector3.right * speed * Time.fixedDeltaTime;

            // Check if the bullet reaches the destroy position
            if (transform.position.x >= destroyXPosition)
            {
                Destroy(gameObject); // Destroy the bullet
                yield break; // Exit the coroutine
            }

            // Wait until the next FixedUpdate
            yield return new WaitForFixedUpdate();
        }
    }

}
