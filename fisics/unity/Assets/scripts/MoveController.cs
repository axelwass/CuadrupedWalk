using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
	
	public JointMovementController backLeft1;
	public JointMovementController backLeft2;
	public JointMovementController backLeftShoulder;
	
	public JointMovementController backRight1;
	public JointMovementController backRight2;
	public JointMovementController backRightShoulder;
	
	public JointMovementController frontLeft1;
	public JointMovementController frontLeft2;
	public JointMovementController frontLeftShoulder;
	
	public JointMovementController frontRight1;
	public JointMovementController frontRight2;
	public JointMovementController frontRightShoulder;
	
	public GameObject body;
	

	
	//float initialPositionX = 0;
	//float initialPositionY = 0;
	//float initialPositionZ = 0;
	Vector3 initialPosition;
	Quaternion initialRotation;
	
	float lastPositionX = 0;
	int updates = 0;
	//float cumulatedError = 0;
	float cumulatedErrorPosition = 0;
	float cumulatedErrorRotation = 0;
	
	bool firstTime = true;
	
	public Vector3 walkDirection = new Vector3(1,0,0);
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void testGenome(Genome genome){
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
		backLeft1.setFunction(new MoveFunction(genome.getAmplitude(0),genome.getPeriod(),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength()));
		backLeft2.setFunction(new MoveFunction(genome.getAmplitude(1),genome.getPeriod(),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength()));
		backLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(2),genome.getPeriod(),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength()));
		
		frontLeft1.setFunction(new MoveFunction(genome.getAmplitude(3),genome.getPeriod(),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength()));
		frontLeft2.setFunction(new MoveFunction(genome.getAmplitude(4),genome.getPeriod(),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength()));
		frontLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(5),genome.getPeriod(),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength()));
		
		backRight1.setFunction(new MoveFunction(genome.getAmplitude(0),genome.getPeriod(),genome.getFase(0)+ Mathf.PI,genome.getCenterAngle(0),genome.getStrength()));
		backRight2.setFunction(new MoveFunction(genome.getAmplitude(1),genome.getPeriod(),genome.getFase(1)+ Mathf.PI,genome.getCenterAngle(1),genome.getStrength()));
		backRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(2),genome.getPeriod(),genome.getFase(2)+ Mathf.PI,genome.getCenterAngle(2),genome.getStrength()));
		
		frontRight1.setFunction(new MoveFunction(genome.getAmplitude(3),genome.getPeriod(),genome.getFase(3)+ Mathf.PI,genome.getCenterAngle(3),genome.getStrength()));
		frontRight2.setFunction(new MoveFunction(genome.getAmplitude(4),genome.getPeriod(),genome.getFase(4)+ Mathf.PI,genome.getCenterAngle(4),genome.getStrength()));
		frontRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(5),genome.getPeriod(),genome.getFase(5)+ Mathf.PI,genome.getCenterAngle(5),genome.getStrength()));
		
		
		initialPosition = body.transform.position;
		initialRotation = body.transform.rotation;
		//Debug.Log("initial angles: " + initialRotation);
		//initialPositionX = body.transform.position.x;
		//initialPositionY = body.transform.position.y;
		//initialPositionZ = body.transform.position.z;
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
	
	}
	
	
	public float getAdvance(){
		
		return 	lastPositionX - initialPosition.x;
	}
	
	public float getCuadraticErrorPosition(){
		//Debug.Log("updates: " + updates);
		return cumulatedErrorPosition/updates;	
	}
	
	public float getCuadraticErrorRotation(){
		//Debug.Log("updates: " + updates);
		return cumulatedErrorRotation/updates;	
	}
	

	
	// Update is called once every 0.02 sec.
	public void updateState(float elapsedTime) {
		if(elapsedTime<0){
			return;
		}
		
		if(firstTime){
			body.rigidbody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
			firstTime = false;	
		}
		
		backLeft1.updateState(elapsedTime);
		backLeft2.updateState(elapsedTime);
		backLeftShoulder.updateState(elapsedTime);
		
		backRight1.updateState(elapsedTime);
		backRight2.updateState(elapsedTime);
		backRightShoulder.updateState(elapsedTime);
		
		frontLeft1.updateState(elapsedTime);
		frontLeft2.updateState(elapsedTime);
		frontLeftShoulder.updateState(elapsedTime);
		
		frontRight1.updateState(elapsedTime);
		frontRight2.updateState(elapsedTime);
		frontRightShoulder.updateState(elapsedTime);
	
		float step_error = Mathf.Pow((body.transform.position.x - (initialPosition + elapsedTime * walkDirection).x),2) + Mathf.Pow((body.transform.position.z - (initialPosition + elapsedTime * walkDirection).z),2);
		//Debug.Log("step_error: " + (step_error>1?step_error:0));
		cumulatedErrorPosition += body.transform.position.y < initialPosition.y? Mathf.Pow((body.transform.position.y - initialPosition.y),4):0;
		cumulatedErrorPosition += step_error>1?step_error:0;
		//cumulatedErrorPosition += (body.transform.position - (initialPosition + elapsedTime * walkDirection)).magnitude;
		cumulatedErrorRotation += Quaternion.Angle(body.transform.rotation,initialRotation);
		lastPositionX = body.transform.position.x;
		
		updates++;
	}
}
