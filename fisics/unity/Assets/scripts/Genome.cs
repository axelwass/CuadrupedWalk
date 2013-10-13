using System;
using UnityEngine;


public class Genome
{
	Gen strength;
	Gen period;
	
	Gen[] amplitudes;
	Gen[] fases;
	
	public Genome ()
	{
		amplitudes = new Gen[12];
		fases = new Gen[12];
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i] = new Gen(90);
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i] = new Gen(Mathf.PI * 2.0f);
        }
		
		
		strength = new Gen(1000);
		period = new Gen((Mathf.PI * 2.0f)/ 5.0f);
		
		init();
	}
	
	void init(){
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].generateVal();
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].generateVal();
        }
		
		
		strength.generateVal();
		period.generateVal();
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
    }
	
}

