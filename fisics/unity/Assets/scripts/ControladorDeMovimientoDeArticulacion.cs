using UnityEngine;
using System.Collections;
using System.IO;

public class ControladorDeMovimientoDeArticulacion : MonoBehaviour {
	

	
	FuncionDeMovimiento function;
	HingeJoint joint;

	public bool imprimir_angulo = false;
	StreamWriter writer;

	// Use this for initialization
	void Start () {
		joint = (HingeJoint)GetComponent("HingeJoint");
		if(imprimir_angulo && Probador.getInstance() != null){
			writer = new StreamWriter(Probador.getInstance().archivo + "." + this.gameObject.transform.parent.gameObject.name + "." + this.gameObject.name,false);
			writer.Close();
		}
	}

	public void setFunction(FuncionDeMovimiento function){
		this.function = function;	
	}
	
	// Update is called once per frame
	public void updateState(float elapsedTime) {
		if(function != null && joint != null){
			JointSpring s = new JointSpring();
			s.targetPosition = function.evalAngulo(elapsedTime);
			if ( s.targetPosition < joint.limits.min ) {
				s.targetPosition = joint.limits.min;
			} else if ( s.targetPosition > joint.limits.max ) {
				s.targetPosition = joint.limits.max;
			};

			if(imprimir_angulo && Probador.getInstance() != null){
				writer = new StreamWriter(Probador.getInstance().archivo + "." + this.gameObject.transform.parent.gameObject.name + "." + this.gameObject.name,true);
				writer.WriteLine(s.targetPosition + ", " + joint.angle);

				writer.Close();
			}
			s.spring = function.evalFuerza(elapsedTime);
			joint.spring = s;
			
		}
	}
}
