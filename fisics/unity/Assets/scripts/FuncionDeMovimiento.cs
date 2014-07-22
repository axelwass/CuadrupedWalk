using System;
using UnityEngine;


public abstract class FuncionDeMovimiento
{
	protected float A;
	protected float B;
	protected float C;
	protected float D;
	protected float strength;

	public abstract float evalAngle (float t);
	public abstract float evalStrength (float t);
		
}

