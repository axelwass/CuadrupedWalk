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
		Time.timeScale = timeScale;
		
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
			testingCreature = GameObject.Find("testingCreature");//(GameObject)Instantiate(creaturePref);
			tester = (MoveController)testingCreature.GetComponent("MoveController");
			tester.testGenome(tests[testNumber].getGenome(),initialSpeed);
			//tests[testNumber].getGenome().print();
			elapsedTime=-0.02f;
			//Random.seed = 0;
			
		}
	}
	
	void endActualTest(){
		float evaluation = (1-Mathf.Pow(tester.getHeight()-tester.getInitialHeight(),2)) *(1 - tester.getSpeed()/initialSpeed.magnitude) * tester.centered();
		evaluation = evaluation<0 || tester.getHeight()<0? 0: evaluation;
		Debug.Log("test number: " + testNumber + "=  speed: " + tester.getSpeed() + "-- height: " + tester.getHeight() + "-- centered: " + tester.centered() + "-- evaluation: " + evaluation);
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
			if(tester != null && testNumber >= 0 && elapsedTime > (Mathf.PI*2/tests[testNumber].getGenome().getPeriod(0)) + (tests[testNumber].getGenome().getFunctionType() == FunctioT.Partida?(Mathf.PI*2/tests[testNumber].getGenome().getPeriod(1)):0)){
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
}
