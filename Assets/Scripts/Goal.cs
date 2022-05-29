using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Paddle enemyPaddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Reseteo de la bola cuando se marca un punto//
        enemyPaddle.score++;
        GameObject.Find("Ball").GetComponent<Ball>().ReturnToCenter();
    }
}

