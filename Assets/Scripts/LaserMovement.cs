using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public float speed = 3f;
    public float range = 2f;
    public int damageAmount = 10;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * range;
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z); // Move along X-axis
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
