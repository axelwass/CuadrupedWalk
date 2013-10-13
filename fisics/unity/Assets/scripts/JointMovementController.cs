using UnityEngine;
using System.Collections;

public class JointMovementController : MonoBehaviour {
	

	
	MoveFunction function;
	HingeJoint joint;
	
	
	float enlapsedTime = 0;
	// Use this for initialization
	void Start () {
		joint = (HingeJoint)GetComponent("HingeJoint");
	}
	
	public void setFunction(MoveFunction function){
		this.function = function;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(function != null){
			enlapsedTime += Time.deltaTime;
			
			JointSpring s = new JointSpring();
			s.targetPosition = function.evalAngle(enlapsedTime);
			s.spring = function.evalStrength(enlapsedTime);
			joint.spring = s;
			
		}
	}
}
