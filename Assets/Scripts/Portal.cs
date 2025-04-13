using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exitPortal;  // Reference to the exit portal (PortalOrange)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the "Player" tag
        {
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform player)
    {
        // Move the player to the exit portal's position
        player.position = exitPortal.position;

        // Ensure the player faces the correct direction (facing forward from the exit portal)
        player.rotation = exitPortal.rotation;
    }
}
