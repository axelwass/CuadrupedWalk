using System;
using UnityEngine;

public class GenomeContainer
{
	Genome genome;
	float evaluation;

	MutationType mutation_t;
	
	public GenomeContainer (FunctioT functionType, MutationType mutation_t)
	{
		this.mutation_t = mutation_t;
		this.genome = new Genome(functionType).init();
	}
	
	public GenomeContainer (Genome genome, MutationType mutation_t)
	{
		this.mutation_t = mutation_t;
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
		Genome newGenome = new Genome(genome.getFunctionType());
		
		
		System.Collections.IEnumerator iterator = genome.GetEnumerator();
		foreach(Gen gen in newGenome){
			iterator.MoveNext();
			
			float rand = UnityEngine.Random.Range(0.0f,1.0f);

			switch(mutation_t){
			case MutationType.Classic:
				if(rand < 0.03){
					gen.generateVal();		
				}else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case MutationType.Stepy:
				if(rand < 0.003){
					gen.generateVal();		
				}
				else if(rand < 0.01){
					gen.setValMutation(((Gen)iterator.Current).getVal());
				}
				else if(rand < 0.02){
					gen.setValMicroMutation(((Gen)iterator.Current).getVal());
				}
				else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case MutationType.Gassian:
				if(rand < 0.05){
					gen.setValNormalMutation(((Gen)iterator.Current).getVal());		
				}
				else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case MutationType.None:
				Debug.LogError("Mutating a not mutable genome!");
				break;
			}

		}
		
		
		return new GenomeContainer(newGenome, mutation_t);
	}
	
	public GenomeContainer apariate(GenomeContainer couple){
		Genome newGenome = new Genome(genome.getFunctionType());
		
		
		System.Collections.IEnumerator iterator1 = genome.GetEnumerator();
		System.Collections.IEnumerator iterator2 = couple.genome.GetEnumerator();
		foreach(Gen gen in newGenome){
			iterator1.MoveNext();
			iterator2.MoveNext();
			float rand = UnityEngine.Random.Range(0.0f,1.0f);
			if( rand< 0.4){
				gen.setVal(((Gen)iterator1.Current).getVal());
			}
			else if(rand < 0.8){
				gen.setVal(((Gen)iterator2.Current).getVal());
			}else{
				gen.setVal(((Gen)iterator1.Current).getVal(),((Gen)iterator2.Current).getVal());
			}
		}
		
		return new GenomeContainer(newGenome, mutation_t);
	}
	
	public override bool Equals (object obj)
	{
		GenomeContainer other = (GenomeContainer)obj;
        System.Collections.IEnumerator iterator1 = genome.GetEnumerator();
		System.Collections.IEnumerator iterator2 = other.genome.GetEnumerator();
		foreach(Gen gen in genome){
			iterator1.MoveNext();
			iterator2.MoveNext();
			
		if(!((Gen)iterator1.Current).getVal().Equals(((Gen)iterator2.Current).getVal())){
				return false;
			}
			
		}
		return true;
	}

	public override int GetHashCode ()
	{
		return base.GetHashCode ();
	}
}

