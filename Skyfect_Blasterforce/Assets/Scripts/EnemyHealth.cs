using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    private int _enemyHealth = 50;
    public void EnemyTakeDamage(int i)
    {
        _enemyHealth -= i;
        Debug.Log(_enemyHealth);
        if (_enemyHealth <= 0)
        {
            Debug.Log("Enemy is Dead");
            Destroy(gameObject,0.5f);
        }
    }
}