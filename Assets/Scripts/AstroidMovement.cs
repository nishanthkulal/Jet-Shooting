using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of movement
    [SerializeField] private float destroyXPosition = -12.18f; // X position to destroy the object

    void OnEnable()
    {
        StartCoroutine(MoveLeftCoroutine());
    }

    IEnumerator MoveLeftCoroutine()
    {
        while (true) // Infinite loop for continuous movement
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;

            // Check if the object has reached or passed the destroy position
            if (transform.position.x <= destroyXPosition)
            {
                Destroy(gameObject);
                yield break; // Exit the coroutine
            }

            yield return new WaitForFixedUpdate(); // Use FixedUpdate timing
        }
    }
}
