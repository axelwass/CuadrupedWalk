using UnityEngine;
using System.Collections;
using System.IO;

public class Probador : MonoBehaviour {
	
	public Simulador simulador;
	
	public string archivo;
	
	System.Collections.Generic.List<ContenedorGenoma> population = new System.Collections.Generic.List<ContenedorGenoma>();

	private static Probador instance;
	
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
	
	public static Probador getInstance(){
		return instance;
	}
	
	// Use this for initialization
	void Start () {
			population.Add(new ContenedorGenoma(Genoma.createFromFile(archivo),TipoMutacion.Ninguna));	
	}
	
	// Update is called once per frame
	void Update () {
		if(!simulador.isRuningTest()){
			simulador.runTests(population);
		}
	}
}
