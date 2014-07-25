using UnityEngine;
using System.Collections;

public class FM_Fourier_Partida : FuncionDeMovimiento {

	float A0;
	float A1;
	float A2;
	float B1;
	float B2;
	float fase;
	float period;
	float strength2;


	public FM_Fourier_Partida(float a1,float a2, float b1, float b2, float period, float fase, float centerAngle, float strength,
	                           float amplitude2, float period2, float fase2, float centerAngle2, float strength2)
	{
		this.A= amplitude2;
		this.B= period2;
		this.C= fase2;
		this.D= centerAngle2;
		this.strength = strength2;
		
		this.A1= a1;
		this.A2= a2;
		this.B1= b1;
		this.B2= b2;
		this.period = period;
		this.fase= fase;
		this.A0= centerAngle;
		this.strength2 = strength;
	}
	
	public override float evalAngulo(float t){
		if(t<(2*Mathf.PI/B)){
			return  A*(float)Mathf.Sin(t/2*B+C) + D;
		}else{
			return A0 + A1*(float)Mathf.Cos(t*period+fase) + B1*(float)Mathf.Sin(t*period+fase) + A2*(float)Mathf.Cos(2*t*period+fase) + B2*(float)Mathf.Sin(2*t*period+fase);
		}
	}
	
	public override float evalFuerza(float t){
			return t<(2*Mathf.PI/B)?strength:strength2;
	}
}
