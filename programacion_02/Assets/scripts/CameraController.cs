using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float frontBack = Input.GetAxis ("Horizontal");
		float leftRight = Input.GetAxis ("Vertical");

		float rotationLeftRight = Input.GetAxis ("Mouse X");
		float rotationUpDown = Input.GetAxis ("Mouse Y");

		Vector3 v = new Vector3 (frontBack, 0.0f, leftRight);
		player.GetComponent<Rigidbody> ().AddForce (v);

		Quaternion localRotation = transform.rotation * (Quaternion.AngleAxis (100 * rotationLeftRight * Time.deltaTime * Vector3.up) *
		                           Quaternion.AngleAxis (100 * rotationUpDown * Time.deltaTime, Vector3.left));
		
		transform.rotation = localRotation;

		
	}
}
