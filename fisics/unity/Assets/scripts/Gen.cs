using System;
using UnityEngine;


public class Gen
{
	float val = 0.0f;
	float minVal;
	float maxVal;
	
	public Gen (float minVal,float maxVal)
	{
		this.minVal = minVal;
		this.maxVal = maxVal;
	}
	
	public void setVal(float val){
		if(val > maxVal || val<minVal){
			Debug.Log("estas seteandole cualquiera a un gen");
		}
		this.val = val;
	}
	
	public float getVal(){
		return val;	
	}
	
	public void generateVal(){
		val = UnityEngine.Random.Range(minVal,maxVal);	
	}
	
}

