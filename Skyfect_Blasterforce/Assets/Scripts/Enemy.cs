using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    #region Private Variables
    //[SerializeField] private Rigidbody2D _rb;
    //[SerializeField] private EnemyHealth _enemyHealth;
    //Boyle Yapınca Calismadilar nedense
    
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private EnemyHealth _enemyHealth;
    private PlayerHealth _playerHealth;
    private GameManager _control;
    private readonly int _crushDamageToPlayer = 25;
    private readonly int _crushDamageToMe = 50;
    private readonly int _lazerDamage = 25;
    
    [SerializeField] private float fireTime=2f;
    [SerializeField] private GameObject lazer;
    [SerializeField] private Transform lazerPositionGameObject;
    private Vector2 _lazerPosition;
    private bool _enemyisShooting = false;
    #endregion
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    
    private void FixedUpdate()
    {
        var position = lazerPositionGameObject.transform.position;
        _lazerPosition = new Vector2(position.x,position.y);
        _rb.velocity = -transform.up * speed;
        if (!_enemyisShooting)
            StartCoroutine(EnemyLazerShoot());
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
            Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
            _playerHealth = other.GetComponent<PlayerHealth>();
            _playerHealth.PlayerTakeDamage(_crushDamageToPlayer);
            _enemyHealth.EnemyTakeDamage(_crushDamageToMe);
        }
        if (other.CompareTag("PlayerLazer"))
            _enemyHealth.EnemyTakeDamage(_lazerDamage);
    }

    private IEnumerator EnemyLazerShoot()
    {
        _enemyisShooting = false;
        for (int o = 0; o < 4; o++)
        {
            _enemyisShooting = true;
            yield return new WaitForSeconds(fireTime);
            Instantiate(lazer, _lazerPosition, Quaternion.identity);
        }
    }
}
