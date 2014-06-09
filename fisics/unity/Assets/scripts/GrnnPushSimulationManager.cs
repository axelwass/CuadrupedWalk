using UnityEngine;
using System.Collections;

public class GrnnPushSimulationManager : SimulationManager {
	
	
	
	
	GameObject testingCreature;
	MoveController tester;
	
	int testNumber = -1;
	float elapsedTime = 0;
	bool runingTests = false;
	
	bool nextTest = false;
	
	System.Collections.Generic.List<GrnnData> tests = new System.Collections.Generic.List<GrnnData>();
	
	
	private static GrnnPushSimulationManager instance;
	
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
		Time.timeScale = timeScale;
		
	}
	
	public override bool isRuningTest(){
		return runingTests;	
	}

	public override void runTests(System.Collections.Generic.List<GenomeContainer> tests){}

	public void runGrnnTests(System.Collections.Generic.List<GrnnData> tests){
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
			tester.setInitialSpeed(instance.initialSpeed);
			tester.testGrnn(tests);
			elapsedTime=0;
			
		}
	}
	
	void endActualTest(){
		float evaluation = tester.getHeightEvaluation() +tester.getSpeedEvaluation() + tester.centered() + tester.getMeanHeightEvaluation();
		evaluation = evaluation<0 || tester.getHeightEvaluation()<0? 0: evaluation;
		Debug.Log("test number: " + testNumber + "=  speed evaluation: " + tester.getSpeedEvaluation() + "-- height: " + tester.getHeightEvaluation()+ "-- meanheight: " + tester.getMeanHeightEvaluation() + "-- centered: " + tester.centered() + "-- evaluation: " + evaluation);
//		tests[testNumber].setEvaluation(evaluation);	
		destroyTest();
		
	}
	
	
	
	
	// Update is called once per 
	void FixedUpdate () {
		if(nextTest){
			testNumber++;
			newTest();
			nextTest = false;
			
		}else{
			if(tester != null && testNumber >= 0 && elapsedTime > 10){
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
		return "grnn";
	}

	
	public override string simulationOptions(){
		return "grnn options";
	}
	
}
