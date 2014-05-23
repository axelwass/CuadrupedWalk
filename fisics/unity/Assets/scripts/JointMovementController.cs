using UnityEngine;
using System.Collections;
using System.IO;

public class JointMovementController : MonoBehaviour {
	

	
	MoveFunction function;
	HingeJoint joint;

	public bool showAngle = false;
	StreamWriter writer;

	// Use this for initialization
	void Start () {
		joint = (HingeJoint)GetComponent("HingeJoint");
		if(showAngle && TestCreature.getInstance() != null){
			writer = new StreamWriter(TestCreature.getInstance().creatureFilePath + "." + this.gameObject.transform.parent.gameObject.name + "." + this.gameObject.name,false);
			writer.Close();
		}
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

			if(showAngle){
				writer = new StreamWriter(TestCreature.getInstance().creatureFilePath + "." + this.gameObject.transform.parent.gameObject.name + "." + this.gameObject.name,true);
				writer.WriteLine(s.targetPosition + ", " + joint.angle);

				writer.Close();
			}
			s.spring = function.evalStrength(elapsedTime);
			joint.spring = s;
			
		}
	}
}
