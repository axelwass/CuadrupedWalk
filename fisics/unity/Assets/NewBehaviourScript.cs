using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
	public HingeJoint backLeft1;
	ArrayList moveFunctions;
	public HingeJoint backLeft2;
	public HingeJoint backLeftShoulder;
	
	public HingeJoint backRight1;
	public HingeJoint backRight2;
	public HingeJoint backRightShoulder;
	
	public HingeJoint frontLeft1;
	public HingeJoint frontLeft2;
	public HingeJoint frontLeftShoulder;
	
	public HingeJoint frontRight1;
	public HingeJoint frontRight2;
	public HingeJoint frontRightShoulder;
	
	public GameObject body;
	

	
	
	
	
	float timeElapsed;
	
	
	

	
	
	// Use this for initialization
	void Start () {
		moveFunctions = new ArrayList();
		moveFunctions.Add(new MoveFunction(backLeft1,40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(backLeft2,-40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(backLeftShoulder,10f,0.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(backRight1,40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(backRight2,-40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(backRightShoulder,10f,0.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontLeft1,40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontLeft2,-40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontLeftShoulder,10f,0.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontRight1,40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontRight2,-40f,1.2f,0f,1000f));
		moveFunctions.Add(new MoveFunction(frontRightShoulder,10f,0.2f,0f,1000f));
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(MoveFunction f in moveFunctions){
			f.update(timeElapsed);
		}
		timeElapsed+=Time.deltaTime;
	}
}
