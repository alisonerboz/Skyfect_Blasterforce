using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    private GameManager _control;
    private AudioSource _boomSound;

    PlayerHealth _playerHealth;
    private readonly int _crushDamageToPlayer = 25;
    EnemyHealth _enemyHealth;
    private readonly int _crushDamageToMe = 50;
    private readonly int _lazerDamage = 25;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boomSound = GetComponent<AudioSource>();
        _enemyHealth = GetComponent<EnemyHealth>();
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
            _playerHealth = other.GetComponent<PlayerHealth>();
            _playerHealth.PlayerTakeDamage(_crushDamageToPlayer);
            _enemyHealth.EnemyTakeDamage(_crushDamageToMe);
        }
        if (other.CompareTag("PlayerLazer"))
        {
            //_boomSound.Play();
            _enemyHealth.EnemyTakeDamage(_lazerDamage);
        }
    }
}
