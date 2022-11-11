using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private int myHealth = 100;
    [SerializeField] private Text _healthText;
	#endregion

	private void OnEnable()
	{
        PlayerMovement.OnGotHit += PlayerTakeDamage;
	}
	private void OnDisable()
	{
		PlayerMovement.OnGotHit -= PlayerTakeDamage;
	}

	public void PlayerTakeDamage()
    {
        myHealth -= 10;
        _healthText.text = "Player Health : " + myHealth;
        if (myHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void PerformDeathSound()
	{
        AudioManager.Instance.Play("PlayerDeath");
	}
}