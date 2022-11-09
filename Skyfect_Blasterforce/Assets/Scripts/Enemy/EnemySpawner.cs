using UnityEngine;
using PathCreation;

public class EnemySpawner : MonoBehaviour
{
	#region Private Variables
	[SerializeField] private GameObject[] _enemiesToSpawn;
	[SerializeField] private float _spawnRate = 3f;
	[SerializeField] private float _spawnDelay = 5f;
	[SerializeField] private PathCreator[] _paths;
	[SerializeField] public static PathCreator _path;
	private bool _stopSpawning = false;

	#endregion
	private void Start()
	{
		
		InvokeRepeating("SpawnEnemies", _spawnRate, _spawnDelay);
	}
	private void SpawnEnemies()
	{
		_path = _paths[Random.Range(0, _paths.Length)];
		Vector3 spawnPosition = _path.path.localPoints[0];
		Instantiate(_enemiesToSpawn[Random.Range(0, _enemiesToSpawn.Length)], spawnPosition, Quaternion.identity);
		if (_stopSpawning)
		{
			CancelInvoke("SpawnEnemies");
		}
	}	
}
