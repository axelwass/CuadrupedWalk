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
	
	Vector3 initialSpeed;
	
	//float initialPositionX = 0;
	float initialPositionY = 0;
	//float initialPositionZ = 0;
	Vector3 initialPosition;
	Vector3 initialPositionAfterFirstPeriod;
	float timeAfterFirstPeriod;
	bool initialPositionSetted;
	float period;

	Quaternion initialRotation;
	
	float lastPositionX = 0;
	float lastTime = 0;

	int updates = 0;
	//float cumulatedError = 0;
	float cumulatedErrorPosition = 0;
	float cumulatedErrorRotation = 0;
	float cumulatedErrorHeight = 0;

	float suposedPostionx =0;
	
	bool firstTime = true;
	
	public Vector3 walkDirection = new Vector3(1,0,0);

	Quaternion RotationOldBody = Quaternion.Euler(0,0,0);
	Quaternion RotationOldbackLeft1 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldbackLeft2 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldbackRight1 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldbackRight2 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldfrontLeft1 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldfrontLeft2 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldfrontRight1 = Quaternion.Euler(0,0,0);
	Quaternion RotationOldfrontRight2 = Quaternion.Euler(0,0,0);

	float stepRotationsDiference;

	float cumulatedStepRotationsDiference;

	int cycle = 1;

	float dominantPeriod;

	// Use this for initialization
	void Start () {
		
	}
	
	public void testGenome(Genome genome){
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);


		switch (genome.getFunctionType()==FunctioT.Olistic? genome.getSelector() : genome.getFunctionType()) {
		case FunctioT.Classic:
			backLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));

			backRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0)));
			backRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0)));
			backRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0)));
			
			frontRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0)));
			frontRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0)));
			frontRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0)));

			period = genome.getPeriod(0);

			break;
		case FunctioT.FaseSync:
			backLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));

			backRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (0), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (1), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (2), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (3), genome.getPeriod (0), genome.getFase (3) + Mathf.PI, genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (4), genome.getPeriod (0), genome.getFase (4) + Mathf.PI, genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (5), genome.getPeriod (0), genome.getFase (5) + Mathf.PI, genome.getCenterAngle (5), genome.getStrength (0)));

			period = genome.getPeriod(0);

			break;
		case FunctioT.FaseSuperSync:
			backLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1.setFunction(new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2.setFunction(new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder.setFunction(new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (0), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (1), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (2), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1.setFunction (new moveFunctionClassic (genome.getAmplitude (3), genome.getPeriod (0), genome.getFase (0), genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2.setFunction (new moveFunctionClassic (genome.getAmplitude (4), genome.getPeriod (0), genome.getFase (1), genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder.setFunction (new moveFunctionClassic (genome.getAmplitude (5), genome.getPeriod (0), genome.getFase (2), genome.getCenterAngle (5), genome.getStrength (0)));

			period = genome.getPeriod(0);

			break;
		case FunctioT.Fourier2:
			backLeft1.setFunction(new MoveFunctionFourier2(genome.getAmplitude(0),genome.getAmplitude(6),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2.setFunction(new MoveFunctionFourier2(genome.getAmplitude(1),genome.getAmplitude(7),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder.setFunction(new MoveFunctionFourier2(genome.getAmplitude(2),genome.getAmplitude(8),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1.setFunction(new MoveFunctionFourier2(genome.getAmplitude(3),genome.getAmplitude(9),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2.setFunction(new MoveFunctionFourier2(genome.getAmplitude(4),genome.getAmplitude(10),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder.setFunction(new MoveFunctionFourier2(genome.getAmplitude(5),genome.getAmplitude(11),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (0),genome.getAmplitude(6), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (1),genome.getAmplitude(7), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (2),genome.getAmplitude(8), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (3),genome.getAmplitude(9), genome.getPeriod (0), genome.getFase (3) + Mathf.PI, genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (4),genome.getAmplitude(10), genome.getPeriod (0), genome.getFase (4) + Mathf.PI, genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder.setFunction (new MoveFunctionFourier2 (genome.getAmplitude (5),genome.getAmplitude(11), genome.getPeriod (0), genome.getFase (5) + Mathf.PI, genome.getCenterAngle (5), genome.getStrength (0)));

			period = genome.getPeriod(0);

			break;
		case FunctioT.Partida:
			backLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			backRight1.setFunction (new MoveFunctionPartida (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0),genome.getAmplitude(18),genome.getPeriod(1),genome.getFase(18),genome.getCenterAngle(18),genome.getStrength(1)));
			backRight2.setFunction (new MoveFunctionPartida (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(19),genome.getCenterAngle(19),genome.getStrength(1)));
			backRightShoulder.setFunction (new MoveFunctionPartida (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0),genome.getAmplitude(20),genome.getPeriod(1),genome.getFase(20),genome.getCenterAngle(20),genome.getStrength(1)));
			
			frontRight1.setFunction (new MoveFunctionPartida (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0),genome.getAmplitude(21),genome.getPeriod(1),genome.getFase(21),genome.getCenterAngle(21),genome.getStrength(1)));
			frontRight2.setFunction (new MoveFunctionPartida (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0),genome.getAmplitude(22),genome.getPeriod(1),genome.getFase(22),genome.getCenterAngle(22),genome.getStrength(1)));
			frontRightShoulder.setFunction (new MoveFunctionPartida (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0),genome.getAmplitude(23),genome.getPeriod(1),genome.getFase(23),genome.getCenterAngle(23),genome.getStrength(1)));

			period = genome.getPeriod(1);

			break;
		case FunctioT.Partida_FaseSync:
			backLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));

			backRight1.setFunction(new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6) + Mathf.PI,genome.getCenterAngle(6),genome.getStrength(1)));
			backRight2.setFunction(new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7) + Mathf.PI,genome.getCenterAngle(7),genome.getStrength(1)));
			backRightShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8) + Mathf.PI,genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontRight1.setFunction(new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9) + Mathf.PI,genome.getCenterAngle(9),genome.getStrength(1)));
			frontRight2.setFunction(new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10) + Mathf.PI,genome.getCenterAngle(10),genome.getStrength(1)));
			frontRightShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11) + Mathf.PI,genome.getCenterAngle(11),genome.getStrength(1)));
			
			period = genome.getPeriod(1);
			
			break;
		case FunctioT.Partida_Classic_FaseSync:
			backLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1.setFunction(new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2.setFunction(new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1.setFunction(new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2.setFunction(new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1.setFunction(new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2.setFunction(new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder.setFunction(new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			period = genome.getPeriod(1);
			
			break;
		case FunctioT.PartidaFinalConstante:
			backLeft1.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backLeft2.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backLeftShoulder.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontLeft1.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontLeft2.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontLeftShoulder.setFunction(new MoveFunctionPartidaFinalConstante(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			backRight1.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0),genome.getAmplitude(18),genome.getPeriod(1),genome.getFase(18),genome.getCenterAngle(18),genome.getStrength(1)));
			backRight2.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(19),genome.getCenterAngle(19),genome.getStrength(1)));
			backRightShoulder.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0),genome.getAmplitude(20),genome.getPeriod(1),genome.getFase(20),genome.getCenterAngle(20),genome.getStrength(1)));
			
			frontRight1.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0),genome.getAmplitude(21),genome.getPeriod(1),genome.getFase(21),genome.getCenterAngle(21),genome.getStrength(1)));
			frontRight2.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0),genome.getAmplitude(22),genome.getPeriod(1),genome.getFase(22),genome.getCenterAngle(22),genome.getStrength(1)));
			frontRightShoulder.setFunction (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0),genome.getAmplitude(23),genome.getPeriod(1),genome.getFase(23),genome.getCenterAngle(23),genome.getStrength(1)));
			
			period = genome.getPeriod(1);
			
			break;

		}

		dominantPeriod = genome.getPeriod (0);
		
		//initialPosition = body.transform.position;

		initialPosition = (body.transform.position + backLeft2.transform.position + backRight2.transform.position +
						frontLeft2.transform.position + frontRight2.transform.position) / 5;


		initialRotation = body.transform.rotation;
		//Debug.Log("initial angles: " + initialRotation);
		//initialPositionX = body.transform.position.x;
		initialPositionY = body.rigidbody.transform.position.y;
		//initialPositionZ = body.transform.position.z;
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
	
	}

	public float centered(){
		
		float xAverage = (backLeft2.rigidbody.transform.position.x + backRight2.rigidbody.transform.position.x + frontLeft2.rigidbody.transform.position.x + frontRight2.rigidbody.transform.position.x) / 4;
		
		float zAverage = (backLeft2.rigidbody.transform.position.z + backRight2.rigidbody.transform.position.z + frontLeft2.rigidbody.transform.position.z + frontRight2.rigidbody.transform.position.z) / 4;
		
		return 1 - Mathf.Sqrt(Mathf.Pow (body.rigidbody.transform.position.x - xAverage, 2) + Mathf.Pow (body.rigidbody.transform.position.z - zAverage, 2));
			
	}

	public float getAdvanceEvaluation(){
		return (suposedPostionx - lastPositionX)/suposedPostionx;
	}

	public float getHeightEvaluation(){
		return 1- (Mathf.Abs(body.rigidbody.transform.position.y - initialPosition.y)/initialPosition.y);
	}

	public float getMeanHeightEvaluation(){
		return 1- (cumulatedErrorHeight/updates)/initialPositionY;
	}


	public float getRotationEvaluation(){
		return (1 - ((cumulatedErrorRotation / updates) / 180f));
	}

	public float getCycleDiferenceEvaluation(){
		return (1 - ((cumulatedStepRotationsDiference / (cycle-1))/450f));
	}

	public float getHeight(){
		return body.rigidbody.transform.position.y;
	}

	public float getInitialHeight(){
		return initialPositionY;
	}
	
	public float getAdvance(){
		//return 	lastPositionX - initialPosition.x;
		return lastPositionX - initialPositionAfterFirstPeriod.x;
	}

	public float getMeanSpeed(){
		return (lastPositionX - initialPositionAfterFirstPeriod.x)/(lastTime-timeAfterFirstPeriod);
	}

	public float getCuadraticErrorPosition(){
		//Debug.Log("updates: " + updates);
		return cumulatedErrorPosition/updates;	
	}
	
	public float getCuadraticErrorRotation(){
		//Debug.Log("updates: " + updates);
		return cumulatedErrorRotation/updates;	
	}
	
	public float getSpeedEvaluation(){
		return 1- body.rigidbody.velocity.magnitude/initialSpeed.magnitude;
	}
	
	// Update is called once every 0.02 sec.
	public void updateState(float elapsedTime) {
				if (elapsedTime < 0) {
						return;
				}

		if(firstTime){
			body.rigidbody.velocity = initialSpeed;//AddForce(new Vector3(0, 0, 20), ForceMode.Impulse); //TODO body.rigidbody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
			firstTime = false;	
		}
				backLeft1.updateState (elapsedTime);
				backLeft2.updateState (elapsedTime);
				backLeftShoulder.updateState (elapsedTime);
		
				backRight1.updateState (elapsedTime);
				backRight2.updateState (elapsedTime);
				backRightShoulder.updateState (elapsedTime);
		
				frontLeft1.updateState (elapsedTime);
				frontLeft2.updateState (elapsedTime);
				frontLeftShoulder.updateState (elapsedTime);
		
				frontRight1.updateState (elapsedTime);
				frontRight2.updateState (elapsedTime);
				frontRightShoulder.updateState (elapsedTime);
	
		suposedPostionx = (initialPosition + elapsedTime * walkDirection).x;
		float step_error = Mathf.Pow((body.transform.position.x - (initialPosition + elapsedTime * walkDirection).x),2) + Mathf.Pow((body.transform.position.z - (initialPosition + elapsedTime * walkDirection).z),2);
		//Debug.Log("step_error: " + (step_error>1?step_error:0));
		cumulatedErrorPosition += body.transform.position.y < initialPosition.y? Mathf.Pow((body.transform.position.y - initialPosition.y),4):0;
		cumulatedErrorPosition += step_error>1?step_error:0;
		//cumulatedErrorPosition += (body.transform.position - (initialPosition + elapsedTime * walkDirection)).magnitude;
		cumulatedErrorRotation += Quaternion.Angle(body.transform.rotation,initialRotation);
		cumulatedErrorHeight += Mathf.Abs (body.rigidbody.transform.position.y - initialPositionY);


		if (elapsedTime > (2 * Mathf.PI * cycle / dominantPeriod) +  (2 * Mathf.PI / period) ) {

			
			Quaternion RotationNewBody = body.transform.rotation;
			Quaternion RotationNewbackLeft1 = Quaternion.Euler(backLeft1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewbackLeft2 = Quaternion.Euler(backLeft2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewbackRight1 = Quaternion.Euler(backRight1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewbackRight2 = Quaternion.Euler(backRight2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewfrontRight1 = Quaternion.Euler(frontRight1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewfrontRight2 = Quaternion.Euler(frontRight2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewfrontLeft1 = Quaternion.Euler(frontLeft1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			Quaternion RotationNewfrontLeft2 = Quaternion.Euler(frontLeft2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );

			stepRotationsDiference = Quaternion.Angle(RotationNewBody,RotationOldBody)+ 
				Quaternion.Angle(RotationNewbackLeft1,RotationOldbackLeft1)+ 
				Quaternion.Angle(RotationNewbackLeft2,RotationOldbackLeft2)+ 
				Quaternion.Angle(RotationNewbackRight1,RotationOldbackRight1)+
				Quaternion.Angle(RotationNewbackRight2,RotationOldbackRight2)+
				Quaternion.Angle(RotationNewfrontRight1,RotationOldfrontRight1)+
				Quaternion.Angle(RotationNewfrontRight2,RotationOldfrontRight2)+
				Quaternion.Angle(RotationNewfrontLeft1,RotationOldfrontLeft1)+
				Quaternion.Angle(RotationNewfrontLeft2,RotationOldfrontLeft2);

			cumulatedStepRotationsDiference += stepRotationsDiference;

			RotationOldBody = RotationNewBody;
			RotationOldbackLeft1 = RotationNewbackLeft1;
			RotationOldbackLeft2 = RotationNewbackLeft2;
			RotationOldbackRight1 = RotationNewbackRight1;
			RotationOldbackRight2 = RotationNewbackRight2;
			RotationOldfrontRight1 = RotationNewfrontRight1;
			RotationOldfrontRight2 = RotationNewfrontRight2;
			RotationOldfrontLeft1 = RotationNewfrontLeft1;
			RotationOldfrontLeft2 = RotationNewfrontLeft2;

			//Debug.Log("diferencias: " + stepRotationsDiference);
			cycle++;
		}

		lastPositionX = (body.transform.position.x + backLeft2.transform.position.x + backRight2.transform.position.x +
				frontLeft2.transform.position.x + frontRight2.transform.position.x) / 5;
		lastTime = elapsedTime;

		if ( !initialPositionSetted && ( elapsedTime > (2 * Mathf.PI / period) ) ) {

			
			RotationOldBody = body.transform.rotation;
			RotationOldbackLeft1 = Quaternion.Euler(backLeft1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldbackLeft2 = Quaternion.Euler(backLeft2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldbackRight1 = Quaternion.Euler(backRight1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldbackRight2 = Quaternion.Euler(backRight2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldfrontRight1 = Quaternion.Euler(frontRight1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldfrontRight2 = Quaternion.Euler(frontRight2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldfrontLeft1 = Quaternion.Euler(frontLeft1.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );
			RotationOldfrontLeft2 = Quaternion.Euler(frontLeft2.transform.rotation.eulerAngles - body.transform.rotation.eulerAngles );

			initialPositionAfterFirstPeriod = ( body.transform.position + backLeft2.transform.position + backRight2.transform.position +
			frontLeft2.transform.position + frontRight2.transform.position) / 5;
			timeAfterFirstPeriod = elapsedTime;
			initialPositionSetted = true;	
		}

		updates++;
	}
	
	public void setInitialSpeed(Vector3 initial){
		initialSpeed = initial;
	}
	
	public Vector3 getInitialSpeed(){
		return initialSpeed;
	}
		
}
