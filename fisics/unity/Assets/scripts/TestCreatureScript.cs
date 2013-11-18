using UnityEngine;
using System.Collections;

public class TestCreatureScript : MonoBehaviour {

	GameObject testingCreature;
	MoveController tester;
	
	
	float elapsedTime = 0;
	
	public string creatureFilePath;
	
	private static TestCreatureScript instance;
	
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
		Application.LoadLevel(1);
	}
	
	
	void OnLevelWasLoaded (int level) {
		if (level == 1) {
			//Debug.Log("testnumber: " + testNumber);
			testingCreature = GameObject.Find("testingCreature");//(GameObject)Instantiate(creaturePref);
			tester = (MoveController)testingCreature.GetComponent("MoveController");
			tester.testGenome(Genome.createFromFile(creatureFilePath));
			
			elapsedTime=-0.02f;
		}
	}
	
	void FixedUpdate () {
		if(tester!=null){
			tester.updateState(elapsedTime);
		}
		elapsedTime+=Time.deltaTime;
	}
}
