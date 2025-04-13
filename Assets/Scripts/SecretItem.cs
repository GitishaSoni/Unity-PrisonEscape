using UnityEngine;

public class SecretItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectSecretItem();
            Destroy(gameObject);
        }
    }
}
