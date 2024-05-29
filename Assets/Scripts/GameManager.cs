using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public hud hud;
    //public event EventHandler MuerteJugador;

    private int vidas = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }

    public void PerderVida()
    {
        vidas -= 1;
        if (vidas == 0)
        {
            //MuerteJugador?.Invoke(this, EventArgs.Empty);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        hud.DesactivarVida(vidas);
    }
}
