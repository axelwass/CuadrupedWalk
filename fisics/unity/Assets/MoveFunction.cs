using System;
using UnityEngine;


	public class MoveFunction
	{
		float A;
		float B;
		float C;
		float strength;
		HingeJoint joint;
		public MoveFunction(HingeJoint j, float A, float B, float C, float strength)
		{
		this.A= A;
		this.B= B;
		this.C= C;
		this.strength = strength;
		this.joint = j;
		}
		
		public void update(float t){
			float angle = A*(float)Math.Sin(t*B+C);
			JointSpring s = new JointSpring();
		s.targetPosition = angle;
		s.spring = strength;
			joint.spring = s;
		}
			
	}

