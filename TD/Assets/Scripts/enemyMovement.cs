using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyMovement : MonoBehaviour {

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
		speed = 3f;
		rb  = gameObject.GetComponent<Rigidbody> ();

		goal = GameObject.Find ("goal");
		points = new List<GameObject>();
		findPoints ();

		currentPoint =  points[currentIndex];
		currentPointPos = currentPoint.GetComponent<Transform> ().position;
	}

	void findPoints() {
		IEnumerable<GameObject> c = GameObject.FindGameObjectsWithTag ("point");
		foreach(GameObject go in c) {
			points.Add(go);
		}
		points.Sort (delegate(GameObject one, GameObject two) {
			return one.name.CompareTo (two.name);
		});

		//Lastly add goal as the last point to go to.
		points.Add (goal);

	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "goal") {
			Destroy (this.gameObject);
			//"Life lost" todo
		} else if (col.gameObject.CompareTag ("point")) {
			currentIndex += 1;
			if(currentIndex==points.Count) {
				currentPoint = goal;
			} else {
				currentPoint = points [currentIndex];
			}
		}
	}

	void Update () {

			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, step);

	}
}


