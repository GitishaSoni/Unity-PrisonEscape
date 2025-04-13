using UnityEngine;

public class Lasermoveupdown : MonoBehaviour
{
    public float speed = 3f;              // Movement speed
    public float range = 2f;              // Max vertical range
    public int damageAmount = 10;         // Damage dealt to player

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * range;

        // Move up and down along world Y-axis
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
