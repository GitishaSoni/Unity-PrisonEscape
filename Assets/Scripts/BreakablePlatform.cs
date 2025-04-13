using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    private bool isBreaking = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isBreaking)
        {
            isBreaking = true;
            Invoke("Break", 1f); // 1 second delay
        }
    }

    void Break()
    {
        Destroy(gameObject);
    }
}
