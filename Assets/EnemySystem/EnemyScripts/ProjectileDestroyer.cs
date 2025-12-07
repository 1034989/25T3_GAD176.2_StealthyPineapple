using UnityEngine;

public class ProjectileDestroyer : EnemyAI
{   //inherits from Enemy AI
    private void Awake()
    {
        DestroyProjectile();
    }
}
