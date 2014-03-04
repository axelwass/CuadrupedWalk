using UnityEngine;
using System.Collections;

public class MoveFunctionFourier2 : MoveFunction
{
	float A2;


	public MoveFunctionFourier2(float amplitude,float amplitude2, float period, float fase, float centerAngle, float strength)
	{
		this.A= amplitude;
		this.A2= amplitude2;
		this.B= period;
		this.C= fase;
		this.D= centerAngle;
		this.strength = strength;
	}
	
	public override float evalAngle(float t){
		return A2*(float)Mathf.Sin(t*B*2+C) + A*(float)Mathf.Sin(t*B+C) + D;
	}
	
	public override float evalStrength(float t){
		return strength;
	}
	
}