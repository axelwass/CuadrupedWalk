using System;
using UnityEngine;


public abstract class FuncionDeMovimiento
{
	protected float A;
	protected float B;
	protected float C;
	protected float D;
	protected float strength;

	public abstract float evalAngulo (float t);
	public abstract float evalFuerza (float t);
		
}

