using System;

public class GenomeContainer
{
	Genome genome;
	float evaluation;
	
	public GenomeContainer ()
	{
		this.genome = new Genome().init();
	}
	
	public GenomeContainer (Genome genome)
	{
		this.genome = genome;
	}
	
	public Genome getGenome(){
	 return genome;	
	}
	
	public void setEvaluation(float evaluation){
		this.evaluation = evaluation;	
	}
	
	public float getEvaluation(){
		return evaluation;
	}
	
	public GenomeContainer mutate(){
		Genome newGenome = new Genome();
		
		
		System.Collections.IEnumerator iterator = genome.GetEnumerator();
		foreach(Gen gen in newGenome){
			iterator.MoveNext();
			if(UnityEngine.Random.Range(0.0f,1.0f) < 0.01){
				gen.generateVal();		
			}
			else{
				gen.setVal(((Gen)iterator.Current).getVal());
			}
		}
		
		
		return new GenomeContainer(newGenome);
	}
	
	public GenomeContainer apariate(GenomeContainer couple){
		Genome newGenome = new Genome();
		
		
		System.Collections.IEnumerator iterator1 = genome.GetEnumerator();
		System.Collections.IEnumerator iterator2 = couple.genome.GetEnumerator();
		foreach(Gen gen in newGenome){
			iterator1.MoveNext();
			iterator2.MoveNext();
			if(UnityEngine.Random.Range(0.0f,1.0f) < 0.5){
				gen.setVal(((Gen)iterator1.Current).getVal());
			}
			else{
				gen.setVal(((Gen)iterator2.Current).getVal());
			}
		}
		
		return new GenomeContainer(newGenome);
	}
	
	
}

