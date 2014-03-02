/*using UnityEngine;
using System.Collections;

public class TestCreatureScript : MonoBehaviour {

	GameObject testingCreature;
	MoveController tester;
	
	
	float elapsedTime = 0;
	
	
	public float testingTime = 20;
	
	public string creatureFilePath;
	
	private static TestCreatureScript instance;
	
	bool firstTime = true;
	
	public bool generate = true;
	
	Genome genome;
	
	void Awake(){
		if(!generate || instance != null){
			DestroyImmediate(this.gameObject);	
		}
		else{
			instance = this;	
			DontDestroyOnLoad(this);
		}
	}
	
	// Use this for initialization
	void Start () {
		genome = Genome.createFromFile(creatureFilePath);
	}
	
	
	void OnLevelWasLoaded (int level) {
		if (level == 1) {
			//Debug.Log("testnumber: " + testNumber);
			testingCreature = GameObject.Find("testingCreature");//(GameObject)Instantiate(creaturePref);
			tester = (MoveController)testingCreature.GetComponent("MoveController");
			tester.testGenome(genome);
			
			elapsedTime=-0.02f;
		}
	}
	
	void FixedUpdate () {
		if(firstTime){
			Application.LoadLevel(1);	
			firstTime = false;
		} else{
			if( testingTime!= 0 && elapsedTime >testingTime){
				float evaluation = tester.getAdvance();//250f - tester.getCuadraticErrorPosition() - tester.getCuadraticErrorRotation();// / (1 + tester.getCuadraticError());
				evaluation = evaluation<0? 0: evaluation;
				Debug.Log(" error position: " + tester.getCuadraticErrorPosition() + "-- error rotation: " + tester.getCuadraticErrorRotation() + "-- advance: " + tester.getAdvance() + "-- evaluation: " + evaluation);	
				testingTime = 0;
			}
			if(tester!=null){
				tester.updateState(elapsedTime);
			}
			elapsedTime+=Time.deltaTime;
		}
	}
}*/
