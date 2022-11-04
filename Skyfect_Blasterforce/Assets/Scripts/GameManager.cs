using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    public GameObject enemy;
    public Vector2 randomPos;
    public float startTimer;
    public float instantiateTimer;
    public float loopTimer;
    private bool _gameOver=false;
    void Start()
    {
        Olustur();
    }

    
    private async void Olustur()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(startTimer));
        while(true)
        {
            for(int i=0;i<=10;i++)
            {
                Vector2 vec = new Vector2(Random.Range(-randomPos.x, randomPos.x),4);
                Instantiate(enemy, vec, Quaternion.identity);
                await UniTask.Delay(TimeSpan.FromSeconds(instantiateTimer));
            }
            await UniTask.Delay(TimeSpan.FromSeconds(loopTimer));
            if (_gameOver)
            {
                break;
            }
        }
        
    }
    /*
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        skor.text = "SKOR : " + score;
        patla.Play();
    }
    public void oyunBitti()
    {

        skor.text = "Bitti : " + score;
        
        oyunBittiKontrol = true;

    }*/
}
