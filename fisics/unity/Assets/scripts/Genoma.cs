using System;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Genoma:System.Collections.IEnumerable, System.Runtime.Serialization.ISerializable
{

	class NameChangeBinder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			if (typeName == "Genome") {
				return typeof(Genoma);
			} if (typeName == "FunctioT") {
				return typeof(TipoDeIndividuo);
			}
			return null;
		}
	}

	TipoDeIndividuo functionType;
	Gen[] strength;
	Gen[] period;
	
	Gen[] amplitudes;
	Gen[] fases;
	Gen[] centerAngles;

	
	public static Genoma createFromFile(String filename){
		Genoma instance  = null;

        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream(filename, FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();
			formatter.Binder = new NameChangeBinder();
            // Deserialize the hashtable from the file and  
            // assign the reference to the local variable.
            instance = (Genoma) formatter.Deserialize(fs);
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

	public TipoDeIndividuo getFunctionType(){
		return functionType;
	}

	private void crearVectores(TipoDeIndividuo functionType){
		switch (functionType) {
		case TipoDeIndividuo.Clasica:
			amplitudes = new Gen[12];
			fases = new Gen[12];
			centerAngles = new Gen[12];
			strength = new Gen[1];
			period = new Gen[1];
			break;
		case TipoDeIndividuo.Fourier_Partida_FaseSync:
			amplitudes = new Gen[36];
			fases = new Gen[18];
			centerAngles = new Gen[18];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case TipoDeIndividuo.Classic_Partida_FaseSync:
			amplitudes = new Gen[18];
			fases = new Gen[18];
			centerAngles = new Gen[18];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case TipoDeIndividuo.Clasica_Partida:
			amplitudes = new Gen[24];
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case TipoDeIndividuo.Rodilla_Fourier_Classic_FaseSync:
			amplitudes = new Gen[24]; //3 más para cada rodillas 
			fases = new Gen[24];
			centerAngles = new Gen[24];
			strength = new Gen[2];
			period = new Gen[2];
			break;
		case TipoDeIndividuo.Rodilla_CosDoubleFrecuency_Partida_FaseSync:
			amplitudes = new Gen[18];
			fases = new Gen[18];
			centerAngles = new Gen[18];
			strength = new Gen[2];
			period = new Gen[3];
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
	
	private Genoma (){
	}
	
	public Genoma (TipoDeIndividuo functionType)
	{
		this.functionType = functionType;

		this.crearVectores (functionType);
	}
	
	public Genoma init(){
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

	public EnumeradorCircular getStrengthEnumerator(){
		return new EnumeradorCircular(strength.GetEnumerator());
	}
	
	public EnumeradorCircular getPeriodEnumerator(){
		return new EnumeradorCircular(period.GetEnumerator());
	}
	
	public EnumeradorCircular getAmplitudeEnumerator(){
		return new EnumeradorCircular(amplitudes.GetEnumerator());	
	}
	
	public EnumeradorCircular getFaseEnumerator(){
		return new EnumeradorCircular(fases.GetEnumerator());	
	}
	
	public EnumeradorCircular getCenterAngleEnumerator(){
		return new EnumeradorCircular(centerAngles.GetEnumerator());
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
		info.AddValue ("functionType", functionType, typeof(TipoDeIndividuo));
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



		//writer.Close();
    }

    // The special constructor is used to deserialize values.
	public Genoma(SerializationInfo info, StreamingContext context):this()
    {
		try{
			functionType = (TipoDeIndividuo)info.GetValue ("functionType", typeof(TipoDeIndividuo));
		}catch(SerializationException e){
			functionType = TipoDeIndividuo.Classic_Partida_FaseSync;
		}

		crearVectores (functionType);

		StreamWriter writer = new StreamWriter(Probador.getInstance().archivo +".caracteristicas",false);
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].setVal((float) info.GetValue("amplitudes" + i, typeof(float)));
			writer.WriteLine("amplitudes" + i +": " +  amplitudes[i].getVal());
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].setVal((float) info.GetValue("fases" + i, typeof(float)));
			writer.WriteLine("fases" + i +": " +  fases[i].getVal());
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            centerAngles[i].setVal((float) info.GetValue("centerAngles" + i, typeof(float)));
			writer.WriteLine("centerAngles" + i +": " + centerAngles[i].getVal());
        }

		try{
			for (int i = 0; i < strength.Length; i++)
			{
				strength[i].setVal((float) info.GetValue("strength" + i, typeof(float)));
				writer.WriteLine("strength" + i +": " + strength[i].getVal());
			}
			for (int i = 0; i < period.Length; i++)
			{
				period[i].setVal((float) info.GetValue("period" + i, typeof(float)));
				writer.WriteLine("period" + i +": " + period[i].getVal());
			}
		}catch(SerializationException e){
			strength[0].setVal((float) info.GetValue("strength", typeof(float)));
			period[0].setVal((float) info.GetValue("period", typeof(float)));
		}



		writer.Close();
    }
}

