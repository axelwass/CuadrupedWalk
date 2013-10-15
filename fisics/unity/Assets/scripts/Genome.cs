using System;
using UnityEngine;


public class Genome:System.Collections.IEnumerable
{
	Gen strength;
	Gen period;
	
	Gen[] amplitudes;
	Gen[] fases;
	Gen[] centerAngles;
	
	public Genome ()
	{
		amplitudes = new Gen[12];
		fases = new Gen[12];
		centerAngles = new Gen[12];
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i] = new Gen(0,90);
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i] = new Gen(0,Mathf.PI * 2.0f);
        }
		for (int i = 0; i < fases.Length; i++)
        {
            centerAngles[i] = new Gen(-90,90);
        }
		
		
		strength = new Gen(0,1000);
		period = new Gen(0,(Mathf.PI * 2.0f)/ 5.0f);
	}
	
	public Genome init(){
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].generateVal();
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].generateVal();
        }
		for (int i = 0; i < fases.Length; i++)
        {
            centerAngles[i].generateVal();
        }
		
		
		strength.generateVal();
		period.generateVal();
		
		return this;
	}
	
	public float getStrength(){
		return strength.getVal();
	}
	
	public float getPeriod(){
		return period.getVal();
	}
	
	public float getAmplitude(int i){
		return amplitudes[i].getVal();	
	}
	
	public float getFase(int i){
		return fases[i].getVal();	
	}
	
	public float getCenterAngle(int i){
		return 0; //centerAngles[i].getVal();	//TODO descomentar para usar angulos centrales.
	}
	
	public System.Collections.IEnumerator GetEnumerator()
    {
		yield return strength;
		yield return period;
        for (int i = 0; i < amplitudes.Length; i++)
        {
            yield return amplitudes[i];
        }
		for (int i = 0; i < fases.Length; i++)
        {
            yield return fases[i];
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            yield return centerAngles[i];
        }
    }
	
}

