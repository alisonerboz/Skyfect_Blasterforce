using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int myHealth = 100;
    private GameObject _canvas;
    private Text _healthText;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas");
        _healthText = _canvas.GetComponentInChildren<Text>();
    }

    

    public void PlayerTakeDamage(int i)
    {
        myHealth -= i;
        _healthText.text = "Player Health : " + myHealth;
        if (myHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}