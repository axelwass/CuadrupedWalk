using UnityEngine;
using System.Collections;

public class MoveFunctionPartida : MoveFunction {

	float A2;
	float B2;
	float C2;
	float D2;
	float strength2;


	public MoveFunctionPartida(float amplitude, float period, float fase, float centerAngle, float strength,
	                           float amplitude2, float period2, float fase2, float centerAngle2, float strength2)
	{
		this.A= amplitude;
		this.B= period;
		this.C= fase;
		this.D= centerAngle;
		this.strength = strength;
		
		this.A2= amplitude2;
		this.B2= period2;
		this.C2= fase2;
		this.D2= centerAngle2;
		this.strength2 = strength2;
	}
	
	public override float evalAngle(float t){
		return t<(2*Mathf.PI/B2)? A*(float)Mathf.Sin(t*B+C) + D:A2*(float)Mathf.Sin(t*B2+C2) + D2;
	}
	
	public override float evalStrength(float t){
			return t<(2*Mathf.PI/B2)?strength:strength2;
	}
}
