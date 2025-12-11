using StarterAssets;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f;    // How much to multiply speed
    public float duration = 5f;           // Power-up duration in seconds

    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.SetSpeed(player.baseSpeed * speedMultiplier);
            Destroy(gameObject); // Optional: remove power-up after pickup
            Debug.Log("Player has gained a speed boost!!");
            StartCoroutine(ResetSpeedAfterTime(player));
        }
    }

    private System.Collections.IEnumerator ResetSpeedAfterTime(PlayerMovement player)
    {
        yield return new WaitForSeconds(duration);
        if (player != null)
        {
            player.ResetSpeed();
        }
    }
}
