using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimulationManager : MonoBehaviour {
	
	
	public GameObject creaturePref;
	public float testingTime;
	public float timeScale;


	public abstract bool isRuningTest ();
	public abstract  void runTests (System.Collections.Generic.List<GenomeContainer> tests);

}
