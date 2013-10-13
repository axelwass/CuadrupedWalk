using System;
using UnityEngine;


public class MoveFunction
{
	float A;
	float B;
	float C;
	float strength;

	public MoveFunction(float amplitude, float period, float fase, float strength)
	{
		this.A= amplitude;
		this.B= period;
		this.C= fase;
		this.strength = strength;
	}

	public float evalAngle(float t){
		return A*(float)Math.Sin(t*B+C);
	}
	
	public float evalStrength(float t){
		return strength;
	}
		
}

