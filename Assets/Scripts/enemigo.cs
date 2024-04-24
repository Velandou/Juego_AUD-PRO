using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.Instance.PerderVida();
		}
	}

	private void SpawnNewEnemy()
	{
		// Access the ObstacleManager or a dedicated enemy spawner script to handle enemy spawning
		ObstacleManager.Instance.SpawnRandomObstacle(); // Assuming you have an ObstacleManager with a method to spawn enemies
	}
}
