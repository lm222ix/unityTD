using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public GameObject Enemy;
	public Vector3 positionToSpawn;
	public float howManyToSpawn;


	// Use this for initialization
	void Start () {
		GameObject spawn = GameObject.Find ("spawn");
		positionToSpawn = new Vector3 (spawn.transform.position.x, 
		                               spawn.transform.position.y,
		                               spawn.transform.position.z);
		howManyToSpawn = 10;
		
		StartCoroutine (spawnGuys ());

	}


	public IEnumerator spawnGuys() {
		for (int i = 0; i<howManyToSpawn; i++) {
			yield return new WaitForSeconds(1);		//1 second spawnrate. Tweak
			Instantiate (Enemy);
			//Enemy.transform.position.Set (positionToSpawn.x,positionToSpawn.y,positionToSpawn.z);
			Enemy.transform.position = positionToSpawn;
		}

	}

	
	// Update is called once per frame
	void Update () {

	}
}
