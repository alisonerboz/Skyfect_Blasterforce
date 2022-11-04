using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D _rb;
    private float _horizantal;
    private float _vertical;
    Vector2 _vec;
    public float playerSpeed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

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
}
