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
	

	
	float initialPositionX = 0;
	float initialPositionY = 0;
	float initialPositionZ = 0;
	
	
	float lastPositionX = 0;
	int updates = 0;
	float cumulatedError = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void testGenome(Genome genome){
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
		backLeft1.setFunction(new MoveFunction(genome.getAmplitude(0),genome.getPeriod(),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength()));
		backLeft2.setFunction(new MoveFunction(genome.getAmplitude(1),genome.getPeriod(),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength()));
		backLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(2),genome.getPeriod(),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength()));
		
		backRight1.setFunction(new MoveFunction(genome.getAmplitude(3),genome.getPeriod(),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength()));
		backRight2.setFunction(new MoveFunction(genome.getAmplitude(4),genome.getPeriod(),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength()));
		backRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(5),genome.getPeriod(),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength()));
		
		frontLeft1.setFunction(new MoveFunction(genome.getAmplitude(6),genome.getPeriod(),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength()));
		frontLeft2.setFunction(new MoveFunction(genome.getAmplitude(7),genome.getPeriod(),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength()));
		frontLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(8),genome.getPeriod(),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength()));
		
		frontRight1.setFunction(new MoveFunction(genome.getAmplitude(9),genome.getPeriod(),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength()));
		frontRight2.setFunction(new MoveFunction(genome.getAmplitude(10),genome.getPeriod(),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength()));
		frontRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(11),genome.getPeriod(),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength()));
		
		
		initialPositionX = body.transform.position.x;
		initialPositionY = body.transform.position.y;
		initialPositionZ = body.transform.position.z;
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
	
	}
	
	
	public float getAdvance(){
		
		return 	lastPositionX - initialPositionX;
	}
	
	public float getCuadraticError(){
		//Debug.Log("updates: " + updates);
		return cumulatedError/updates;	
	}
	

	
	// Update is called once every 0.02 sec.
	public void updateState(float elapsedTime) {
		if(elapsedTime<0){
			return;
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
	
		
		cumulatedError += body.transform.position.y < initialPositionY? Mathf.Pow((body.transform.position.y - initialPositionY),2):0;
		lastPositionX = body.transform.position.x;
		
		updates++;
	}
}
