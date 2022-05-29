using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public Paddle paddle1, paddle2;
    public Text winText, countdownText;
    public float speedMultiplier = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ReturnToCenter();
    }

    public void ReturnToCenter()
    {
        //Texto del ganador si un jugador alcanza los 10 puntos y se para el juego//

        if (paddle1.score > 9)
        {
            winText.enabled = true;
            winText.text = "Player 1 Wins!";
            Time.timeScale = 0;
        }
        else if (paddle2.score > 9)
        {
            winText.enabled = true;
            winText.text = "Player 2 wins!";
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(Countdown());
        }

        
    }
    public IEnumerator Countdown() //Cuenta atrás cuando se marca un punto//
    {   //Cuando se reinicia la bola, tiene un ángulo random//
        int velX = Random.Range(1, 3) == 1 ? Random.Range(-4, -7) : Random.Range(4, 7);
        int velZ = Random.Range(1, 3) == 1 ? Random.Range(-4, -7) : Random.Range(4, 7);

        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, 0, 0);

        countdownText.enabled = true;

        Time.timeScale = 0f;
        
        for (int i = 3; i > 0; i--)//Cuenta atrás: 3... 2... 1... y la bola sale//
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        Time.timeScale = 1f;

        countdownText.enabled = false;
        rb.velocity = new Vector3(velX, 0, velZ);

        yield return null;
    }
    private void OnCollisionEnter(Collision collision) //Aumento de la velocidad de la bola cuando la golpea el paddle//
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();

        if (paddle)
        {
            rb.velocity *= speedMultiplier;
        }
    }
}
