using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class move : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	public GameObject goal;
	private Rigidbody rb;
	private List<GameObject> points;
	private Vector3 currentPointPos;
	private GameObject currentPoint;
	private int currentIndex;

	// Use this for initialization
	void Start () {
		currentIndex = 0;
		maxSpeed = 2;
		speed = 0.05f;
		rb  = gameObject.GetComponent<Rigidbody> ();


		points = new List<GameObject>();
		findPoints ();
		goal = GameObject.Find ("goal");

		currentPoint =  points[currentIndex];
		currentPointPos = currentPoint.GetComponent<Transform> ().position;
	}

	void findPoints() {
		IEnumerable<GameObject> c = GameObject.FindGameObjectsWithTag ("point");
		points.AddRange (c);

	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "goal") {
			Destroy (this.gameObject);
			//Destroy(col.gameObject);
		} else if (col.gameObject.CompareTag ("point")) {
			rb.AddForce(new Vector3(0,0,0));
			currentIndex += 1;
			currentPoint = points [currentIndex];
			Destroy(col.gameObject);
			print (currentIndex);
			print (currentPoint.name);
		}
	}

	// Update is called once per frame
	void Update () {
		//*
		//if (rb.position.x < goalPos.x) {

//		}
//		if (rb.position.z < goalPos.z) {
//			rb.AddForce(new Vector2(1,goalPos.y));
//		}
		//*
		if (rb.velocity.magnitude < maxSpeed) {		//Limits to maxspeed
			rb.AddForce (speed * new Vector3(currentPoint.GetComponent<Transform>().position.x, 0, currentPoint.GetComponent<Transform>().position.z));
		}
	}
}
