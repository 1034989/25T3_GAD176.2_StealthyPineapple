using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //This is simply for testing, feel free to delete this script, replace it if your own player script
    public SentryData SentryData;
    public Sentry sentry;
    public SentryShoot sentryShoot;

    //Its unique Scripts
    public float playerHP = 100f; //Health
    private float maxHP = 100f; 
    private float currentHP = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHP = maxHP; 
    }

    public void TakeDamage()
    {
        sentryShoot.SentryShot();
    }

}
