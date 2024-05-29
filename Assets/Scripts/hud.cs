using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hud : MonoBehaviour
{

    [SerializeField] private GameObject menuGameOver;
    //private GameManager gamemanager;

//    public void Start()
//    {
//        gamemanager = GameManager.Instance;
//        gamemanager.MuerteJugador += ActivarMenu;
//    }

//    private void ActivarMenu(object sender, EventArgs e)
//    {
//        Time.timeScale = 0; // Pause the game
//        menuGameOver.SetActive(true);
//    }

//    public void Reiniciar()
//    {
//        Time.timeScale = 1; // Resume the game
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    public void MenuInicial(string nombre)
//    {
//        Time.timeScale = 1; // Resume the game
//        SceneManager.LoadScene(nombre);
//    }

//    public void Salir()
//    {
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#else
//        Application.Quit();
//#endif
//    }

    public GameObject[] vidas;

    void Update()
    {

    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
