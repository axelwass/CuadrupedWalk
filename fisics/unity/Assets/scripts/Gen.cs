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

	public void setVal(float val1,float val2){
		float max = val1 > val2 ? val1 : val2;
		float min = val1 < val2 ? val1 : val2;

		if (Mathf.Abs (val1 - val2) > (maxVal - max + min - minVal)) {
			this.val = (val1 + val2) / 2;
		} else {
			float diff = (maxVal - max + min - minVal);
			this.val = (max + diff/2)< maxVal?max + diff/2: min - diff/2;
		}
	}
	
	public float getVal(){
		return val;	
	}
	
	public void generateVal(){
		val = UnityEngine.Random.Range(minVal,maxVal);	
	}

	public void setValMutation(float val){
		float range = (maxVal - minVal)/4;
		this.val = val + UnityEngine.Random.Range(-range,range);
		if (this.val < minVal) {
			this.val = maxVal + this.val- minVal;
		}
		if (this.val > maxVal) {
			this.val = minVal + this.val - maxVal;
		}
	}

	public void setValMicroMutation(float val){
		float range = (maxVal - minVal)/10;
		this.val = val + UnityEngine.Random.Range(-range,range);
		if (this.val < minVal) {
			this.val = maxVal + this.val- minVal;
		}
		if (this.val > maxVal) {
			this.val = minVal + this.val - maxVal;
		}
	}
}

