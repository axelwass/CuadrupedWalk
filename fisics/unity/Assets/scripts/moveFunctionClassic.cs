using System;
using UnityEngine;


public class moveFunctionClassic: MoveFunction
{

	public moveFunctionClassic(float amplitude, float period, float fase, float centerAngle, float strength)
	{
		this.A= amplitude;
		this.B= period;
		this.C= fase;
		this.D= centerAngle;
		this.strength = strength;
	}
	
	public override float evalAngle(float t){
		return A*(float)Math.Sin(t*B+C) + D;
	}
	
	public override float evalStrength(float t){
		return strength;
	}
	
}
