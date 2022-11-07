using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Private Variables
    
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float playerSpeed;//10
    [SerializeField] private float minX;//-1.5
    [SerializeField] private float maxX;//1.5
    [SerializeField] private float minY;//-3
    [SerializeField] private float maxY;//3
    private float _horizantal;
    private float _vertical;
    private Vector2 _vec;
    #endregion
    

    private void FixedUpdate()
    {
        _horizantal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _vec = new Vector2(_horizantal, _vertical);
        _rb.velocity = _vec * playerSpeed;
        var position = transform.position;
        _rb.position = new Vector2
            (
                Mathf.Clamp(position.x, minX, maxX),
                Mathf.Clamp(position.y, minY, maxY)
            );
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyLazer"))
            _playerHealth.PlayerTakeDamage(10);
            
    }
}
