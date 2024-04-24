using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{
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