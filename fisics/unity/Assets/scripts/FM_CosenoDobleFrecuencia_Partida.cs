using UnityEngine;
using System.Collections;

public class FM_CosenoDobleFrecuencia_Partida : FuncionDeMovimiento {
	
	
	float A2;
	float B2;
	float B3;
	float C2;
	float D2;
	float strength2;
	
	
	public FM_CosenoDobleFrecuencia_Partida(float amplitude, float period, float period3, float fase, float centerAngle, float strength,
	                                   float amplitude2, float period2, float fase2, float centerAngle2, float strength2)
	{
		this.A2 = amplitude;
		this.B2 = period;
		this.B3 = period3;
		this.C2 = fase;
		this.D2 = centerAngle;
		this.strength2 = strength;
		
		this.A = amplitude2;
		this.B = period2;
		this.C = fase2;
		this.D = centerAngle2;
		this.strength = strength2;
	}
	public override float evalAngle(float t){
		if (t < (2 * Mathf.PI / B)) {
			return  A * (float)Mathf.Cos (t / 2 * B + C);
		}
		float t2 = t - (2 * Mathf.PI / B) + C2 /((B2+B3)/2);
		float t_local = t2 - Mathf.Floor(t2 /(Mathf.PI / B2 + Mathf.PI / B3)) * (Mathf.PI / B2 + Mathf.PI / B3);
		if (t_local * B2 < Mathf.PI) {
			return A2 * (float)Mathf.Cos (t_local * B2) + D2;
		}
		else {
			float t_local2 = (t_local - ((Mathf.PI)/B2) + ((Mathf.PI)/B3));
			return A2 * (float)Mathf.Cos (t_local2 * B3) + D2;
		}
	}
	
	public override float evalStrength(float t){
		return t<(2*Mathf.PI/B)?strength:strength2;
	}
}
