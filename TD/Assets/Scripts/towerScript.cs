using UnityEngine;
using System.Collections;

public class towerScript : MonoBehaviour {

	float nextAttack;
	float attackRate;

	public GameObject projectile;

	float projectileSpeed;
	// Use this for initialization
	void Start () {
		attackRate = 1;
		nextAttack = 0;
		projectileSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 200);
		int i = 0;
		while (i < hitColliders.Length) {
			if (hitColliders [i].tag.Equals ("enemy")) {
				attack (hitColliders [i]);
			} else {
			}
			i++;
		}
	}
		
	void attack (Collider target){

		if (Time.time > nextAttack) {

			nextAttack = Time.time + attackRate;

			GameObject g = Instantiate(projectile,transform.position,transform.rotation) as GameObject;
			g.GetComponent<Rigidbody> ().AddForce (g.transform.forward * projectileSpeed);

			target.SendMessage ("takeDMG", 5f);
			//Debug.Log("Attack Function Called");
		}
	}


	/*function Update () {
		// Put this in your update function
		if (Input.GetButtonDown("Fire1")) {

			// Instantiate the projectile at the position and rotation of this transform
			var clone : Transform;
			clone = Instantiate(projectile, transform.position, transform.rotation);

			// Add force to the cloned object in the object's forward direction
			clone.rigidbody.AddForce(clone.transform.forward * shootForce);
		}
	}*/
}
