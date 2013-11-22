using System;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Genome:System.Collections.IEnumerable, System.Runtime.Serialization.ISerializable
{
	Gen strength;
	Gen period;
	
	Gen[] amplitudes;
	Gen[] fases;
	Gen[] centerAngles;
	
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
	
	public Genome ()
	{
		amplitudes = new Gen[12];
		fases = new Gen[12];
		centerAngles = new Gen[12];
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i] = new Gen(0,90);
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i] = new Gen(0,Mathf.PI * 2.0f);
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            centerAngles[i] = new Gen(-90,90);
        }
		
		
		strength = new Gen(0,10000);
		period = new Gen(0,/*(Mathf.PI * 2.0f)*/10);
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
		
		
		strength.generateVal();
		period.generateVal();
		
		return this;
	}
	
	public float getStrength(){
		return strength.getVal();
	}
	
	public float getPeriod(){
		return period.getVal();
	}
	
	public float getAmplitude(int i){
		return amplitudes[i].getVal();	
	}
	
	public float getFase(int i){
		return fases[i].getVal();	
	}
	
	public float getCenterAngle(int i){
		return 0; //centerAngles[i].getVal();	//TODO descomentar para usar angulos centrales.
	}
	
	public System.Collections.IEnumerator GetEnumerator()
    {
		yield return strength;
		yield return period;
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
		Debug.Log("strength" + strength.getVal());
		Debug.Log("period" + period.getVal());
		
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
        // Use the AddValue method to specify serialized values.
		
		for (int i = 0; i < amplitudes.Length; i++)
        {
        	info.AddValue("amplitudes" + i, amplitudes[i].getVal(), typeof(float));
        }
		for (int i = 0; i < fases.Length; i++)
        {
        	info.AddValue("fases" + i, fases[i].getVal(), typeof(float));
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
        	info.AddValue("centerAngles" + i, centerAngles[i].getVal(), typeof(float));
        }
		
		
        info.AddValue("strength", strength.getVal(), typeof(float));
        info.AddValue("period", period.getVal(), typeof(float));

    }

    // The special constructor is used to deserialize values.
    public Genome(SerializationInfo info, StreamingContext context):this()
    {
		
		for (int i = 0; i < amplitudes.Length; i++)
        {
            amplitudes[i].setVal((float) info.GetValue("amplitudes" + i, typeof(float)));
        }
		for (int i = 0; i < fases.Length; i++)
        {
            fases[i].setVal((float) info.GetValue("fases" + i, typeof(float)));
        }
		for (int i = 0; i < centerAngles.Length; i++)
        {
            centerAngles[i].setVal((float) info.GetValue("centerAngles" + i, typeof(float)));
        }
		
		
		strength.setVal((float) info.GetValue("strength", typeof(float)));
		period.setVal((float) info.GetValue("period", typeof(float)));
    }
}

