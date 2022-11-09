using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    #region Private Variables
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    #endregion

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject, 1f);
    }
}
