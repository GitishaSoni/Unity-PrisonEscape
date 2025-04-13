using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int itemsCollected = 0;
    public GameObject finalDoor; // Assign in Inspector

    void Start()
    {
        // Hide the door at the start
        if (finalDoor != null)
            finalDoor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SecretItem"))
        {
            itemsCollected++;
            Destroy(other.gameObject); // Remove the collected item

            Debug.Log("Item collected! Total: " + itemsCollected);

            if (itemsCollected >= 3)
            {
                UnlockDoor();
            }
        }
    }

    void UnlockDoor()
    {
        if (finalDoor != null)
            finalDoor.SetActive(true); // Now the door appears!

        Debug.Log("All items collected. Door unlocked and visible!");
    }
}
