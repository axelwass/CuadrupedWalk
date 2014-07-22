﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SimulationManager : MonoBehaviour {
	
	public float tiempo_simulacion;

	public float escala_temporal;
	public Vector3 velocidad_de_inicio;
	public abstract bool isRuningTest ();
	public abstract  void runTests (System.Collections.Generic.List<GenomeContainer> tests);
	public abstract string getName();
	public abstract string simulationOptions();

}
