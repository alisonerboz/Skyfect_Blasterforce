using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	#region Private Variables
	private bool _allowedToShoot = true;
	[SerializeField] private float _fireRate = .2f;
	[SerializeField] private GameObject[] _ammo;
	#endregion

	private void Update()
	{
		StartCoroutine(Shoot());
	}
	private void OnDisable()
	{
		StopCoroutine(Shoot());
	}

	public IEnumerator Shoot()
	{
		if (Input.GetKey(KeyCode.Mouse0) && _allowedToShoot)
		{
			_allowedToShoot = false;
			Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + .5f, 0);
			GameObject bullet = Instantiate(_ammo[Random.Range(0, _ammo.Length)], spawnPoint, Quaternion.identity);

			PerformShootingSound();

			Vector3 destination = new Vector3(transform.position.x, 14, 0);
			bullet.transform.DOMove(destination, 1f);
			Destroy(bullet, 2f);
			yield return new WaitForSeconds(_fireRate);
			_allowedToShoot = true;
		}
	}
	public void PerformShootingSound()
	{
		AudioManager.Instance.Play("PlayerShoot");
	}
}
