using UnityEngine;
using DG.Tweening;

public class EnemyShooting : MonoBehaviour
{
	private float _fireRate = .5f;
	private float _fireDelay = .5f;
	private bool _isShooting;

	private void OnEnable()
	{
		InvokeRepeating("Shoot", _fireRate, _fireDelay);
	}

	[SerializeField] private GameObject[] _ammo;
	public void Shoot()
	{
		Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y - 1, 0);
		GameObject bullet = Instantiate(_ammo[Random.Range(0, _ammo.Length)], spawnPoint, Quaternion.identity);

		Vector3 destination = new Vector3(transform.position.x, -10, 0);
		bullet.transform.DOMove(destination, 1f);
		Destroy(bullet, 2f);
		if (_isShooting)
		{
			CancelInvoke("Shoot");
		}
	}
}
