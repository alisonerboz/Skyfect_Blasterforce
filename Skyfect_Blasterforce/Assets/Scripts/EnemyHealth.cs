using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 50;
    private AudioSource _boomSound;
    private void Start()
    {
        _boomSound = GetComponent<AudioSource>();
    }

    public void EnemyTakeDamage(int i)
    {
        enemyHealth -= i;
        Debug.Log("Enemy Health : "+enemyHealth);
        if (enemyHealth <= 0)
        {
            _boomSound.Play();
            Debug.Log("Enemy is Dead");
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}