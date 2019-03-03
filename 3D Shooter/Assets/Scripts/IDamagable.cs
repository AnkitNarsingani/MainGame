public interface IDamagable<T>
{
    void TakeDamage(T dmgValue);
    void Die(T leastHealth);
}
