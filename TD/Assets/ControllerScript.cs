using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public GameObject Enemy;
	public Vector3 positionToSpawn;
	public int howManyToSpawn;


	// Use this for initialization
	void Start () {
		GameObject spawn = GameObject.Find ("spawn");
		positionToSpawn = new Vector3 (spawn.transform.position.x, 
		                               spawn.transform.position.y,
		                               spawn.transform.position.z);
		howManyToSpawn = 3;
		spawnGuys();	
	}


	void spawnGuys() {
	//	for (int i = 0; i<5; i++) {
			Instantiate (Enemy);
			//Enemy.transform.position.Set (positionToSpawn.x,positionToSpawn.y,positionToSpawn.z);
			Enemy.transform.position = positionToSpawn;
		

	}
	
	// Update is called once per frame
	void Update () {

	}
}
