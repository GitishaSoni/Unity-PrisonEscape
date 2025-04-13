using UnityEngine;

public class RockDamage : MonoBehaviour
{
    public int damage = 15;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Destroy(gameObject); // destroy rock after hit
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 2f); // optional delay
        }
    }
}
