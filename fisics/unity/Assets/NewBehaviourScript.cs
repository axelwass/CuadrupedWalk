using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
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
	
	
	float timeElapsed;
	
	float initialPositionX = 0;
	float lastPositionX = 0;
	
	float initialPositionY = 0;
	float initialPositionZ = 0;
	int updates = 0;
	float cumulatedError = 0;
	
	// Use this for initialization
	void Start () {
		
		backLeft1.setFunction(new MoveFunction(40f,1.2f,0f,1000f));
		backLeft2.setFunction(new MoveFunction(-40f,1.2f,0f,1000f));
		backLeftShoulder.setFunction(new MoveFunction(10f,0.2f,0f,1000f));
		
		backRight1.setFunction(new MoveFunction(40f,1.2f,0f,1000f));
		backRight2.setFunction(new MoveFunction(-40f,1.2f,0f,1000f));
		backRightShoulder.setFunction(new MoveFunction(10f,0.2f,0f,1000f));
		
		frontLeft1.setFunction(new MoveFunction(40f,1.2f,0f,1000f));
		frontLeft2.setFunction(new MoveFunction(-40f,1.2f,0f,1000f));
		frontLeftShoulder.setFunction(new MoveFunction(10f,0.2f,0f,1000f));
		
		frontRight1.setFunction(new MoveFunction(40f,1.2f,0f,1000f));
		frontRight2.setFunction(new MoveFunction(-40f,1.2f,0f,1000f));
		frontRightShoulder.setFunction(new MoveFunction(10f,0.2f,0f,1000f));
		
		testGenome(new Genome());
		
		initialPositionX = body.transform.position.x;
		initialPositionY = body.transform.position.y;
		initialPositionZ = body.transform.position.z;
	}
	
	void testGenome(Genome genome){
		backLeft1.setFunction(new MoveFunction(genome.getAmplitude(0),genome.getPeriod(),genome.getFase(0),genome.getStrength()));
		backLeft2.setFunction(new MoveFunction(genome.getAmplitude(1),genome.getPeriod(),genome.getFase(1),genome.getStrength()));
		backLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(2),genome.getPeriod(),genome.getFase(2),genome.getStrength()));
		
		backRight1.setFunction(new MoveFunction(genome.getAmplitude(3),genome.getPeriod(),genome.getFase(3),genome.getStrength()));
		backRight2.setFunction(new MoveFunction(genome.getAmplitude(4),genome.getPeriod(),genome.getFase(4),genome.getStrength()));
		backRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(5),genome.getPeriod(),genome.getFase(5),genome.getStrength()));
		
		frontLeft1.setFunction(new MoveFunction(genome.getAmplitude(6),genome.getPeriod(),genome.getFase(6),genome.getStrength()));
		frontLeft2.setFunction(new MoveFunction(genome.getAmplitude(7),genome.getPeriod(),genome.getFase(7),genome.getStrength()));
		frontLeftShoulder.setFunction(new MoveFunction(genome.getAmplitude(8),genome.getPeriod(),genome.getFase(8),genome.getStrength()));
		
		frontRight1.setFunction(new MoveFunction(genome.getAmplitude(9),genome.getPeriod(),genome.getFase(9),genome.getStrength()));
		frontRight2.setFunction(new MoveFunction(genome.getAmplitude(10),genome.getPeriod(),genome.getFase(10),genome.getStrength()));
		frontRightShoulder.setFunction(new MoveFunction(genome.getAmplitude(11),genome.getPeriod(),genome.getFase(11),genome.getStrength()));	
	}
	
	
	float getAdvance(){
		return 	lastPositionX - initialPositionX;
	}
	
	float getCuadraticError(){
		return cumulatedError/updates;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		cumulatedError += Mathf.Pow((body.transform.position.y - initialPositionY) + (body.transform.position.z - initialPositionZ),2);
		lastPositionX = body.transform.position.x;
		
		Debug.Log("error: " + getCuadraticError() + "-- advance: " + getAdvance());
		
		updates++;
		timeElapsed+=Time.deltaTime;
	}
}
