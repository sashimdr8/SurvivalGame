using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Animator anim;
	private float inputH;
	private float inputV;
	public Rigidbody rbody;
	private bool run;
	// Use this for initialization

	//Camera Script
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;



	void Start () {
		anim = GetComponent<Animator> (); 
		rbody = GetComponent<Rigidbody> ();
		run = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("1")){
			anim.Play ("WAIT01", -1, 0f);
		}else if(Input.GetKeyDown("2")){
			anim.Play ("WAIT02", -1, 0f);
		}else if(Input.GetKeyDown("3")){
			anim.Play ("WAIT03", -1, 0f);
		}else if(Input.GetKeyDown("4")){
			anim.Play ("WAIT04", -1, 0f);
		}

		if(Input.GetMouseButtonDown(0)){
			int n = Random.Range (0, 2);
			if(n == 0)
				anim.Play ("DAMAGED00", -1, 0f);
			else
				anim.Play ("DAMAGED01", -1, 0f);
	    }

		if (Input.GetKey (KeyCode.LeftShift)) {
			run = true;
		} else {
			run = false;
		}
		if (Input.GetKey (KeyCode.Space)) {
			anim.SetBool ("jump", true);
		} else {
			anim.SetBool ("jump", false);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			anim.Play ("WALK00_F", -1, 0f);
		}



		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool("run", run);
		float moveX = inputH * 100f * Time.deltaTime;
		float moveZ = inputV * 800f * Time.deltaTime;


		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


		if (moveZ <= 0f) {
			moveX = 0f;
		} else if (run) {
			moveX *= 5f;
			moveZ *= 5f;
		}


		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKeyDown("w") && Input.GetAxis ("Mouse X") != 0.0) {
			moveX = yaw * 30f * Time.deltaTime;
		}
		rbody.velocity = new Vector3 (moveX, 0f, moveZ);




		//Camera Script








	}
}
