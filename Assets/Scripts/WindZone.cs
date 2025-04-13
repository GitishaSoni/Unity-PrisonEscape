using UnityEngine;

public class WindyZone : MonoBehaviour
{
    public float windForce = 20f;
    public Vector3 windDirection = Vector3.back; // change this to Vector3.back for "push back"

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(windDirection.normalized * windForce, ForceMode.Acceleration);
            }
        }
    }
}
