using System.Collections;
using UnityEngine.Events;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    #region Events

	#endregion

	#region Private Variables

    #endregion
    

    
    private void OnTriggerEnter2D(Collider2D other) // Geçici
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("PlayerLazer"))
		{
            Destroy(gameObject);
		}
    }
}
