using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed;
    GameManager _control; 
    AudioSource _boomSound;
    
    void Start()
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
            Destroy(gameObject);
        }
        if (other.CompareTag("PlayerLazer"))
        {
            _boomSound.Play();
            Destroy(gameObject);
        }
    }
}
