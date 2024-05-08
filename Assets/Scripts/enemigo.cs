using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
	public Rigidbody2D rb2D;

	public float velocidadDeMovimiento;

	public LayerMask capaAbajo;
	public LayerMask capaEnFrente;

	public float distanciaAbajo;
	public float distanciaEnFrente;

	public Transform ControladorAbajo;
	public Transform ControladorEnFrente;

	public bool informacionAbajo;
	public bool informacionEnFrente;

	private bool mirandoALaDerecha = true;

	private void Update()
    {
		rb2D.velocity = new Vector2(velocidadDeMovimiento,rb2D.velocity.y);

		informacionEnFrente = Physics2D.Raycast(ControladorEnFrente.position, transform.right, distanciaEnFrente, capaEnFrente);
		informacionAbajo = Physics2D.Raycast(ControladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

		if(informacionEnFrente || !informacionAbajo)
        {
			Girar();
        }
	}

	private void Girar()
    {
		mirandoALaDerecha = !mirandoALaDerecha;
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
		velocidadDeMovimiento *= -1;
    }

	private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(ControladorAbajo.transform.position, ControladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
		Gizmos.DrawLine(ControladorEnFrente.transform.position, ControladorEnFrente.transform.position + transform.right * distanciaEnFrente);
	}

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
