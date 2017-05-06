using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : MonoBehaviour {
	new Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody>();	
	}
	
	void Update () {
		
	}

	void FixedUpdate() {
		rigidbody.AddForce(10 * Global.windDirection);
	}
}
