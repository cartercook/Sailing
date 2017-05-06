using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {
	public Transform sail;

	new Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {

	}

	void FixedUpdate() {
		// add wind propulsion

		//Debug.DrawLine(sail.position, sail.position + sail.up, Color.red);
		//Debug.DrawLine(sail.position, sail.position + Global.windDirection, Color.blue);
		//Debug.Log(Mathf.Abs(Vector3.Dot(Global.windDirection, sail.up)));

		rigidbody.AddRelativeForce(40 * Vector3.forward * Mathf.Abs(Vector3.Dot(Global.windDirection, sail.up)));

		float rotateSpeed = 160;

		// controls
		if (Input.GetKey(KeyCode.RightArrow)) {
			// left hand rule: up = rotate to the right
			rigidbody.AddTorque(rotateSpeed * Vector3.up);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			//rotate left
			rigidbody.AddTorque(rotateSpeed * Vector3.down);
		} else {
			// stop turning
			//rigidbody.AddTorque(rigidbody.ang);
		}
	}
}
