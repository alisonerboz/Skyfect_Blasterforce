using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    #region Private Variables
    private AudioManager MySound;
    #endregion
    private void Awake()
    {
        //MySound = FindObjectOfType<AudioManager>();
    }
    
    public void Back()
    {
        //MySound.Play("HudClickSound");
        SceneManager.LoadScene(0);
    }
    public void Settings()
    {
        //MySound.Play("HudClickSound");
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        //MySound.Play("HudClickSound");
        SceneManager.LoadScene(2);
    }
    public void Play()
    {
        //MySound.Play("HudClickSound");
        SceneManager.LoadScene(3);
    }
    
    public void Exit()
    {
        //MySound.Play("HudClickSound");
        Application.Quit();
    }
}
