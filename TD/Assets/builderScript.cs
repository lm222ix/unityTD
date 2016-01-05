using UnityEngine;
using System.Collections;

public class builderScript : MonoBehaviour {
	
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 10.0f;
	//vertical position of the gameobject
	private float yAxis;
	
	void Start(){
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
	}


	// Update is called once per frame
	void Update () {

		//targetPoint = currentPosition;

		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray;
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray,out hit))
			{
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the click / tap position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on touch position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log(endPoint);
			}
		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
		}
	}
	

}