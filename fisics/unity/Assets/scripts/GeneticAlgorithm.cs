using UnityEngine;
using System.Collections;
using System.IO;

public class GeneticAlgorithm : MonoBehaviour {
	
	public int POPULATION = 30; // DEBE SER MAYOR QUE 10!
	
	public SimulationsManager simManager;
	
	
	System.Collections.Generic.List<GenomeContainer> population = new System.Collections.Generic.List<GenomeContainer>();
	
	
	private static GeneticAlgorithm instance;
	
	int generation = 0;
	
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
		//GenomeContainer gc = new GenomeContainer();
		for(int i =0; i<POPULATION; i++){
			population.Add(new GenomeContainer());	
		}
		simManager.runTests(population);
		
		StreamWriter writer = new StreamWriter("fitness.txt",false);
		writer.Write(writer.NewLine);
		writer.Close();
	}
	
	GenomeContainer getRouletteParent(float totalEvaluation){
		float number = UnityEngine.Random.Range(0.0f,totalEvaluation);
		
		float cumEval = 0;
		for(int j =0; j<POPULATION; j++){
			cumEval += population[j].getEvaluation();
			if(cumEval>number){
					return population[j];
			}
		}
		Debug.Log("ShouldNotReach");
		return population[0];
	}
	
	GenomeContainer getRandomParent(){
		int parent = UnityEngine.Random.Range(0,POPULATION);
		//Debug.Log("Se devuelve el: " + parent);
		return population[parent];
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!simManager.isRuningTest()){
			population.Sort(delegate(GenomeContainer gc1, GenomeContainer gc2) { //no elimina repetidos!
				return gc2.getEvaluation().CompareTo(gc1.getEvaluation());
              });
			
			
			StreamWriter writer = new StreamWriter("fitness.txt",true);
			float totalEvaluation = 0;
			foreach(GenomeContainer gc in population){
				writer.Write(gc.getEvaluation());
				writer.Write("\t");
				totalEvaluation += gc.getEvaluation();
				//Debug.Log("genome eval: " + gc.getEvaluation());
				
			}
			writer.Write(writer.NewLine);
			writer.Close();
			
			Debug.Log("Best sofar: " + population[0].getEvaluation());
			population[0].getGenome().saveToFile("bestSoFar["+(generation++)+"].genome");
			
			System.Collections.Generic.List<GenomeContainer> newPopulation = new System.Collections.Generic.List<GenomeContainer>();
			
			//for(int i =0; i<POPULATION / 5; i++){
			//	newPoblation.Add(population[i]);
			//}
			// cambiado por 2 de elite.
			int eliteSize = 5;
			for(int i =0; i<eliteSize; i++){
				newPopulation.Add(population[i]);
			}
			int rouletteSize = 10;
			for(int i =0; i< rouletteSize; i++){
				GenomeContainer son = getRouletteParent(totalEvaluation).apariate(getRouletteParent(totalEvaluation));
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.3f){
					son = son.mutate();
				}
				newPopulation.Add(son);	
			}
			
			for(int i =0; i< POPULATION - rouletteSize - eliteSize; i++){
				GenomeContainer son = getRandomParent().apariate(getRandomParent());
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.3f){
					son = son.mutate();
				}
				newPopulation.Add(son);	
			}
			/*for(int i =0; i<POPULATION / 2; i++){
				newPoblation.Add(poblation[i]);
			}
			
			for(int i =0; i<POPULATION; i+=2){
				newPoblation.Add(poblation[i].apariate(poblation[i+1]).mutate());	
			}*/
			
			population = newPopulation;
			
			foreach(GenomeContainer gc in population){
				gc.setEvaluation(0);	
			}
			
			simManager.runTests(population);
		}
	}
}
