using UnityEngine;

public class Goal : MonoBehaviour
{
	[SerializeField] private Ball ball;
	[SerializeField] private Score score;
	[SerializeField] private Animator myAnimationController;
	private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
        {
			myAnimationController.SetTrigger("OnScore");
        }

		soundManager.SelectionAudio(1, 0.5f);
		score.UpdateScore();
		ball.ReturnToCenter();
	}

}