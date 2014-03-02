using UnityEngine;
using System.Collections;
using System.IO;

public class TestCreature : MonoBehaviour {
	
	public SimulationManager simManager;
	
	public string creatureFilePath;
	
	System.Collections.Generic.List<GenomeContainer> population = new System.Collections.Generic.List<GenomeContainer>();


	
	
	public bool faseSync = true;

	private static TestCreature instance;
	
	public bool generate = true;
	
	void Awake(){
		if(!generate ||instance != null){
			
			DestroyImmediate(this.gameObject);
		}
		else{
			instance = this;	
			DontDestroyOnLoad(this);
		}
	}
	
	public static TestCreature getInstance(){
		return instance;
	}
	
	// Use this for initialization
	void Start () {
			population.Add(new GenomeContainer(Genome.createFromFile(creatureFilePath)));	
	}
	
	// Update is called once per frame
	void Update () {
		if(!simManager.isRuningTest()){
			simManager.runTests(population);
		}
	}
}
