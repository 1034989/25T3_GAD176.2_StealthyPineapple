using UnityEngine;

[CreateAssetMenu(fileName = "SentryData", menuName = "SentryData")]

public class SentryData : ScriptableObject
{
    //Sentry Movement related variables
    public float sentryMoveSpeed;

    //Sentry Damage related variables
    public float shootRange;
    public float fireRate;
    public float sentryDamage;
    public float nextFireTime;
    
    //Sentry Health related variables
    public float maxHealth; 
    public float currentHealth; 
    public float sentryHealth;
}
