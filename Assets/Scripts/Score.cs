using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[SerializeField] Paddle paddle;
	[SerializeField] private Image image;
	[SerializeField] private Sprite[] scoreSprites;

	public void UpdateScore()
	{
		image.sprite = scoreSprites[Mathf.Clamp(++paddle.score, 0, scoreSprites.Length - 1)];
	}
}
