using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private int enemyHealth = 50;
    [SerializeField] private AudioSource _boomSound;
    #endregion
    public void EnemyTakeDamage(int i)
    {
        enemyHealth -= i; ;
        if (enemyHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            //_boomSound.Play();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}