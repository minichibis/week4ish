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
    }

    // Update is called once per frame
    void Update()
    {
		scoretxt.text = score.ToString();
		
		if(Input.GetKeyDown(KeyCode.Space) && grounded && gameing){
			b.AddForce(new Vector3(0, jumpforce, 0), jumptype);
			grounded = false;
		} else if(Input.GetKeyDown(KeyCode.R) && !gameing){
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
    }
	
	private void OnCollisionEnter(Collision c){
		if(c.gameObject.CompareTag("evil")){
			gameing = false;
			gameo.enabled = true;
		}else if(c.gameObject.CompareTag("ground")){
			grounded = true;
			if(gameing)transform.position = new Vector3(0, 0.025f, 0);
		}
	}
}
