using UnityEngine;
using System.Collections;

public class GrnnFunction : MoveFunction {

	GameObject body;

	float startTime = -100;

	ArrayList functions = new ArrayList();

	float period1;
	float period2;

	public GrnnFunction(BodyParts part,System.Collections.Generic.List<GrnnData> datas,GameObject body){
		foreach(GrnnData data in datas){
			switch(part){
			case BodyParts.BackLeft1:
				functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backLeft1));
				break;
			case BodyParts.BackLeft2:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backLeft2));
				break;
			case BodyParts.BackLeftShoulder:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backLeftShoulder));

				break;
			case BodyParts.BackRight1:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backRight1));

				break;
			case BodyParts.BackRight2:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backRight2));

				break;
			case BodyParts.BackRightShoulder:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).backRightShoulder));

				break;
			case BodyParts.FrontLeft1:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontLeft1));

				break;
			case BodyParts.FrontLeft2:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontLeft2));

				break;
			case BodyParts.FrontLeftShoulder:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontLeftShoulder));

				break;
			case BodyParts.FrontRight1:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontRight1));

				break;
			case BodyParts.FrontRight2:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontRight2));

				break;
			case BodyParts.FrontRightShoulder:
					functions.Add(new GrnnMaper(data.x,data.z,new GenomeToFunctions(data.genome).frontRightShoulder));

				break;
			}
			period2 = Mathf.Max(period2,new GenomeToFunctions(data.genome).dominantPeriod);
			period1 = Mathf.Max(period1,new GenomeToFunctions(data.genome).secondPeriod);
		}



		this.body = body;
	}


	public override float evalAngle (float t){
		if(body.rigidbody.velocity.magnitude >0.7 && (t-startTime > 3 + (Mathf.PI*2/period2) + (Mathf.PI*2/period1))){
			startTime = t;
		}
		if(startTime >= 0){
			foreach(GrnnMaper func in functions){
				return func.function.evalAngle(t-startTime);
			}
		}
		return 0;
	}
		
	public override float evalStrength (float t){
		float strength = 1000;
		foreach(GrnnMaper func in functions){
			if(t-startTime < 3 + (Mathf.PI*2/period2) + (Mathf.PI*2/period1)){
				strength = Mathf.Max(func.function.evalStrength(t),strength);
			}
		}

		return strength;
	}

	class GrnnMaper{
		public float x;
		public float z;
		public MoveFunction function;

		public GrnnMaper(float x,float z,MoveFunction function){
			this.x = x;
			this.z = z;
			this.function = function;
		}
	}
}
