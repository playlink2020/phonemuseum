using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExample : MonoBehaviour {

	float rotate = 0;
	
	void Start() {
		Application.targetFrameRate = 300;
	}

	void FixedUpdate () {
		transform.position += transform.forward * Time.deltaTime * 10;
		rotate += Mathf.DeltaAngle(Mathf.Rad2Deg * transform.rotation.y, SteeringWheel.axis + Mathf.Rad2Deg * transform.rotation.y);
		transform.rotation = Quaternion.AngleAxis(rotate, Vector3.up);
	}
}
