using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    #region Private Variables
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource lazerSound;
    [SerializeField] private float speed;

    #endregion

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("LazerShoot");
        
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject,1f);
    }
    /*
        audio manager
        dusman mekanik>
        unitaski değiş >
        regionlara ayır >
     */
}
