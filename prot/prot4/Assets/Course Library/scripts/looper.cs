/** Sam Carpenter
* Prototype 3
* moves backdrop pieces
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looper : MonoBehaviour
{
	public float leftbound = 56.4f;
	public float speed = 20f;
	
	private Vector3 start;
	
	private playergoboing script;
	
    // Start is called before the first frame update
    void Start()
    {
		start = transform.position;
		leftbound = start.x - leftbound;
		script = GameObject.FindGameObjectWithTag("Player").GetComponent<playergoboing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.gameing)transform.Translate(Vector3.left * Time.deltaTime * speed);
		
		if(transform.position.x < leftbound){
			transform.position = start;
		}
    }
}
