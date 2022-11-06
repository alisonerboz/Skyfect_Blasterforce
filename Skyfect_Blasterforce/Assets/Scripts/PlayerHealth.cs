using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    private int _myHealth = 100;
    public void PlayerTakeDamage(int i)
    {
        _myHealth -= i;
        Debug.Log(_myHealth);
        if (_myHealth <= 0)
        {
            Debug.Log("Player is Dead");
            Destroy(gameObject,0.5f);
        }
    }
}