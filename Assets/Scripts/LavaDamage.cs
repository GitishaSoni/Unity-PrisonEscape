using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    public int damageAmount = 20;
    public float damageInterval = 1.0f; // Time between each damage tick

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(20);
            }
        }
    }
}

