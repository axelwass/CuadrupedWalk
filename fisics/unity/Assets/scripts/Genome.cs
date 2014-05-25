using System;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Genome:System.Collections.IEnumerable, System.Runtime.Serialization.ISerializable
{

	FunctioT functionType;
	Gen[] strength;
	Gen[] period;
	
	Gen[] amplitudes;
	Gen[] fases;
	Gen[] centerAngles;

	
	Gen selector;
	
	public static Genome createFromFile(String filename){
		Genome instance  = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream(filename, FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            // Deserialize the hashtable from the file and  
            // assign the reference to the local variable.
            instance = (Genome) formatter.Deserialize(fs);
        }
        catch (SerializationException e) 
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }
		
		return instance;
	}

	public FunctioT getFunctionType(){
		return functionType;
	}

	private void createVectors(FunctioT functionType){
		switch (functionType) {
		case FunctioT.Classic:
			amplitudes = new Gen[12];
			fases = new Gen[12];
			centerAngles = new Gen[12];
			strength = new Gen[1];
			period = new Gen[1];
			break;
		case FunctioT.FaseSync:
			amplitudes = new Gen[6];
			fases = new Gen[6];
			centerAngles = new Gen[6];
			strength = new Gen[1];
			period = new Gen[1];
			break;
		case FunctioT.FaseSuperSync:
			amplitudes = new Gen[6];
			fases = new Gen[3];
			centerAngles = new Gen[6];
			strength = new Gen[1];
			period = new Gen[1];
			break;
		case FunctioT.Fourier2:
			amplitudes = new Gen[12];
			fases = new Gen[6];
			centerAngles = new Gen[6];
			strength = new Gen[1];
			period = new Gen[1];
			break;
		case FunctioT.Partida_FaseSync:
			amplitudes = new Gen[12];
			fases = new Gen[12];
			centerAngles = new Gen[12];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.Partida_Classic_FaseSync:
			amplitudes = new Gen[18];
			fases = new Gen[18];
			centerAngles = new Gen[18];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.Partida:
			amplitudes = new Gen[24];
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.PartidaFinalConstante:
			amplitudes = new Gen[24];
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.Olistic:
			selector = new Gen(0,(float)(int)FunctioT.Olistic-0.01f);
			amplitudes = new Gen[24];
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.Partida_Classic_FaseSync_Fourier_Knee:
			amplitudes = new Gen[24]; //3 más para cada rodillas 
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case FunctioT.Media_Partida_Classic_FaseSync_Fourier_Knee:
			amplitudes = new Gen[24]; //3 más para cada rodillas 
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		}
		
		for (int i = 0; i < amplitudes.Length; i++)
		{
			amplitudes[i] = new Gen(0,30);
		}
		for (int i = 0; i < fases.Length; i++)
		{
			fases[i] = new Gen(0,Mathf.PI * 2.0f);
		}
		for (int i = 0; i < centerAngles.Length; i++)
		{
			centerAngles[i] = new Gen(-45,45);
		}
		
		
		for (int i = 0; i < strength.Length; i++) {
			strength[i] = new Gen (500, 3000);
		}
		for (int i = 0; i < period.Length; i++) {
			period[i] = new Gen(1,/*(Mathf.PI * 2.0f)*/10); //cambiamos el periodo de (1,5) a (1,10)
		}
	}
	
	private Genome (){
	}
	
	public Genome (FunctioT functionType)
	{
		this.functionType = functionType;

		this.createVectors (functionType);
	}
	
	public Genome init(){
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].generateVal();
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].generateVal();
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            centerAngles[i].generateVal();
        }
		
		for (int i = 0; i < strength.Length; i++)
		{
			strength[i].generateVal();
		}

		for (int i = 0; i < period.Length; i++)
		{
			period[i].generateVal();
		}

		if (functionType == FunctioT.Olistic) {
			selector.generateVal();
		}
		
		return this;
	}
	
	public float getStrength(int i){
		return strength[i].getVal();
	}
	
	public float getPeriod(int i){
		return period[i].getVal();
	}
	
	public float getAmplitude(int i){
		return amplitudes[i].getVal();	
	}
	
	public float getFase(int i){
		return fases[i].getVal();	
	}
	
	public float getCenterAngle(int i){
		return centerAngles[i].getVal();
	}

	public FunctioT getSelector(){
		return (FunctioT)(int)selector.getVal();
	}
	
	public System.Collections.IEnumerator GetEnumerator()
    {
		for (int i = 0; i < strength.Length; i++)
		{
			yield return strength[i];
		}
		for (int i = 0; i < period.Length; i++)
		{
			yield return period[i];
		}
		
		for (int i = 0; i < amplitudes.Length; i++)
        {
            yield return amplitudes[i];
        }
		for (int i = 0; i < fases.Length; i++)
        {
            yield return fases[i];
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            yield return centerAngles[i];
        }

		
		if (functionType == FunctioT.Olistic) {
			yield return selector;
		}
    }
	
	public void print(){
		String s = "strength: ";
		for (int i = 0; i < strength.Length; i++)
		{
			s += strength[i].getVal();
		}
		Debug.Log(s);
		String p = "period: ";
		for (int i = 0; i < period.Length; i++)
		{
			p += period[i].getVal();
		}
		Debug.Log(p);
		
		String a = "Amplitudes: ";
		 for (int i = 0; i < amplitudes.Length; i++)
        {
            a += amplitudes[i].getVal();
        }
		Debug.Log(a);
		String b = "fases: ";
		for (int i = 0; i < fases.Length; i++)
        {
            b+=fases[i].getVal();
        }
		Debug.Log(b);
		//for (int i = 0; i < centerAngles.Length; i++)
        //{
        //    Debug.Log(centerAngles[i]);
        //}
	}
	
	public void saveToFile(String filename){
		FileStream fs = new FileStream(filename, FileMode.Create);

        // Construct a BinaryFormatter and use it to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
        try 
        {
            formatter.Serialize(fs, this);
        }
        catch (SerializationException e) 
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }	
	}
	
	
	public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
		info.AddValue ("functionType", functionType, typeof(FunctioT));
        // Use the AddValue method to specify serialized values.
		//StreamWriter writer = new StreamWriter("save.txt",false);
		for (int i = 0; i < amplitudes.Length; i++)
        {
        	info.AddValue("amplitudes" + i, amplitudes[i].getVal(), typeof(float));
			//writer.WriteLine("amplitudes" + i +": " +  amplitudes[i].getVal());
        }
		for (int i = 0; i < fases.Length; i++)
        {
        	info.AddValue("fases" + i, fases[i].getVal(), typeof(float));
			//writer.WriteLine("fases" + i +": " +  fases[i].getVal());
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
        	info.AddValue("centerAngles" + i , centerAngles[i].getVal(), typeof(float));
			//writer.WriteLine("centerAngles" + i +": " + centerAngles[i].getVal());
        }

		for (int i = 0; i < strength.Length; i++)
		{
			info.AddValue("strength" + i , strength[i].getVal(), typeof(float));
		}

		for (int i = 0; i < period.Length; i++)
		{
			info.AddValue("period" + i , period[i].getVal(), typeof(float));
		}

		if (functionType == FunctioT.Olistic) {
			info.AddValue("selector" , selector.getVal(), typeof(float));
		}

		//writer.Close();
    }

    // The special constructor is used to deserialize values.
	public Genome(SerializationInfo info, StreamingContext context):this()
    {
		try{
			functionType = (FunctioT)info.GetValue ("functionType", typeof(FunctioT));
		}catch(SerializationException e){
			functionType = FunctioT.FaseSync;
		}

		createVectors (functionType);

		//StreamWriter writer = new StreamWriter("load.txt",false);
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].setVal((float) info.GetValue("amplitudes" + i, typeof(float)));
			//writer.WriteLine("amplitudes" + i +": " +  amplitudes[i].getVal());
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].setVal((float) info.GetValue("fases" + i, typeof(float)));
			//writer.WriteLine("fases" + i +": " +  fases[i].getVal());
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            centerAngles[i].setVal((float) info.GetValue("centerAngles" + i, typeof(float)));
			//writer.WriteLine("centerAngles" + i +": " + centerAngles[i].getVal());
        }

		try{
			for (int i = 0; i < strength.Length; i++)
			{
				strength[i].setVal((float) info.GetValue("strength" + i, typeof(float)));
			}
			for (int i = 0; i < period.Length; i++)
			{
				period[i].setVal((float) info.GetValue("period" + i, typeof(float)));
			}
		}catch(SerializationException e){
			strength[0].setVal((float) info.GetValue("strength", typeof(float)));
			period[0].setVal((float) info.GetValue("period", typeof(float)));
		}

		if (functionType == FunctioT.Olistic) {
			selector.setVal((float)info.GetValue("selector" , typeof(float)));
		}

		//writer.Close();
    }
}

