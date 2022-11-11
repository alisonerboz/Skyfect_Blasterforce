using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	public static UnityAction OnGotHit;

	private void OnEnable()
	{
		GameManager.OnGameRunning += Move;
	}
	private void OnDisable()
	{
		GameManager.OnGameRunning -= Move;
	}


	public void Move()
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.DOMoveX(transform.position.x - .1f, .1f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.DOMoveX(transform.position.x + .1f, .1f);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.DOMoveY(transform.position.y + .1f, .1f);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.DOMoveY(transform.position.y - .1f, .1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("EnemyLazer"))
		{
			OnGotHit?.Invoke();
		}
	}
}
