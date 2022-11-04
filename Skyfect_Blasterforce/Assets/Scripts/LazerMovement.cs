using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed;
    private AudioSource _lazerSound;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lazerSound = GetComponent<AudioSource>();
        _lazerSound.Play();
    }

    private void Update()
    {
        _rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("Lazer Carpti");
            Destroy(gameObject);
        }
    }
    
}
