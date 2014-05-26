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

	public bool twoLegs = false;

	public GameObject body;
	

	Vector3 initialSpeed;


	float initialPositionYSholders = 0;

	float lastVelocity = 0;
	float acceleration;
	//float initialPositionX = 0;
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
	float cumulatedWalkDirectionError = 0;

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

	float cumulatedAccelerationError = 0;

	int cycle = 1;

	float dominantPeriod;

	// Use this for initialization
	void Start () {
		
	}
	
	public void testGenome(Genome genome){
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);

		
		GenomeToFunctions translator = new GenomeToFunctions(genome);
		
		backLeft1.setFunction(translator.backLeft1);
		backLeft2.setFunction(translator.backLeft2);
		backLeftShoulder.setFunction(translator.backLeftShoulder);

		if (!twoLegs) {
				frontLeft1.setFunction (translator.frontLeft1);
				frontLeft2.setFunction (translator.frontLeft2);
				frontLeftShoulder.setFunction (translator.frontLeftShoulder);
		}

		backRight1.setFunction (translator.backRight1);
		backRight2.setFunction (translator.backRight2);
		backRightShoulder.setFunction (translator.backRightShoulder);

		if (!twoLegs) {
				frontRight1.setFunction (translator.frontRight1);
				frontRight2.setFunction (translator.frontRight2);
				frontRightShoulder.setFunction (translator.frontRightShoulder);
		}

		period = translator.secondPeriod;
		dominantPeriod = translator.dominantPeriod;


//		Probar poner todas last fases iguales! y tambien todos los periodos (en rodillas con rodillas, hombros con hombros, etc)
//		Mandar pelicula x email con el mejor y con momentos previos
		// Mas fourier o una especia de campana chata.
		// Probar tres estructuras distintas para ver distintas formas de caminar : reptil, perro, girafa.
		// hacer informe del modelo exitoso.



		//initialPosition = body.transform.position;
		if(!twoLegs){
			initialPosition = (body.transform.position + backLeft2.transform.position + backRight2.transform.position +
						frontLeft2.transform.position + frontRight2.transform.position) / 5;
		}else{
			initialPosition = (body.transform.position + backLeft2.transform.position + backRight2.transform.position) / 3;

		}

		initialRotation = body.transform.rotation;
		//Debug.Log("initial angles: " + initialRotation);
		//initialPositionX = body.transform.position.x;
		if(!twoLegs){
			initialPositionYSholders = Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y,
		                                     frontLeftShoulder.transform.position.y,frontRightShoulder.transform.position.y );
		}else{
			initialPositionYSholders = Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y);
		}
		//initialPositionZ = body.transform.position.z;
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
	
	}

	public void testGrnn(System.Collections.Generic.List<GrnnData> data){
		backLeft1.setFunction(new GrnnFunction(BodyParts.BackLeft1,data,body));
		backLeft2.setFunction(new GrnnFunction(BodyParts.BackLeft2,data,body));
		backLeftShoulder.setFunction(new GrnnFunction(BodyParts.BackLeftShoulder,data,body));
		
		frontLeft1.setFunction(new GrnnFunction(BodyParts.FrontLeft1,data,body));
		frontLeft2.setFunction(new GrnnFunction(BodyParts.FrontLeft2,data,body));
		frontLeftShoulder.setFunction(new GrnnFunction(BodyParts.FrontLeftShoulder,data,body));
		
		backRight1.setFunction (new GrnnFunction(BodyParts.BackRight1,data,body));
		backRight2.setFunction (new GrnnFunction(BodyParts.BackRight2,data,body));
		backRightShoulder.setFunction (new GrnnFunction(BodyParts.BackRightShoulder,data,body));
		
		frontRight1.setFunction (new GrnnFunction(BodyParts.FrontRight1,data,body));
		frontRight2.setFunction (new GrnnFunction(BodyParts.FrontRight2,data,body));
		frontRightShoulder.setFunction (new GrnnFunction(BodyParts.FrontRightShoulder,data,body));

		
		//initialPosition = body.transform.position;
		if(!twoLegs){
			initialPosition = (body.transform.position + backLeft2.transform.position + backRight2.transform.position +
			                   frontLeft2.transform.position + frontRight2.transform.position) / 5;
		}else{
			initialPosition = (body.transform.position + backLeft2.transform.position + backRight2.transform.position) / 3;
			
		}
		
		initialRotation = body.transform.rotation;
		//Debug.Log("initial angles: " + initialRotation);
		//initialPositionX = body.transform.position.x;
		if(!twoLegs){
			initialPositionYSholders = Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y,
			                                     frontLeftShoulder.transform.position.y,frontRightShoulder.transform.position.y );
		}else{
			initialPositionYSholders = Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y);
		}
	}

	public float centered(){
		float xAverage;
		float zAverage;
		if(!twoLegs){
			xAverage = (backLeft2.rigidbody.transform.position.x + backRight2.rigidbody.transform.position.x + frontLeft2.rigidbody.transform.position.x + frontRight2.rigidbody.transform.position.x) / 4;
		
			zAverage = (backLeft2.rigidbody.transform.position.z + backRight2.rigidbody.transform.position.z + frontLeft2.rigidbody.transform.position.z + frontRight2.rigidbody.transform.position.z) / 4;
		}else{
			xAverage = (backLeft2.rigidbody.transform.position.x + backRight2.rigidbody.transform.position.x) / 2;
			
			zAverage = (backLeft2.rigidbody.transform.position.z + backRight2.rigidbody.transform.position.z) / 2;

		}
		return 1 - Mathf.Sqrt(Mathf.Pow (body.rigidbody.transform.position.x - xAverage, 2) + Mathf.Pow (body.rigidbody.transform.position.z - zAverage, 2));
			
	}

	public float getAdvanceEvaluation(){
		return (suposedPostionx - lastPositionX)/suposedPostionx;
	}

	public float getMeanWalkDirectionError(float simulationTime){
		return 1-((cumulatedWalkDirectionError/updates)/(0.51f *walkDirection.x * simulationTime));
	}

	public float getHeightEvaluation(){
		
		return 1- (Mathf.Abs (Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y,
		                                frontLeftShoulder.transform.position.y,frontRightShoulder.transform.position.y ) - initialPositionYSholders)/initialPositionYSholders);
	}

	public float getMeanHeightEvaluation(){
		return 1- (cumulatedErrorHeight/updates)/initialPositionYSholders;
	}


	public float getMeanRotationEvaluation(){
		return (1 - ((cumulatedErrorRotation / updates) / 180f));
	}

	public float getCycleDiferenceEvaluation(){
		if(!twoLegs){
			return (1 - ((cumulatedStepRotationsDiference / (cycle-1))/450f));
		}else{
			return (1 - ((cumulatedStepRotationsDiference / (cycle-1))/250f));
		}
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
			lastVelocity = body.rigidbody.velocity.x;
			firstTime = false;	
		}
				backLeft1.updateState (elapsedTime);
				backLeft2.updateState (elapsedTime);
				backLeftShoulder.updateState (elapsedTime);
		
				backRight1.updateState (elapsedTime);
				backRight2.updateState (elapsedTime);
				backRightShoulder.updateState (elapsedTime);
		if(!twoLegs){
				frontLeft1.updateState (elapsedTime);
				frontLeft2.updateState (elapsedTime);
				frontLeftShoulder.updateState (elapsedTime);
		
				frontRight1.updateState (elapsedTime);
				frontRight2.updateState (elapsedTime);
				frontRightShoulder.updateState (elapsedTime);
		}
	
		suposedPostionx = (initialPosition + elapsedTime * walkDirection).x;
		cumulatedWalkDirectionError += Mathf.Abs(body.transform.position.x - (initialPosition + elapsedTime * walkDirection).x);
		acceleration = (body.rigidbody.velocity.x - lastVelocity)/0.02f;
		if(acceleration < -0.02f){
			cumulatedAccelerationError-=acceleration;
		}
		if(lastVelocity < 0.2){
			cumulatedAccelerationError += 0.02f;
		}

		float step_error = Mathf.Pow((body.transform.position.x - (initialPosition + elapsedTime * walkDirection).x),2) + Mathf.Pow((body.transform.position.z - (initialPosition + elapsedTime * walkDirection).z),2);
		//Debug.Log("step_error: " + (step_error>1?step_error:0));
		cumulatedErrorPosition += body.transform.position.y < initialPosition.y? Mathf.Pow((body.transform.position.y - initialPosition.y),4):0;
		cumulatedErrorPosition += step_error>1?step_error:0;
		//cumulatedErrorPosition += (body.transform.position - (initialPosition + elapsedTime * walkDirection)).magnitude;
		cumulatedErrorRotation += Quaternion.Angle(body.transform.rotation,initialRotation);
		if(!twoLegs){
		cumulatedErrorHeight += Mathf.Abs (Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y,
		                                             frontLeftShoulder.transform.position.y,frontRightShoulder.transform.position.y ) - initialPositionYSholders);
		}else{
			cumulatedErrorHeight += Mathf.Abs (Mathf.Min(backLeftShoulder.transform.position.y,backRightShoulder.transform.position.y) - initialPositionYSholders);
		}

		if (elapsedTime > (2 * Mathf.PI * cycle / dominantPeriod) +  (2 * Mathf.PI / period) ) {

			
			Quaternion RotationNewBody = body.transform.rotation;
			Quaternion RotationNewbackLeft1 = Quaternion.Euler(backLeft1.transform.rotation.eulerAngles/* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackLeft2 = Quaternion.Euler(backLeft2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackRight1 = Quaternion.Euler(backRight1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackRight2 = Quaternion.Euler(backRight2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );

			Quaternion RotationNewfrontRight1 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontRight2 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontLeft1 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontLeft2 = Quaternion.Euler(0,0,0);;
			if(!twoLegs){
				RotationNewfrontRight1 = Quaternion.Euler(frontRight1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontRight2 = Quaternion.Euler(frontRight2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontLeft1 = Quaternion.Euler(frontLeft1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontLeft2 = Quaternion.Euler(frontLeft2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			}
			if(!twoLegs){
			stepRotationsDiference = Quaternion.Angle(RotationNewBody,RotationOldBody)+ 
				Quaternion.Angle(RotationNewbackLeft1,RotationOldbackLeft1)+ 
				Quaternion.Angle(RotationNewbackLeft2,RotationOldbackLeft2)+ 
				Quaternion.Angle(RotationNewbackRight1,RotationOldbackRight1)+
				Quaternion.Angle(RotationNewbackRight2,RotationOldbackRight2)+
				Quaternion.Angle(RotationNewfrontRight1,RotationOldfrontRight1)+
				Quaternion.Angle(RotationNewfrontRight2,RotationOldfrontRight2)+
				Quaternion.Angle(RotationNewfrontLeft1,RotationOldfrontLeft1)+
				Quaternion.Angle(RotationNewfrontLeft2,RotationOldfrontLeft2);
			}else{
				stepRotationsDiference = Quaternion.Angle(RotationNewBody,RotationOldBody)+ 
					Quaternion.Angle(RotationNewbackLeft1,RotationOldbackLeft1)+ 
						Quaternion.Angle(RotationNewbackLeft2,RotationOldbackLeft2)+ 
						Quaternion.Angle(RotationNewbackRight1,RotationOldbackRight1)+
						Quaternion.Angle(RotationNewbackRight2,RotationOldbackRight2);
			}
			cumulatedStepRotationsDiference += stepRotationsDiference;

			RotationOldBody = RotationNewBody;
			RotationOldbackLeft1 = RotationNewbackLeft1;
			RotationOldbackLeft2 = RotationNewbackLeft2;
			RotationOldbackRight1 = RotationNewbackRight1;
			RotationOldbackRight2 = RotationNewbackRight2;
			if(!twoLegs){
				RotationOldfrontRight1 = RotationNewfrontRight1;
				RotationOldfrontRight2 = RotationNewfrontRight2;
				RotationOldfrontLeft1 = RotationNewfrontLeft1;
				RotationOldfrontLeft2 = RotationNewfrontLeft2;
			}
			//Debug.Log("diferencias: " + stepRotationsDiference);
			cycle++;
		}
		if(!twoLegs){
		lastPositionX = (body.transform.position.x + backLeft2.transform.position.x + backRight2.transform.position.x +
				frontLeft2.transform.position.x + frontRight2.transform.position.x) / 5;
		}else{
			lastPositionX = (body.transform.position.x + backLeft2.transform.position.x + backRight2.transform.position.x) / 3;
		}
		lastTime = elapsedTime;

		if ( !initialPositionSetted && ( elapsedTime > (2 * Mathf.PI / period) ) ) {

			
			RotationOldBody = body.transform.rotation;
			RotationOldbackLeft1 = Quaternion.Euler(backLeft1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackLeft2 = Quaternion.Euler(backLeft2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackRight1 = Quaternion.Euler(backRight1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackRight2 = Quaternion.Euler(backRight2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			if(!twoLegs){
				RotationOldfrontRight1 = Quaternion.Euler(frontRight1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontRight2 = Quaternion.Euler(frontRight2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontLeft1 = Quaternion.Euler(frontLeft1.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontLeft2 = Quaternion.Euler(frontLeft2.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			}
			if(!twoLegs){
			initialPositionAfterFirstPeriod = ( body.transform.position + backLeft2.transform.position + backRight2.transform.position +
			frontLeft2.transform.position + frontRight2.transform.position) / 5;
			}else{
				initialPositionAfterFirstPeriod = ( body.transform.position + backLeft2.transform.position + backRight2.transform.position) / 3;
			}
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

	public float getCumulaterAccelerationError(){
		return 1000/cumulatedAccelerationError;
	}
		
}
