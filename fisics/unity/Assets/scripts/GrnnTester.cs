using UnityEngine;
using System.Collections;

public class GrnnTester : MonoBehaviour {

	
	public PushSimulationManager simManager;

	public Hashtable files; 

	public string creatureFilePath001;
	public string creatureFilePath002;
	/*public string creatureFilePath003;
	private Genome genome003;
	public string creatureFilePath100;
	private Genome genome001;
	public string creatureFilePath200;
	private Genome genome001;
	public string creatureFilePath300;
	private Genome genome001;*/



	GrnnData[] data = new GrnnData[1];
	
	private static GrnnTester instance;
	
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
	
	public static GrnnTester getInstance(){
		return instance;
	}
	
	// Use this for initialization
	void Start () {
		//population.Add(new GenomeContainer(Genome.createFromFile(creatureFilePath),MutationType.None));
		data[0] = new GrnnData(0,1,Genome.createFromFile(creatureFilePath001));

	}
	
	// Update is called once per frame
	void Update () {
		if(!simManager.isRuningTest()){
			//simManager.runGrnnTest(data);
		}
	}
}
