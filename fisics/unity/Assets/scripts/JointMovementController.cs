using UnityEngine;
using System.Collections;

public class JointMovementController : MonoBehaviour {
	

	
	MoveFunction function;
	HingeJoint joint;
	
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
			if ( s.targetPosition < joint.limits.min ) {
				s.targetPosition = joint.limits.min;
			} else if ( s.targetPosition > joint.limits.max ) {
				s.targetPosition = joint.limits.max;
			};
			s.spring = function.evalStrength(elapsedTime);
			joint.spring = s;
			
		}
	}
}
