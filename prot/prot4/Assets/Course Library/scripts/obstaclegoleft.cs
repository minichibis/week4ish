/** Sam Carpenter
* Prototype 3
* makes obstacles move to the left, and maybe other thihngs too
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclegoleft : MonoBehaviour
{
    public float speed = 30f;
	public float leftbound = -15;
	private playergoboing script;
	private bool ding = true;
	
	void Start(){
		script = GameObject.FindGameObjectWithTag("Player").GetComponent<playergoboing>();
	}

    // Update is called once per frame
    void Update()
    {
        if(script.gameing) transform.Translate(Vector3.left * Time.deltaTime * speed);
		
		if(transform.position.x < leftbound && gameObject.CompareTag("evil")){
			Destroy(gameObject);
		}
		
		if(transform.position.x < 0 && gameObject.CompareTag("evil") && ding && script.gameing){
			script.score++;
			ding = false;
		}
    }
}
