using UnityEngine;
using System.Collections;
using System.IO;

public class GeneticAlgorithm : MonoBehaviour {
	
	
	public SimulationManager simulador;

	public int TAMANIO_ALEATORIO = 30; // DEBE SER MAYOR QUE 10!
	public int TAMANIO_ELITE = 4;
	public int TAMANIO_RULETA = 20;
	public int TAMANIO_NUEVO = 10;

	public MutationType tipo_mutacion = MutationType.Stepy;

	public FunctioT tipo_funcion = FunctioT.Classic;

	string folder;

	public string descripcion;
	
	System.Collections.Generic.List<GenomeContainer> population = new System.Collections.Generic.List<GenomeContainer>();

	private static GeneticAlgorithm instance;
	
	int generation = 0;
	
	public string continuar_de_carpeta;

	public bool usar = true;


	void Awake(){
		if(!usar || instance != null){
			
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
		if (string.IsNullOrEmpty(continuar_de_carpeta)) {
			for (int i =0; i<TAMANIO_ALEATORIO + TAMANIO_ELITE + TAMANIO_RULETA + TAMANIO_NUEVO; i++) {
				population.Add (new GenomeContainer (tipo_funcion, tipo_mutacion));	
			}

		} else {
			for(int i = 0;File.Exists(continuar_de_carpeta + "/population["+ i +"].genome");i++){
				//Debug.Log(loadFromFile + "/population["+ i +"].genome");
				population.Add (new GenomeContainer(Genome.createFromFile(continuar_de_carpeta + "/population["+ i +"].genome"),tipo_mutacion));
			}
		}
		simulador.runTests(population);
		folder = simulador.getName() + System.DateTime.Now.ToString("dd_MM_yyyy") + "(" + System.DateTime.Now.ToString("tthh_mm_ss") + ") (" + descripcion + ")";
		Directory.CreateDirectory("./test/");
		Directory.CreateDirectory("./test/" + folder);
		
		StreamWriter writer = new StreamWriter("test/"+folder+"/fitness.txt",false);
		writer.WriteLine("Elite Size: " + TAMANIO_ELITE + ", roulete size: " + TAMANIO_RULETA+ ", random size: " + TAMANIO_ALEATORIO);
		writer.WriteLine("Mutation type: " + tipo_mutacion);
		writer.WriteLine (simulador.simulationOptions());
		writer.WriteLine("Funcion: " + tipo_funcion + ", empujon inicial: (" + simulador.velocidad_de_inicio.x + "," + simulador.velocidad_de_inicio.y + "," + simulador.velocidad_de_inicio.z + ")");

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
		if(!simulador.isRuningTest()){
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
			
			
			for(int i =0; i<TAMANIO_ELITE; i++){
				newPopulation.Add(population[i]);
			}

			for(int i =0; i< TAMANIO_RULETA/2 + TAMANIO_RULETA%2; i++){
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
			
			for(int i =0; i< TAMANIO_ALEATORIO; i++){
				GenomeContainer son = getRandomParent(oldPopulation).apariate(getRandomParent(oldPopulation));
				if(UnityEngine.Random.Range(0.0f,1.0f)<0.45f){
					son = son.mutate();
				}
				newPopulation.Add(son);	
				//Debug.Log("newPop size: " + newPopulation.Count);
			}

			for(int i =0; i<TAMANIO_NUEVO; i++){
				newPopulation.Add(new GenomeContainer(tipo_funcion, tipo_mutacion));	
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

			System.Collections.Generic.List<GenomeContainer> toTest = population.GetRange(TAMANIO_ELITE,TAMANIO_ALEATORIO+TAMANIO_RULETA+TAMANIO_NUEVO);

			simulador.runTests(toTest);
		}
	}
}
