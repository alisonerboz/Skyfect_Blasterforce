using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    private GameManager _control;
    private AudioSource _boomSound;

    private PlayerHealth _playerHealth;
    //private int _crushDamegeToPlayer = 25;
    private EnemyHealth _enemyHealth;
    //private int _crushDamegeToMe = 50;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boomSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            _boomSound.Play();
            _playerHealth.PlayerTakeDamage(25);
            _enemyHealth.EnemyTakeDamage(50);
        }
        if (other.CompareTag("PlayerLazer"))
        {
            _boomSound.Play();
            Destroy(gameObject,0.1f);
        }
    }
}
