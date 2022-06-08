using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public Paddle paddle1, paddle2;
    public float speedMultiplier = 1.1f;
    public ParticleSystem collisionParticle;
    
    private SoundManager soundManager;

    //[SerializeField] public Image countdownImage;
    //[SerializeField] public Sprite[] countdownSprite;
    [SerializeField] public Image winImage;
    [SerializeField] public Sprite[] winSprite = new Sprite[2];
    [SerializeField] private Animator myAnimationController;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        ReturnToCenter();
    }

    public void ReturnToCenter()
    {
        winImage.enabled = false; 
        
        if (paddle1.score > 9)
        {
            soundManager.SelectionAudio(2, 0.25f);
            winImage.enabled = true;
            winImage.sprite = winSprite[0];
            myAnimationController.SetTrigger("OnWin");
        }
        else if (paddle2.score > 9)
        {
            soundManager.SelectionAudio(2, 0.25f);
            winImage.enabled = true;
            winImage.sprite = winSprite[winSprite.Length - 1];
            myAnimationController.SetTrigger("OnWin");
        }
        else
        {
            StartCoroutine(Countdown());
        }

        
    }
    public IEnumerator Countdown() 
    {   //Velocidad y ángulo random.
        int velX = Random.Range(1, 3) == 1 ? Random.Range(-5, -5) : Random.Range(5, 5);
        int velZ = Random.Range(1, 3) == 1 ? Random.Range(-5, -5) : Random.Range(5, 5);
        
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(0, 0, 0);
    
        /*countdownImage.sprite = countdownSprite[0];

        Time.timeScale = 0f;

        for (int i = 3; i > 0; i--)//Cuenta atrás: 3... 2... 1... y la bola sale.
        {
            myAnimationController.SetTrigger("OnRestart");

            while (PauseMenu.GameIsPaused)
             {
                 yield return null;
             }

            countdownImage.enabled = true;
            countdownImage.sprite = countdownSprite[(i - 1) % countdownSprite.Length]; 
            yield return new WaitForSecondsRealtime(1);
            
        }

        countdownImage.enabled = false;

        Time.timeScale = 1f;*/

        rb.velocity = new Vector3(velX, 0, velZ);

        yield return null;
    }
    private void OnCollisionEnter(Collision collision) //Aumento de la velocidad de la bola cuando la golpea el paddle.
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();

        if (paddle)
        {
            soundManager.SelectionAudio(0, 0.25f);
            rb.velocity *= speedMultiplier;
            EmitParticle(8);
        }

        Wall wall = collision.collider.GetComponent<Wall>();

        if (wall)
        {
            soundManager.SelectionAudio(0, 0.25f);
            EmitParticle(8);
        }

    }
    private void EmitParticle(int amount)
    {
        collisionParticle.Emit(amount);
    }
}
