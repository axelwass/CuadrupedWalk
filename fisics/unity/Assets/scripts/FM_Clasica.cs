using System;
using UnityEngine;


public class FM_Clasica: FuncionDeMovimiento
{

	public FM_Clasica(float amplitude, float period, float fase, float centerAngle, float strength)
	{
		this.A= amplitude;
		this.B= period;
		this.C= fase;
		this.D= centerAngle;
		this.strength = strength;
	}
	
	public override float evalAngulo(float t){
		return A*(float)Math.Sin(t*B+C) + D;
	}
	
	public override float evalFuerza(float t){
		return strength;
	}
	
}
