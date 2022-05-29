using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
	public float speed;
	public int score = 0;
	[SerializeField] private KeyCode upKey;
	[SerializeField] private KeyCode downKey;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Ball ball;
	[SerializeField] private bool hasAI;


	private void Update()
	{
		if (hasAI)
		{
			if (transform.position.z < ball.transform.position.z)
			{
				rb.velocity = new Vector3(0, 0, speed);
			}
			else if (transform.position.z > ball.transform.position.z)
			{
				rb.velocity = new Vector3(0, 0, -speed);
			}
			else
			{
				rb.velocity = new Vector3(0, 0, 0);
			}
		}
		else
		{
			if (Input.GetKey(upKey))
			{
				rb.velocity = new Vector3(0, 0, speed);
			}
			else if (Input.GetKey(downKey))
			{
				rb.velocity = new Vector3(0, 0, -speed);
			}
			else
			{
				rb.velocity = new Vector3(0, 0, 0);
			}
		}
	}
}
