using System;
using UnityEngine;

public class ContenedorGenoma
{
	Genoma genome;
	float evaluation;

	TipoMutacion mutation_t;
	
	public ContenedorGenoma (TipoDeIndividuo functionType, TipoMutacion mutation_t)
	{
		this.mutation_t = mutation_t;
		this.genome = new Genoma(functionType).init();
	}
	
	public ContenedorGenoma (Genoma genome, TipoMutacion mutation_t)
	{
		this.mutation_t = mutation_t;
		this.genome = genome;
	}
	
	public Genoma getGenome(){
	 return genome;	
	}
	
	public void setEvaluation(float evaluation){
		this.evaluation = evaluation;	
	}
	
	public float getEvaluation(){
		return evaluation;
	}
	
	public ContenedorGenoma mutate(){
		Genoma newGenome = new Genoma(genome.getFunctionType());
		
		
		System.Collections.IEnumerator iterator = genome.GetEnumerator();
		foreach(Gen gen in newGenome){
			iterator.MoveNext();
			
			float rand = UnityEngine.Random.Range(0.0f,1.0f);

			switch(mutation_t){
			case TipoMutacion.Clasica:
				if(rand < 0.03){
					gen.generateVal();		
				}else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case TipoMutacion.Escalonada:
				if(rand < 0.003){
					gen.generateVal();		
				}
				else if(rand < 0.008){
					gen.setValMutation(((Gen)iterator.Current).getVal());
				}
				else if(rand < 0.015){
					gen.setValMicroMutation(((Gen)iterator.Current).getVal());
				}
				else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case TipoMutacion.Gausiana:
				if(rand < 0.05){
					gen.setValNormalMutation(((Gen)iterator.Current).getVal());		
				}
				else
				{
					gen.setVal(((Gen)iterator.Current).getVal());
				}
				break;
			case TipoMutacion.Ninguna:
				break;
			}

		}
		
		
		return new ContenedorGenoma(newGenome, mutation_t);
	}
	
	public ContenedorGenoma apariate(ContenedorGenoma couple){
		Genoma newGenome = new Genoma(genome.getFunctionType());
		
		
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
		
		return new ContenedorGenoma(newGenome, mutation_t);
	}
	
	public override bool Equals (object obj)
	{
		ContenedorGenoma other = (ContenedorGenoma)obj;
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

