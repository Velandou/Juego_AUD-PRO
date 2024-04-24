using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public hud hud;

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
            SceneManager.LoadScene(1);
        }
        hud.DesactivarVida(vidas);
    }

    //public void SumarPuntos(int puntosASumar)
    //{
    //    puntosTotales += puntosASumar;
    //}
}