using UnityEngine;
using System.Collections;

public class SimulationsManager : MonoBehaviour {

	
	public GameObject creaturePref;
	public float testingTime = 10;
	
	GameObject testingCreature;
	MoveController tester;
	
	int testNumber = 0;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 10;
		newTest();	
	}
	
	public void destroyTest(){
		tester = null;
		Destroy(testingCreature);	
	}
	
	public void newTest(){
		testNumber++;
		testingCreature = (GameObject)Instantiate(creaturePref);
		tester = (MoveController)testingCreature.GetComponent("MoveController");
		tester.testGenome(new Genome());
	}
	
	
	// Update is called once per frame
	void Update () {
		if(tester != null && tester.getTimeElapsed() >testingTime){
			Debug.Log("test number: " + testNumber + "= error: " + tester.getCuadraticError() + "-- advance: " + tester.getAdvance());
			destroyTest();
			newTest();
		}
	}
}
