using UnityEngine;
using System.Collections;

public class CircularEnumerator {

	System.Collections.IEnumerator enumerator;

	public CircularEnumerator(System.Collections.IEnumerator enumerator){
		this.enumerator = enumerator;
	}

	public float nextValue(){
		if (!enumerator.MoveNext ()) {
			enumerator.Reset();
			enumerator.MoveNext();
		}
		return ((Gen)enumerator.Current).getVal();
	}
}
