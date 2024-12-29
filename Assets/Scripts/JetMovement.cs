using UnityEngine;

public class JetMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the jet's movement
    [SerializeField] private float upperLimit = 3.86f; // Upper boundary
    [SerializeField] private float lowerLimit = -3.9f; // Lower boundary
    void Update()
    {
        // Get vertical input (W/UpArrow for positive, S/DownArrow for negative)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate new position
        Vector3 newPosition = transform.position + Vector3.up * verticalInput * speed * Time.deltaTime;

        // Clamp the new position within the boundaries
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLimit, upperLimit);
        newPosition.x = -7.84f;

        // Apply the clamped position
        transform.position = newPosition;
    }
}
