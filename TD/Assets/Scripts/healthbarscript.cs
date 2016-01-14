using UnityEngine;
using System.Collections;

public class healthbarscript : MonoBehaviour {

	public float maxHP = 100;
	public float currentHP = 100;

	float hpBarLength;
	float percentHP;
	public Texture2D hpBar;

	//Vector3 targetPos;
	// Use this for initialization
	void Start () {
		//Camera cam = GetComponent<Camera> ();
		//hpBarSize = new Vector2 (10, 10);
		//hpBarLocation = cam.WorldToScreenPoint (transform.position);
		//targetPos = new Vector3();
	}
	void takeDMG() {
		currentHP -= 10.0f;
	}

	void OnGUI(){
		if (currentHP > 0) {
			Vector3 targetPos = Camera.main.WorldToScreenPoint (transform.position);
			targetPos.y = Screen.height - targetPos.y;

			GUI.DrawTexture (new Rect (targetPos.x, targetPos.y - 20, 60, 20), hpBar);
			//GUI.Box(new Rect (targetPos.x, targetPos.y-20, 60, 20), currentHP + "/"    + maxHP);
			GUI.Box (new Rect (targetPos.x, targetPos.y - 20, 60, 20), currentHP + "");
		} else {
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		

		percentHP = currentHP / maxHP;
		hpBarLength = percentHP*100;

		//For testing purposes
		if(Input.GetKeyDown("h")) {
			currentHP -= 10.0f;
		}

		if(Input.GetKeyDown("j")) {
			currentHP += 10.0f;
		}

	}
}