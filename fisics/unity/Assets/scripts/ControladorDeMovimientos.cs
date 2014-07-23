using UnityEngine;
using System.Collections;
using System.IO;

public class ControladorDeMovimientos : MonoBehaviour {
	
	public ControladorDeMovimientoDeArticulacion antebrazo_izquierdo_tracero;
	public ControladorDeMovimientoDeArticulacion brazo_izquierdo_tracero;
	public ControladorDeMovimientoDeArticulacion hombro_izquierdo_tracero;
	
	public ControladorDeMovimientoDeArticulacion antebrazo_derecho_tracero;
	public ControladorDeMovimientoDeArticulacion brazo_derecho_tracero;
	public ControladorDeMovimientoDeArticulacion hombro_derecho_tracero;
	
	public ControladorDeMovimientoDeArticulacion antebrazo_izquierdo_delantero;
	public ControladorDeMovimientoDeArticulacion brazo_izquierdo_delantero;
	public ControladorDeMovimientoDeArticulacion hombro_izquierdo_delantero;
	
	public ControladorDeMovimientoDeArticulacion antebrazo_derecho_delantero;
	public ControladorDeMovimientoDeArticulacion brazo_derecho_delantero;
	public ControladorDeMovimientoDeArticulacion hombro_derecho_delantero;

	public bool dos_piernas = false;

	public GameObject torso;
	

	public bool imprimir_V2 = false;
	public bool imprimir_H = false;
	public bool imprimir_D = false;

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
	
	public Vector3 Velocidad_objetivo = new Vector3(1,0,0);

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

	StreamWriter walkDirectionWriter;
	StreamWriter heightWriter;
	StreamWriter errorRotationWriter;
	// Use this for initialization
	void Start () {
		if(imprimir_V2 && Probador.getInstance() != null){
			if(imprimir_V2){
				walkDirectionWriter = new StreamWriter(Probador.getInstance().archivo + ".V2",false);
				walkDirectionWriter.Close();
			}
			if(imprimir_H){
				heightWriter = new StreamWriter(Probador.getInstance().archivo + ".H",false);
				heightWriter.Close();
			}
			if(imprimir_D){
				errorRotationWriter = new StreamWriter(Probador.getInstance().archivo + ".D",false);
				errorRotationWriter.Close();
			}
		}
	}
	
	public void testGenome(Genoma genome){
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);

		
		GenomaAFuncion translator = new GenomaAFuncion(genome);
		
		antebrazo_izquierdo_tracero.setFunction(translator.backLeft1);
		brazo_izquierdo_tracero.setFunction(translator.backLeft2);
		hombro_izquierdo_tracero.setFunction(translator.backLeftShoulder);

		if (!dos_piernas) {
				antebrazo_izquierdo_delantero.setFunction (translator.frontLeft1);
				brazo_izquierdo_delantero.setFunction (translator.frontLeft2);
				hombro_izquierdo_delantero.setFunction (translator.frontLeftShoulder);
		}

		antebrazo_derecho_tracero.setFunction (translator.backRight1);
		brazo_derecho_tracero.setFunction (translator.backRight2);
		hombro_derecho_tracero.setFunction (translator.backRightShoulder);

		if (!dos_piernas) {
				antebrazo_derecho_delantero.setFunction (translator.frontRight1);
				brazo_derecho_delantero.setFunction (translator.frontRight2);
				hombro_derecho_delantero.setFunction (translator.frontRightShoulder);
		}

		period = translator.secondPeriod;
		dominantPeriod = translator.dominantPeriod;


//		Probar poner todas last fases iguales! y tambien todos los periodos (en rodillas con rodillas, hombros con hombros, etc)
//		Mandar pelicula x email con el mejor y con momentos previos
		// Mas fourier o una especia de campana chata.
		// Probar tres estructuras distintas para ver distintas formas de caminar : reptil, perro, girafa.
		// hacer informe del modelo exitoso.



		//initialPosition = body.transform.position;
		if(!dos_piernas){
			initialPosition = (torso.transform.position + brazo_izquierdo_tracero.transform.position + brazo_derecho_tracero.transform.position +
						brazo_izquierdo_delantero.transform.position + brazo_derecho_delantero.transform.position) / 5;
		}else{
			initialPosition = (torso.transform.position + brazo_izquierdo_tracero.transform.position + brazo_derecho_tracero.transform.position) / 3;

		}

		initialRotation = torso.transform.rotation;
		//Debug.Log("initial angles: " + initialRotation);
		//initialPositionX = body.transform.position.x;
		if(!dos_piernas){
			initialPositionYSholders = Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y,
		                                     hombro_izquierdo_delantero.transform.position.y,hombro_derecho_delantero.transform.position.y );
		}else{
			initialPositionYSholders = Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y);
		}
		//initialPositionZ = body.transform.position.z;
		//Debug.Log("x: " + body.transform.position.x + "y: " + body.transform.position.y + "z: " + body.transform.position.z);
	
	}

	public float centered(){
		float xAverage;
		float zAverage;
		if(!dos_piernas){
			xAverage = (brazo_izquierdo_tracero.rigidbody.transform.position.x + brazo_derecho_tracero.rigidbody.transform.position.x + brazo_izquierdo_delantero.rigidbody.transform.position.x + brazo_derecho_delantero.rigidbody.transform.position.x) / 4;
		
			zAverage = (brazo_izquierdo_tracero.rigidbody.transform.position.z + brazo_derecho_tracero.rigidbody.transform.position.z + brazo_izquierdo_delantero.rigidbody.transform.position.z + brazo_derecho_delantero.rigidbody.transform.position.z) / 4;
		}else{
			xAverage = (brazo_izquierdo_tracero.rigidbody.transform.position.x + brazo_derecho_tracero.rigidbody.transform.position.x) / 2;
			
			zAverage = (brazo_izquierdo_tracero.rigidbody.transform.position.z + brazo_derecho_tracero.rigidbody.transform.position.z) / 2;

		}
		return 1 - Mathf.Sqrt(Mathf.Pow (torso.rigidbody.transform.position.x - xAverage, 2) + Mathf.Pow (torso.rigidbody.transform.position.z - zAverage, 2));
			
	}

	public float getAdvanceEvaluation(){
		return (suposedPostionx - lastPositionX)/suposedPostionx;
	}

	public float getMeanWalkDirectionError(float simulationTime){
		return 1-((cumulatedWalkDirectionError/updates)/(0.51f *Velocidad_objetivo.x * simulationTime));
	}

	public float getHeightEvaluation(){
		
		return 1- (Mathf.Abs (Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y,
		                                hombro_izquierdo_delantero.transform.position.y,hombro_derecho_delantero.transform.position.y ) - initialPositionYSholders)/initialPositionYSholders);
	}

	public float getMeanHeightEvaluation(){
		return 1- (cumulatedErrorHeight/updates)/initialPositionYSholders;
	}


	public float getMeanRotationEvaluation(){
		return (1 - ((cumulatedErrorRotation / updates) / 180f));
	}

	public float getCycleDiferenceEvaluation(){
		if(!dos_piernas){
			return (1 - ((cumulatedStepRotationsDiference / (cycle==1?1:cycle-1))/450f));
		}else{
			return (1 - ((cumulatedStepRotationsDiference / (cycle==1?1:cycle-1))/250f));
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
		float speedEvalLineal = 1- torso.rigidbody.velocity.magnitude/initialSpeed.magnitude;
		return speedEvalLineal<0.5f?speedEvalLineal*0.75f:0.75f + (speedEvalLineal-0.5f)*0.5f;
	}
	
	public float getBodyRotation(){
		return 1 - torso.transform.rotation.eulerAngles.x/180;
	}
	
	// Update is called once every 0.02 sec.
	public void updateState(float elapsedTime) {
				if (elapsedTime < 0) {
						return;
				}

		if(firstTime){
			torso.rigidbody.velocity = initialSpeed;//AddForce(new Vector3(0, 0, 20), ForceMode.Impulse); //TODO body.rigidbody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
			lastVelocity = torso.rigidbody.velocity.x;
			firstTime = false;	
		}
				antebrazo_izquierdo_tracero.updateState (elapsedTime);
				brazo_izquierdo_tracero.updateState (elapsedTime);
				hombro_izquierdo_tracero.updateState (elapsedTime);
		
				antebrazo_derecho_tracero.updateState (elapsedTime);
				brazo_derecho_tracero.updateState (elapsedTime);
				hombro_derecho_tracero.updateState (elapsedTime);
		if(!dos_piernas){
				antebrazo_izquierdo_delantero.updateState (elapsedTime);
				brazo_izquierdo_delantero.updateState (elapsedTime);
				hombro_izquierdo_delantero.updateState (elapsedTime);
		
				antebrazo_derecho_delantero.updateState (elapsedTime);
				brazo_derecho_delantero.updateState (elapsedTime);
				hombro_derecho_delantero.updateState (elapsedTime);
		}
	
		suposedPostionx = (initialPosition + elapsedTime * Velocidad_objetivo).x;
		cumulatedWalkDirectionError += Mathf.Abs(torso.transform.position.x - (initialPosition + elapsedTime * Velocidad_objetivo).x);
		if(Probador.getInstance() != null){
			if(imprimir_V2){
				walkDirectionWriter = new StreamWriter(Probador.getInstance().archivo + ".V2",true);
				walkDirectionWriter.WriteLine(torso.transform.position.x + ", " + (initialPosition + elapsedTime * Velocidad_objetivo).x);
				walkDirectionWriter.Close();
			}
			if(imprimir_H){
				heightWriter = new StreamWriter(Probador.getInstance().archivo + ".H",true);
				heightWriter.WriteLine(Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y,
				                                 hombro_izquierdo_delantero.transform.position.y,hombro_derecho_delantero.transform.position.y ) + ", " + initialPositionYSholders);
				heightWriter.Close();
			}
			if(imprimir_D){
				errorRotationWriter = new StreamWriter(Probador.getInstance().archivo + ".D",true);
				errorRotationWriter.WriteLine( torso.transform.rotation.eulerAngles.y);
				errorRotationWriter.Close();
			}
		}
		acceleration = (torso.rigidbody.velocity.x - lastVelocity)/0.02f;
		if(acceleration < -0.02f){
			cumulatedAccelerationError-=acceleration;
		}
		if(lastVelocity < 0.2){
			cumulatedAccelerationError += 0.02f;
		}

		float step_error = Mathf.Pow((torso.transform.position.x - (initialPosition + elapsedTime * Velocidad_objetivo).x),2) + Mathf.Pow((torso.transform.position.z - (initialPosition + elapsedTime * Velocidad_objetivo).z),2);

		//Debug.Log("step_error: " + (step_error>1?step_error:0));
		cumulatedErrorPosition += torso.transform.position.y < initialPosition.y? Mathf.Pow((torso.transform.position.y - initialPosition.y),4):0;
		cumulatedErrorPosition += step_error>1?step_error:0;
		//cumulatedErrorPosition += (body.transform.position - (initialPosition + elapsedTime * walkDirection)).magnitude;
		cumulatedErrorRotation += Quaternion.Angle(torso.transform.rotation,initialRotation);
		if(!dos_piernas){
		cumulatedErrorHeight += Mathf.Abs (Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y,
		                                             hombro_izquierdo_delantero.transform.position.y,hombro_derecho_delantero.transform.position.y ) - initialPositionYSholders);
		}else{
			cumulatedErrorHeight += Mathf.Abs (Mathf.Min(hombro_izquierdo_tracero.transform.position.y,hombro_derecho_tracero.transform.position.y) - initialPositionYSholders);
		}

		if (elapsedTime > (2 * Mathf.PI * cycle / dominantPeriod) +  (2 * Mathf.PI / period) ) {

			
			Quaternion RotationNewBody = torso.transform.rotation;
			Quaternion RotationNewbackLeft1 = Quaternion.Euler(antebrazo_izquierdo_tracero.transform.rotation.eulerAngles/* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackLeft2 = Quaternion.Euler(brazo_izquierdo_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackRight1 = Quaternion.Euler(antebrazo_derecho_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			Quaternion RotationNewbackRight2 = Quaternion.Euler(brazo_derecho_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );

			Quaternion RotationNewfrontRight1 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontRight2 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontLeft1 = Quaternion.Euler(0,0,0);;
			Quaternion RotationNewfrontLeft2 = Quaternion.Euler(0,0,0);;
			if(!dos_piernas){
				RotationNewfrontRight1 = Quaternion.Euler(antebrazo_derecho_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontRight2 = Quaternion.Euler(brazo_derecho_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontLeft1 = Quaternion.Euler(antebrazo_izquierdo_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationNewfrontLeft2 = Quaternion.Euler(brazo_izquierdo_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			}
			if(!dos_piernas){
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
			if(!dos_piernas){
				RotationOldfrontRight1 = RotationNewfrontRight1;
				RotationOldfrontRight2 = RotationNewfrontRight2;
				RotationOldfrontLeft1 = RotationNewfrontLeft1;
				RotationOldfrontLeft2 = RotationNewfrontLeft2;
			}
			//Debug.Log("diferencias: " + stepRotationsDiference);
			cycle++;
		}
		if(!dos_piernas){
		lastPositionX = (torso.transform.position.x + brazo_izquierdo_tracero.transform.position.x + brazo_derecho_tracero.transform.position.x +
				brazo_izquierdo_delantero.transform.position.x + brazo_derecho_delantero.transform.position.x) / 5;
		}else{
			lastPositionX = (torso.transform.position.x + brazo_izquierdo_tracero.transform.position.x + brazo_derecho_tracero.transform.position.x) / 3;
		}
		lastTime = elapsedTime;

		if ( !initialPositionSetted && ( elapsedTime > (2 * Mathf.PI / period) ) ) {

			
			RotationOldBody = torso.transform.rotation;
			RotationOldbackLeft1 = Quaternion.Euler(antebrazo_izquierdo_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackLeft2 = Quaternion.Euler(brazo_izquierdo_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackRight1 = Quaternion.Euler(antebrazo_derecho_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			RotationOldbackRight2 = Quaternion.Euler(brazo_derecho_tracero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			if(!dos_piernas){
				RotationOldfrontRight1 = Quaternion.Euler(antebrazo_derecho_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontRight2 = Quaternion.Euler(brazo_derecho_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontLeft1 = Quaternion.Euler(antebrazo_izquierdo_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
				RotationOldfrontLeft2 = Quaternion.Euler(brazo_izquierdo_delantero.transform.rotation.eulerAngles /* - body.transform.rotation.eulerAngles*/ );
			}
			if(!dos_piernas){
			initialPositionAfterFirstPeriod = ( torso.transform.position + brazo_izquierdo_tracero.transform.position + brazo_derecho_tracero.transform.position +
			brazo_izquierdo_delantero.transform.position + brazo_derecho_delantero.transform.position) / 5;
			}else{
				initialPositionAfterFirstPeriod = ( torso.transform.position + brazo_izquierdo_tracero.transform.position + brazo_derecho_tracero.transform.position) / 3;
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
