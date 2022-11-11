using UnityEngine;
public class Enemy : MonoBehaviour
{
    #region Events

    #endregion

    #region Private Variables
    private int _enemyHealth = 100;
    #endregion
    

    
    private void OnTriggerEnter2D(Collider2D other) // Geçici
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("PlayerLazer"))
		{
            _enemyHealth -= 50;
			if (_enemyHealth <= 0)
			{
                PerformDeathSound();
                Destroy(gameObject);
			}
		}
    }
    public void PerformDeathSound()
	{
        AudioManager.Instance.Play("EnemyDeath");
	}
}
