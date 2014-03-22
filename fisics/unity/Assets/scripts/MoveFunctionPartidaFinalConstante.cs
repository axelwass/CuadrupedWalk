using UnityEngine;
using System.Collections;

public class MoveFunctionPartidaFinalConstante : MoveFunction {
	
	float A2;
	float B2;
	float C2;
	float D2;
	float strength2;
	
	
	public MoveFunctionPartidaFinalConstante(float amplitude, float period, float fase, float centerAngle, float strength,
	                           float amplitude2, float period2, float fase2, float centerAngle2, float strength2)
	{
		this.A= amplitude2;
		this.B= period2;
		this.C= fase2;
		this.D= centerAngle2;
		this.strength = strength2;
		
		this.A2= amplitude;
		this.B2= period;
		this.C2= fase;
		this.D2= centerAngle;
		this.strength2 = strength;
	}
	
	public override float evalAngle(float t){
		return t<(2*Mathf.PI/B)? A*(float)Mathf.Sin(t*B+C) + D:
			t<(2*Mathf.PI/B2)+(2*Mathf.PI/B)?A2*(float)Mathf.Sin(t*B2+C2) + D2:
				A2*(float)Mathf.Sin(2*Mathf.PI+C2) + D2;
				
	}
	
	public override float evalStrength(float t){
		return t<(2*Mathf.PI/B)?strength:strength2;
	}
}
