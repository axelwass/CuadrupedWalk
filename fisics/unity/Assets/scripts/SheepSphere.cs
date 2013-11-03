using UnityEngine;
using System.Collections;

public class SheepSphere : MonoBehaviour {
	
	public GameObject sheep1;
	public GameObject sheep2;

	// Use this for initialization
	void Start () {
		sheep1.rigidbody.AddForce(new Vector3(0, 0, -2), ForceMode.Impulse);
		sheep2.rigidbody.AddForce(new Vector3(0, 0, 2), ForceMode.Impulse);
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
