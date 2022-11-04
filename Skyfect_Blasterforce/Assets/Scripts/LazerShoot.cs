using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    private bool _isShooting;
    public float fireTime;
    //public float fireCoolDown;
    public GameObject lazer;
    public Transform lazerPositionGameObject;
    private Vector2 _lazerPosition;
    private void Update()
    {
        var position = lazerPositionGameObject.transform.position;
        _lazerPosition = new Vector2(position.x,position.y);
        if (Input.GetMouseButtonDown(0))
        {
            if (_isShooting == false)
                Shoot();
        }
    }
    
    private async void Shoot()
    {
        _isShooting = true;
        await UniTask.Delay(TimeSpan.FromSeconds(fireTime));
        Instantiate(lazer, _lazerPosition, Quaternion.identity);
        Debug.Log("Ates Etti");
        _isShooting = false;
    }
}
