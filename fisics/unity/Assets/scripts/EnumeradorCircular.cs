using UnityEngine;
using System.Collections;

public class EnumeradorCircular {

	System.Collections.IEnumerator enumerator;

	public EnumeradorCircular(System.Collections.IEnumerator enumerator){
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
