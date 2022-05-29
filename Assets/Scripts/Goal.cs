using UnityEngine;

public class Goal : MonoBehaviour
{
	[SerializeField] private Ball ball;
	[SerializeField] private Score score;

	void OnTriggerEnter(Collider other)
	{
		//Reseteo de la bola cuando se marca un punto//
		score.UpdateScore();
		ball.ReturnToCenter();
	}
}