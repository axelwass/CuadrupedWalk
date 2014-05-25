using UnityEngine;
using System.Collections;

public class GrnnData{

	public float x;
	public float z;
	public Genome genome;

	public GrnnData(float x,float z, Genome genome){
		this.x = x;
		this.z = z;
		this.genome = genome;
	}
}
