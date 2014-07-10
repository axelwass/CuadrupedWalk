using UnityEngine;
using System.Collections;
using System.IO;

public class GeneticAlgorithm : MonoBehaviour {
	
	public int RANDOM_SIZE = 30; // DEBE SER MAYOR QUE 10!
	public int ELITE_SIZE = 4;
	public int ROULET_SIZE = 20;
	public int NEW_SIZE = 10;

	public MutationType mutation_t = MutationType.Stepy;

	public SimulationManager simManager;

	public FunctioT functionType = FunctioT.Classic;

	string folder;

	public string description;
	
	System.Collections.Generic.List<GenomeContainer> population = new System.Collections.Generic.List<GenomeContainer>();

	private static GeneticAlgorithm instance;
	
	int generation = 0;
	
	public bool generate = true;

	public string loadFromFile;

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
		//GenomeContainer gc = new GenomeContainer();
		if (string.IsNullOrEmpty(loadFromFile)) {
			for (int i =0; i<RANDOM_SIZE + ELITE_SIZE + ROULET_SIZE + NEW_SIZE; i++) {
				population.Add (new GenomeContainer (functionType, mutation_t));	
			}

		} else {
			for(int i = 0;File.Exists(loadFromFile + "/population["+ i +"].genome");i++){
				//Debug.Log(loadFromFile + "/population["+ i +"].genome");
				population.Add (new GenomeContainer(Genome.createFromFile(loadFromFile + "/population["+ i +"].genome"),mutation_t));
			}
		}
		simManager.runTests(population);
		folder = simManager.getName() + System.DateTime.Now.ToString("dd_MM_yyyy") + "(" + System.DateTime.Now.ToString("tthh_mm_ss") + ") (" + description + ")";
		Directory.CreateDirectory("./test/");
		Directory.CreateDirectory("./test/" + folder);
		
		StreamWriter writer = new StreamWriter("test/"+folder+"/fitness.txt",false);
		writer.WriteLine("Elite Size: " + ELITE_SIZE + ", roulete size: " + ROULET_SIZE+ ", random size: " + RANDOM_SIZE);
		writer.WriteLine("Mutation type: " + mutation_t);
		writer.WriteLine (simManager.simulationOptions());
		writer.WriteLine("Funcion: " + functionType + ", empujon inicial: (" + simManager.initialSpeed.x + "," + simManager.initialSpeed.y + "," + simManager.initialSpeed.z + ")");

		writer.Close();
	}
	
	GenomeContainer getRouletteParent(System.Collections.Generic.List<GenomeContainer> pop){
		float totalEvaluation = getTotalEvaluation(pop);
		float number = UnityEngine.Random.Range(0.0f,totalEvaluation);
		
		float cumEval = 0;
		for(int j =0; j<pop.Count; j++){
			cumEval += pop[j].getEvaluation();
			if(cumEval>=number){
					return pop[j];
			}
		}
		Debug.Log("ShouldNotReach");
		return pop[0];
	}
	
	
	GenomeContainer getRandomParent(System.Collections.Generic.List<GenomeContainer> pop){
		int parent = UnityEngine.Random.Range(0,pop.Count);
		//Debug.Log("Se devuelve el: " + parent);
		return pop[parent];
		
	}
	
	float getTotalEvaluation(System.Collections.Generic.List<GenomeContainer> pop){
		float totalEvaluation = 0;
		foreach(GenomeContainer gc in pop){
				totalEvaluation += gc.getEvaluation();
				//Debug.Log("genome eval: " + gc.getEvaluation());
				
			}
		return totalEvaluation;
	}

	void OnGUI () {
		if (GUI.Button (new Rect (10,10,130,20), "Guardar generacion")) {
			Directory.CreateDirectory("./test/" + folder + "/generation" + generation);
			int i =0;
			foreach(GenomeContainer gc in population){
				gc.getGenome().saveToFile("test/"+folder + "/generation" + generation + "/population["+ (i++) +"].genome");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(!simManager.isRuningTest()){
			population.Sort(delegate(GenomeContainer gc1, GenomeContainer gc2) { //no elimina repetidos!
				return gc2.getEvaluation().CompareTo(gc1.getEvaluation());
              });

			StreamWriter writer = new StreamWriter("test/"+folder+"/fitness.txt",true);
			foreach(GenomeContainer gc in population){
				writer.Write(gc.getEvaluation());
				writer.Write("\t");
			}
			writer.Write(writer.NewLine);
			writer.Close();

			Debug.Log("Best sofar["+generation+"]: " + population[0].getEvaluation());
			population[0].getGenome().saveToFile("test/"+folder+"/bestSoFar["+(generation++)+"].genome");
			
			System.Collections.Generic.List<GenomeContainer> newPopulation = new System.Collections.Generic.List<GenomeContainer>();
			System.Collections.Generic.List<GenomeContainer> oldPopulation = new System.Collections.Generic.List<GenomeContainer>();
			for(int i =0; i<population.Count; i++){
				oldPopulation.Add(population[i]);
			}
			
			
			for(int i =0; i<ELITE_SIZE; i++){
				newPopulation.Add(population[i]);
			}

			for(int i =0; i< ROULET_SIZE/2 + ROULET_SIZE%2; i++){
				GenomeContainer c1 = getRouletteParent(oldPopulation);
				oldPopulation.Remove(c1);
				GenomeContainer c2 = getRouletteParent(oldPopulation);
				oldPopulation.Remove(c2);
				GenomeContainer son1 = c1.apariate(c2);
				GenomeContainer son2 = c2.apariate(c1);

				if(UnityEngine.Random.Range(0.0f,1.0f)<0.3f){
					son1 = son1.mutate();
				}
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.3f){
					son2 = son2.mutate();
				}
				newPopulation.Add(son1);
				//Debug.Log("newPop size: " + newPopulation.Count);
				newPopulation.Add(son2);
				//Debug.Log("newPop size: " + newPopulation.Count);
			}
			
			for(int i =0; i< RANDOM_SIZE; i++){
				GenomeContainer son = getRandomParent(oldPopulation).apariate(getRandomParent(oldPopulation));
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.45f){
					son = son.mutate();
				}
				newPopulation.Add(son);	
				//Debug.Log("newPop size: " + newPopulation.Count);
			}

			for(int i =0; i<NEW_SIZE; i++){
				newPopulation.Add(new GenomeContainer(functionType, mutation_t));	
			}
			/*for(int i =0; i<POPULATION / 2; i++){
				newPoblation.Add(poblation[i]);
			}
			
			for(int i =0; i<POPULATION; i+=2){
				newPoblation.Add(poblation[i].apariate(poblation[i+1]).mutate());	
			}*/
			
			population = newPopulation;
			
			/*foreach(GenomeContainer gc in population){
				gc.setEvaluation(0);	
			}*/

			System.Collections.Generic.List<GenomeContainer> toTest = population.GetRange(ELITE_SIZE,RANDOM_SIZE+ROULET_SIZE+NEW_SIZE);

			simManager.runTests(toTest);
		}
	}
}
