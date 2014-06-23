using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimulationManager : MonoBehaviour {
	
	public float testingTime;

	public float timeScale;
	public Vector3 initialSpeed;
	public abstract bool isRuningTest ();
	public abstract  void runTests (System.Collections.Generic.List<GenomeContainer> tests);
	public abstract string getName();
	public abstract string simulationOptions();

}
