using UnityEngine;
using System.Collections;

public class GeneticAlgorithm : MonoBehaviour {
	
	public int POPULATION = 10;
	
	public SimulationsManager simManager;
	
	
	System.Collections.Generic.List<GenomeContainer> poblation = new System.Collections.Generic.List<GenomeContainer>();
	
	
	// Use this for initialization
	void Start () {
		for(int i =0; i<POPULATION; i++){
			poblation.Add(new GenomeContainer());	
		}
		simManager.runTests(poblation);
	}
	
	GenomeContainer getParent(float totalEvaluation){
		float number = UnityEngine.Random.Range(0.0f,totalEvaluation);
		
		float cumEval = 0;
		for(int j =0; j<POPULATION; j++){
			cumEval += poblation[j].getEvaluation();
			if(cumEval>number){
					return poblation[j];
			}
		}
		Debug.Log("JouldNotReach");
		return poblation[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(!simManager.isRuningTest()){
			poblation.Sort(delegate(GenomeContainer gc1, GenomeContainer gc2) {
                return gc2.getEvaluation().CompareTo(gc1.getEvaluation());
              });
			
			float totalEvaluation = 0;
			foreach(GenomeContainer gc in poblation){
				totalEvaluation += gc.getEvaluation();
				//Debug.Log("genome eval: " + gc.getEvaluation());
				
			}
			
			Debug.Log("Best sofar: " + poblation[0].getEvaluation());
			
			System.Collections.Generic.List<GenomeContainer> newPoblation = new System.Collections.Generic.List<GenomeContainer>();
			
			for(int i =0; i<POPULATION / 5; i++){
				newPoblation.Add(poblation[i]);
			}
			
			for(int i =0; i<POPULATION - (POPULATION/5); i++){
				GenomeContainer son = getParent(totalEvaluation).apariate(getParent(totalEvaluation));
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.3f){
					son = son.mutate();
				}
				newPoblation.Add(son);	
			}
			
			/*for(int i =0; i<POPULATION / 2; i++){
				newPoblation.Add(poblation[i]);
			}
			
			for(int i =0; i<POPULATION; i+=2){
				newPoblation.Add(poblation[i].apariate(poblation[i+1]).mutate());	
			}*/
			
			poblation = newPoblation;
			
			foreach(GenomeContainer gc in poblation){
				gc.setEvaluation(0);	
			}
			
			simManager.runTests(poblation);
		}
	}
}
