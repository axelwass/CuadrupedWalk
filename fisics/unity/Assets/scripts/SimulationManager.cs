﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimulationManager : MonoBehaviour {
	
	public bool accelEval = true;
	public bool heightEval = true;
	public bool cycleEval = true;

	public float timeScale;
	public Vector3 initialSpeed;
	public abstract bool isRuningTest ();
	public abstract  void runTests (System.Collections.Generic.List<GenomeContainer> tests);
	public abstract string getName();

}
