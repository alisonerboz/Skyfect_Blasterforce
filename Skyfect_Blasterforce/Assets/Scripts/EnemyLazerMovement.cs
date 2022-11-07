using UnityEngine;
public class EnemyLazerMovement : MonoBehaviour
{
    #region Private Variables
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource lazerSound;
    [SerializeField] private float speed;
    private PlayerHealth _playerHealth;

    #endregion

    private void Start()
    {
        //_playerHealth.GetComponent<PlayerHealth>();
        lazerSound.Play();
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject,1f);
        
    }
}
