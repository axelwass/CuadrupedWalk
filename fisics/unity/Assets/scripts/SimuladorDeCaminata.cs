using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimuladorDeCaminata : Simulador {

	
	public bool V2 = true;
	private bool accelEval = false;
	public bool H = true;
	public bool K = true;
	public bool D = true;


	
	GameObject testingCreature;
	ControladorDeMovimientos tester;
	
	int testNumber = -1;
	float elapsedTime = 0;
	bool runingTests = false;
	
	bool nextTest = false;
	
	System.Collections.Generic.List<ContenedorGenoma> tests = new System.Collections.Generic.List<ContenedorGenoma>();
	
	
	private static SimuladorDeCaminata instance;
	
	void Awake(){
		if(instance != null){
			DestroyImmediate(this.gameObject);	
		}
		else{
			instance = this;	
			DontDestroyOnLoad(this);
		}
	}
	
	// Use this for initialization
	void Start () {
		Time.timeScale = escala_temporal;
		
	}
	
	public override bool isRuningTest(){
		return runingTests;	
	}
	
	public override void runTests(System.Collections.Generic.List<ContenedorGenoma> tests){
		if(runingTests){
			Debug.Log("No se pueden correr dos sries de tests al mismo tiempo");	
		}
		else{
			runingTests = true;
			this.tests = tests;
			
			testNumber = -1;
			nextTest=true;
			
		}
	}
	
	void destroyTest(){
		tester = null;
		//Destroy(testingCreature);
		//DestroyImmediate(testingCreature);
	}
	
	void newTest(){
		//Debug.Log("testnumber: " + testNumber);
		Application.LoadLevel(0);
	}
	
	void OnLevelWasLoaded (int level) {
		if (level == 0) {
			//Debug.Log("testnumber: " + testNumber);
			testingCreature = GameObject.FindWithTag("creature");//(GameObject)Instantiate(creaturePref);
			tester = (ControladorDeMovimientos)testingCreature.GetComponent("ControladorDeMovimientos");
			tester.testGenome(tests[testNumber].getGenome());
			//tests[testNumber].getGenome().print();
			elapsedTime=0;
			//Random.seed = 0;
			
		}
	}

	void endActualTest(){
		float evaluation = (V2?tester.getMeanWalkDirectionError(tiempo_simulacion):tester.getMeanSpeed()*10)* (this.K?tester.getCycleDiferenceEvaluation():1) * (this.H?tester.getMeanHeightEvaluation():1) * (this.accelEval?tester.getCumulaterAccelerationError():1) *(this.D?tester.getMeanRotationEvaluation():1);
		evaluation = tester.getMeanSpeed()<0 || evaluation<0 ? 0: evaluation;

		Debug.Log("Individuo: "  + testNumber + "= K:" + tester.getCycleDiferenceEvaluation().ToString("F2") + "-- D: " + tester.getMeanRotationEvaluation().ToString("F2") + "-- H: " + (tester.getMeanHeightEvaluation()).ToString("F2") + "-- V: " + (tester.getMeanSpeed()*10).ToString("F2") + "-- V2: " + (tester.getMeanWalkDirectionError(tiempo_simulacion)).ToString("F2") + "-- Aptitud: " + evaluation);
			tests[testNumber].setEvaluation(evaluation);	
			destroyTest();
			 
	}
	
	
	
	// Update is called once per 
	void FixedUpdate () {
		if(nextTest){
			testNumber++;
			newTest();
			nextTest = false;
			
		}else{
			if(tester != null && testNumber >= 0 && elapsedTime >tiempo_simulacion){
				endActualTest();
				//testNumber++;
				if(testNumber+1<tests.Count){
					nextTest =true;
				}
				else{
					tests = null;
					runingTests = false;
					Debug.Log("fin de generación");
				}
			}else{
				if(tester!=null){
					tester.updateState(elapsedTime);
				}
				elapsedTime+=Time.deltaTime;
			}
		}
	}

	public override string getName(){
		return "walk";
	}

	public override string simulationOptions(){
			return "CycleEval?: " + K + ", accelEval?: " + accelEval + ", heightEval?: " + H;
	}
}
