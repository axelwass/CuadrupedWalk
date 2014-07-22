using UnityEngine;
using System.Collections;

public class FM_Caidas : FuncionDeMovimiento {
	
	float A2;
	float B2;
	float C2;
	float D2;
	float strength2;

	float A3;
	float B3;
	float C3;
	float D3;
	float strength3;

	float A4;
	float B4;
	float C4;
	float D4;
	float strength4;

	
	public FM_Caidas(EnumeradorCircular aEnum,
	                                         EnumeradorCircular caEnum,
	                                         EnumeradorCircular pEnum,
	                                         EnumeradorCircular fEnum,
	                                         EnumeradorCircular sEnum)
	{
		this.A= aEnum.nextValue();
		this.B= pEnum.nextValue();
		this.C= fEnum.nextValue();
		this.D= caEnum.nextValue();
		this.strength = sEnum.nextValue();
		
		this.A2= aEnum.nextValue();
		this.B2= pEnum.nextValue();
		this.C2= fEnum.nextValue();
		this.D2= caEnum.nextValue();
		this.strength2 = sEnum.nextValue();
		
		this.A3= aEnum.nextValue();
		this.B3= pEnum.nextValue();
		this.C3= fEnum.nextValue();
		this.D3= caEnum.nextValue();
		this.strength3 = sEnum.nextValue();
		
		this.A4= aEnum.nextValue();
		this.B4= pEnum.nextValue();
		this.C4= fEnum.nextValue();
		this.D4= caEnum.nextValue();
		this.strength4 = sEnum.nextValue();
	}
	
	public override float evalAngle(float t){
		return t<(Mathf.PI/B)? A*(float)Mathf.Sin(t*B+C) + D: //le saco el 2 pi a todos
			t<(Mathf.PI/B2)+(Mathf.PI/B)?A2*(float)Mathf.Sin(t*B2+C2) + D2:
			t<(Mathf.PI/B3)+(Mathf.PI/B2)+(Mathf.PI/B)?A3*(float)Mathf.Sin(t*B3+C3) + D3:
			t<(Mathf.PI/B4)+(Mathf.PI/B3)+(Mathf.PI/B2)+(Mathf.PI/B)?A4*(float)Mathf.Sin(t*B4+C4) + D4:
				0;
				
	}
	
	public override float evalStrength(float t){
		return t<(Mathf.PI/B)? strength: //le saco el 2 pi a todos
			t<(Mathf.PI/B2)+(Mathf.PI/B)?strength2:
				t<(Mathf.PI/B3)+(Mathf.PI/B2)+(Mathf.PI/B)?strength3:
				t<(Mathf.PI/B4)+(Mathf.PI/B3)+(Mathf.PI/B2)+(Mathf.PI/B)?strength4:
				Mathf.Max(strength,strength2,strength3,strength4);
	}
}
