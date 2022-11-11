using UnityEngine;
using DG.Tweening;
using PathCreation;

public class EnemyMovement : MonoBehaviour
{
	#region Private Variables
	[SerializeField] private float _speed = 3f;
	public PathCreator pathCreator;
	private EndOfPathInstruction _end;
	private float _dstTravelled;
	#endregion

	#region Properties
	public float speed { get => _speed; set => _speed = value; }
	public float dstTravelled { get => _dstTravelled; set => _dstTravelled = value; }
	public EndOfPathInstruction end { get => _end; set => _end = value; }
	public float DstTravelled { get => _dstTravelled; set => _dstTravelled = value; }
	#endregion	
	private void OnEnable()
	{
		pathCreator = EnemySpawner._path;
		GameManager.OnGameRunning += Move;
	}
	private void OnDisable()
	{
		GameManager.OnGameRunning -= Move;
	}
	private void Move()
	{
		if (pathCreator != null)
		{
			dstTravelled += speed * Time.deltaTime;
			Vector3 road = pathCreator.path.GetPointAtDistance(dstTravelled, end = EndOfPathInstruction.Stop);
			Vector3 lastPoint = pathCreator.path.GetPoint(pathCreator.path.localPoints.Length - 1);
			transform.position = road;

			if (lastPoint == road)
			{
				Destroy(gameObject);
			}
		}
	}
}
