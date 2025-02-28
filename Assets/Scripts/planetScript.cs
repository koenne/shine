using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetScript : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public float gravityForce = 5;
    public float rotationForce = 5;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Disable default gravity, since we're using a custom gravity system.

            if (rb != null)
            {
                // Get the direction from the player to the planet's center
                Vector2 direction = (transform.position - collision.transform.position).normalized;

                // Apply a force towards the center of the planet (simulating gravity)
                rb.AddForce(direction * gravityForce, ForceMode2D.Force);

                // Calculate the angle the player should be rotated to stand upright on the planet
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Adjust rotation so the player's feet point outward, away from the center
                Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 90);

                // Smoothly rotate the player to match the new orientation
                collision.transform.rotation = Quaternion.Slerp(collision.transform.rotation, targetRotation, rotationForce * Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.5f; // Restore normal gravity when leaving the planet's gravity field

            // Reset rotation so player is upright in normal gravity
            collision.transform.rotation = Quaternion.identity;
        }
    }
}
