using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimulationsManager : MonoBehaviour {

	
	public GameObject creaturePref;
	public float testingTime = 10;
	public float timeScale = 1;
	
	GameObject testingCreature;
	MoveController tester;
	
	int testNumber = 0;
	
	bool runingTests = false;
	
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
			
			testNumber = 0;
			
			newTest(testNumber);
		}
	}
	
	void destroyTest(){
		tester = null;
		Destroy(testingCreature);	
	}
	
	void newTest(int i){
		testingCreature = (GameObject)Instantiate(creaturePref);
		tester = (MoveController)testingCreature.GetComponent("MoveController");
		tester.testGenome(tests[i].getGenome());
	}
	
	
	// Update is called once per frame
	void Update () {
		if(tester != null && tester.getTimeElapsed() >testingTime){
			float evaluation = tester.getAdvance()<0? 0: tester.getAdvance() / (1 + tester.getCuadraticError());
			Debug.Log("test number: " + testNumber + "= error: " + tester.getCuadraticError() + "-- advance: " + tester.getAdvance() + "-- evaluation: " + evaluation);
			tests[testNumber].setEvaluation(evaluation);
			destroyTest();
			
			testNumber++;
			if(testNumber<tests.Count){
				newTest(testNumber);
			}
			else{
				tests = null;
				runingTests = false;
			}
		}
	}
}
