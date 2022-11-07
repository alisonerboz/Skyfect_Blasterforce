using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameManager : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private GameObject enemy;//public
    [SerializeField] private Vector2 randomPos;//public
    [SerializeField] private float startTimer;//public
    [SerializeField] private float instantiateTimer;//public
    [SerializeField] private float loopTimer; //public
    [SerializeField] private int EnemyValue; //public
    private bool _gameOver=false;
    #endregion
    void Start()
    {
        StartCoroutine(CreateNewEnemy());
    }
    private IEnumerator CreateNewEnemy()
    {
        yield return new WaitForSeconds(startTimer);
        while(true)
        {
            for(int i=0;i<=EnemyValue;i++)
            {
                Vector2 vec = new Vector2(Random.Range(-randomPos.x, randomPos.x),5);
                Instantiate(enemy, vec, Quaternion.identity);
                yield return new WaitForSeconds(instantiateTimer);
            }
            yield return new WaitForSeconds(loopTimer);
            if (_gameOver)
            {
                break;
            }
        }
    }
}
