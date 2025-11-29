using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        int outcome = Random.Range(0, 3);
        var playerHealth = other.GetComponent<PlayerHealth>();

        switch (outcome)
        {
            case 0: // Health boost
                playerHealth?.UseEnergy(1);
                MysteryBoxMessageManager.instance.ShowMessage("Health Restored!");
                break;
            case 1: // Points boost
                ScoreManager.instance.AddScore(5);
                MysteryBoxMessageManager.instance.ShowMessage("Bonus Points!");
                break;
            case 2: // Trap
                ScoreManager.instance.RemoveScore(3);
                MysteryBoxMessageManager.instance.ShowMessage("Trap! Lost 3 Coins!");
                break;
        }

        Destroy(gameObject);
    }

}
