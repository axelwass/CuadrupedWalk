using System;
using UnityEngine;

public class Gen
{
	float val = 0.0f;
	float maxVal;
	
	public Gen (float maxVal)
	{
		this.maxVal = maxVal;
	}
	
	public void setVal(float val){
			if(val > maxVal)
				Debug.Log("estas seteandole cualquiera a un gen");
			this.val = val;
	}
	
	public float getVal(){
		return val;	
	}
	
	public void generateVal(){
		val = UnityEngine.Random.Range(0.0f,maxVal);	
	}
	
}

