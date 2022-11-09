using System.Collections;
using UnityEngine;

public class LazerShoot : MonoBehaviour
{
    #region Private Variables
    
    private bool _isShooting;
    [SerializeField] private float fireTime;
    [SerializeField] private GameObject lazer;
    [SerializeField] private Transform lazerPositionGameObject;
    private Vector2 _lazerPosition;

    #endregion
    private void Update()//Fixed Update ile yavas calisiyor daha iyisini bulana kadar boyle durdurıyım.
    {
        var position = lazerPositionGameObject.transform.position;
        _lazerPosition = new Vector2(position.x,position.y);
        if (Input.GetMouseButtonDown(0))
        {
            if (_isShooting == false)
                StartCoroutine(Shoot());//Suan Ates Etmiyorsa Tıklandıgında ates etsin.
        }
    }

    private IEnumerator Shoot()//Ates Etme Fonksiyonu
    {
        _isShooting = true;
        yield return new WaitForSeconds(fireTime);
        Instantiate(lazer, _lazerPosition, Quaternion.identity);
        
        _isShooting = false;
    }
     
}
