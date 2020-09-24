/** Sam Carpenter
* Challenge3
* slightly modified
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
	public AudioClip boingsound;
	
	public int score = 0;
	public Text scoretxt;
	public Text statetxt;
	public Text rtxt;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
		playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
		
		scoretxt.text = score.ToString();
		statetxt.enabled = false;
		rtxt.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
		scoretxt.text = score.ToString();
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
		
		//i bring you down
		if(transform.position.y > 16){
			playerRb.velocity = new Vector3(playerRb.velocity.x, -10, playerRb.velocity.z);
			transform.Translate(Vector3.up*-0.25f);
			playerAudio.PlayOneShot(boingsound, 1.0f);
		}
		//retry
		if(Input.GetKeyDown(KeyCode.R) && gameOver){
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Destroy(other.gameObject);
			statetxt.enabled = true;
			rtxt.enabled = true;
			statetxt.text = "YOU LOSE!";
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
			score++;
			if(score >= 30){
				statetxt.enabled = true;
				rtxt.enabled = true;
				statetxt.text = "YOU WIN!";
				gameOver = true;
			}

        }  else if (other.gameObject.CompareTag("ground")){
			playerRb.velocity = new Vector3(playerRb.velocity.x, 10, playerRb.velocity.z);
			transform.Translate(Vector3.up*0.25f);
			playerAudio.PlayOneShot(boingsound, 1.0f);
		}

    }

}
