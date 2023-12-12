public interface IDamagable 
{
    void SetHealth(float initHealth);
    float GetHealth();
    void TakeDamage(float takenDamage);
    void Dispose();
}
