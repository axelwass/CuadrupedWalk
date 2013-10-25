using UnityEngine;
using System.Collections;

public class JointMovementController : MonoBehaviour {
	

	
	MoveFunction function;
	HingeJoint joint;
	
	bool firstTime = true;
	
	// Use this for initialization
	void Start () {
		joint = (HingeJoint)GetComponent("HingeJoint");
	}
	
	public void setFunction(MoveFunction function){
		this.function = function;	
	}
	
	// Update is called once per frame
	public void updateState(float elapsedTime) {
		if(function != null && joint != null){
			JointSpring s = new JointSpring();
			s.targetPosition = function.evalAngle(elapsedTime);
			s.spring = function.evalStrength(elapsedTime);
			joint.spring = s;
			
		}
	}
}
