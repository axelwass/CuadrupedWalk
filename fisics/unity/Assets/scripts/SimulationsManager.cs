using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimulationsManager : MonoBehaviour {

	
	public GameObject creaturePref;
	public float testingTime = 10;
	public float timeScale = 1;
	
	GameObject testingCreature;
	MoveController tester;
	
	int testNumber = -1;
	float elapsedTime = 0;
	bool runingTests = false;
	
	bool nextTest = false;
	
	System.Collections.Generic.List<GenomeContainer> tests = new System.Collections.Generic.List<GenomeContainer>();
	
	// Use this for initialization
	void Start () {
		Time.timeScale = timeScale;
		
	}
	
	public bool isRuningTest(){
		return runingTests;	
	}
	
	public void runTests(System.Collections.Generic.List<GenomeContainer> tests){
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
		DestroyImmediate(testingCreature);
	}
	
	void newTest(int i){
		testingCreature = (GameObject)Instantiate(creaturePref);
		tester = (MoveController)testingCreature.GetComponent("MoveController");
		tester.testGenome(tests[i].getGenome());
		tests[i].getGenome().print();
		elapsedTime=-0.02f;
		Random.seed = 0;
	}
	
	void endActualTest(){
			float evaluation = tester.getAdvance()<0? 0: tester.getAdvance();// / (1 + tester.getCuadraticError());
			Debug.Log("test number: " + testNumber + "= error: " + tester.getCuadraticError() + "-- advance: " + tester.getAdvance() + "-- evaluation: " + evaluation);
			tests[testNumber].setEvaluation(evaluation);	
			destroyTest();
			
	}
	
	
	
	// Update is called once per 
	void FixedUpdate () {
		if(nextTest){
			testNumber++;
			newTest(testNumber);
			nextTest = false;
			
		}else{
			if(tester != null && testNumber >= 0 && elapsedTime >testingTime){
				endActualTest();
				testNumber++;
				if(testNumber<tests.Count){
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
