/** Sam Carpenter
* Prototype 3
* makes the player jump and such
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playergoboing : MonoBehaviour
{
	private Rigidbody b;
	public float jumpforce;
	public ForceMode jumptype;
	public float gravmod;
	
	public bool grounded = true;
	public bool gameing = true;
	
	public int score;
	
	public Text scoretxt;
	public Text gameo;
	
	private Animator animations;
	public ParticleSystem dirt;
	public ParticleSystem explo;
	
	public AudioClip crunchfx;
	public AudioClip boingfx;
	public AudioSource sfx;
	
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Rigidbody>();
		Physics.gravity = new Vector3(0, gravmod * -9.81f, 0);
		score = 0;
		gameing = true;
		grounded = true;
		scoretxt.text = score.ToString();
		gameo.enabled = false;
		
		animations = GetComponent<Animator>();
		animations.SetFloat("Speed_f", 1.0f);
		
		dirt.Play();
		explo.Stop();
    }

    // Update is called once per frame
    void Update()
    {
		scoretxt.text = score.ToString();
		
		if(Input.GetKeyDown(KeyCode.Space) && grounded && gameing){
			b.AddForce(new Vector3(0, jumpforce, 0), jumptype);
			grounded = false;
			
			dirt.Stop();
			animations.SetTrigger("Jump_trig");
			
			sfx.PlayOneShot(boingfx, 1.0f);
		} else if(Input.GetKeyDown(KeyCode.R) && !gameing){
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
    }
	
	private void OnCollisionEnter(Collision c){
		if(c.gameObject.CompareTag("evil")){
			gameing = false;
			gameo.enabled = true;
			
			animations.SetBool("Death_b", true);
			animations.SetInteger("DeathType_int", 1);
			dirt.Stop();
			explo.Play();
			
			sfx.PlayOneShot(crunchfx, 1.0f);
		}else if(c.gameObject.CompareTag("ground") && gameing){
			grounded = true;
			if(gameing){
				transform.position = new Vector3(0, 0.025f, 0);
				animations.SetTrigger("StopJump");
				dirt.Play();
			}
		}
	}
}
