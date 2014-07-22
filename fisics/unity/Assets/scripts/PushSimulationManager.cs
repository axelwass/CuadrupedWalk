using UnityEngine;
using System.Collections;

public class PushSimulationManager : SimulationManager {
		
		
		
		
	GameObject testingCreature;
	MoveController tester;
	
	int testNumber = -1;
	float elapsedTime = 0;
	bool runingTests = false;
	
	bool nextTest = false;

	System.Collections.Generic.List<GenomeContainer> tests = new System.Collections.Generic.List<GenomeContainer>();
	
	
	private static PushSimulationManager instance;
	
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
	
	public override void runTests(System.Collections.Generic.List<GenomeContainer> tests){
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
			tester = (MoveController)testingCreature.GetComponent("MoveController");
			tester.setInitialSpeed(instance.velocidad_de_inicio);
			tester.testGenome(tests[testNumber].getGenome());
			//tests[testNumber].getGenome().print();
			elapsedTime=0;
			//Random.seed = 0;
			
		}
	}
	
	void endActualTest(){
		float evaluation = tester.getHeightEvaluation()  * tester.getSpeedEvaluation() * tester.centered() * tester.getMeanHeightEvaluation() * tester.getBodyRotation();
		evaluation = evaluation<0 || tester.getHeightEvaluation()<0 || tester.getSpeedEvaluation()<0 || tester.centered()<0 || tester.getMeanHeightEvaluation() < 0 || tester.getBodyRotation()<0? 0: evaluation;
		Debug.Log("test number: " + testNumber + "=  speed evaluation: " + tester.getSpeedEvaluation() + "-- height: " + tester.getHeightEvaluation()+ "-- meanheight: " + tester.getMeanHeightEvaluation() + "-- centered: " + tester.centered()+ "-- body rotation: " + tester.getBodyRotation() + "-- evaluation: " + evaluation);
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
			if(tester != null && testNumber >= 0 && elapsedTime > tiempo_simulacion){
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
		return "push";
	}

	public override string simulationOptions(){
		return "all";
	}

}
