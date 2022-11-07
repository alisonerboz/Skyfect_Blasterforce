using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private int myHealth = 100;
    [SerializeField] private Text _healthText;
    #endregion
    public void PlayerTakeDamage(int i)
    {
        myHealth -= i;
        _healthText.text = "Player Health : " + myHealth;
        if (myHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}