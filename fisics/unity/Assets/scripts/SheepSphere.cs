using UnityEngine;
using System.Collections;
using System.IO;

public class SheepSphere : MonoBehaviour {
	
	public GameObject sheep1;
	public GameObject sheep2;
	public int force;
	StreamWriter writer;

	// Use this for initialization
	void Start () {
		sheep1.rigidbody.AddForce(new Vector3(0, 0, -force), ForceMode.Impulse);
		sheep2.rigidbody.AddForce(new Vector3(0, 0, force), ForceMode.Impulse);
		
       writer = new StreamWriter("Test.txt");
	   writer.WriteLine("Time \t Sheep1(z) \t Sheep2(z)");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time < 5){
	   writer.WriteLine(Time.time + "\t" + sheep1.transform.position.z + "\t" + sheep2.transform.position.z);
		print(Time.time + "\t" + sheep1.transform.position.z + "\t" + sheep2.transform.position.z);
		} else {
			writer.Close ();
		}
	}
}
