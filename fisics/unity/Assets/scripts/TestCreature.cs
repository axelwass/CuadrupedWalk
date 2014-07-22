using UnityEngine;
using System.Collections;
using System.IO;

public class TestCreature : MonoBehaviour {
	
	public SimulationManager simulador;
	
	public string archivo;
	
	System.Collections.Generic.List<GenomeContainer> population = new System.Collections.Generic.List<GenomeContainer>();

	private static TestCreature instance;
	
	public bool usar = true;
	
	void Awake(){
		if(!usar ||instance != null){
			
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
			population.Add(new GenomeContainer(Genome.createFromFile(archivo),MutationType.None));	
	}
	
	// Update is called once per frame
	void Update () {
		if(!simulador.isRuningTest()){
			simulador.runTests(population);
		}
	}
}
