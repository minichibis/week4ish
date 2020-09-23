using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningstuff : MonoBehaviour
{
	public GameObject obstacle;
	private Vector3 pos = new Vector3(35, 0, 0);
	
	private float startdelay = 2;
	private float repeatdelay = 2;
	
	private playergoboing script;
	
    // Start is called before the first frame update
    void Start()
    {
		script = GameObject.FindGameObjectWithTag("Player").GetComponent<playergoboing>();
        InvokeRepeating("mske", startdelay, repeatdelay);
    }
	
	void mske(){
		if(script.gameing) Instantiate(obstacle, pos, obstacle.transform.rotation);
	}
}
