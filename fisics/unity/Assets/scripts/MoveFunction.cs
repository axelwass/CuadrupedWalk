using System;
using UnityEngine;


public class MoveFunction
{
	float A;
	float B;
	float C;
	float D;
	float strength;

	public MoveFunction(float amplitude, float period, float fase, float centerAngle, float strength)
	{
		this.A= amplitude;
		this.B= period;
		this.C= fase;
		this.D= centerAngle;
		this.strength = strength;
	}

	public float evalAngle(float t){
		return A*(float)Math.Sin(t*B+C) + D;
	}
	
	public float evalStrength(float t){
		return strength;
	}
		
}

