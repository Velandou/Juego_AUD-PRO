using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class Osc : MonoBehaviour
{
    //[Range(20, 20000)]
    float frecuencia = 100;
    public int FM = 44100;
    public float TiempoSegundos = 2.0f;
    int Funcion = 0;
    AudioSource audioSource;
    int timeIndex = 0;

    int TM;


    public List<float> frecuencias = new List<float>();
    public enum WaveFormType
    {
        Sine,
        Square,
        Sawtooth,
        Triangle
    }
    public WaveFormType waveFormType = WaveFormType.Sine;
    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0;
        audioSource.Stop();


        GenerateWaveTable();
        env = GetADSR();
        frecuencia = 0;
    }
    void Start()
    {
        frecuencias.Add(0f);
        env = GetADSR();
    }

    public int funcion = 0;
    void Update()
    {
        //env = GetADSR();
        TM = (int)(FM / frecuencia);
        //Funcion = funcionDropDown;
        //textoOctava.SetText(octava.value.ToString());
    }


    public float CreateSeno(int timeIndex, float frecuencia)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frecuencia / FM);
    }
    public float CreateSquare(int timeIndex, float frecuencia)
    {
        return Mathf.Sign(Mathf.Sin(2 * Mathf.PI * timeIndex * frecuencia / FM));
    }

    public float CreateTriangle(int timeIndex, float frecuencia)
    {
        float m1 = 1 / (TM / 4.0f);
        float m2 = -2 / ((TM * (3 / 4.0f) - (TM - 4.0f)));
        float m3 = 1 / (TM - (TM * (3 / 4.0f)));

        float b1 = 1 - (m1 * (TM / 4.0f));
        float b2 = 1 - (m2 * (TM / 4.0f));
        float b3 = 0 - (m3 * TM);

        if (timeIndex <= (TM / 4.0f)) return (m1 * timeIndex + b1);
        else if (timeIndex > (TM / 4.0f) && timeIndex <= (TM * (3 / 4.0f))) return (m2 * timeIndex + b2);
        else return (m3 * timeIndex + b3);
    }

    public float CreateSawTooth(int timeIndex, float frecuencia)
    {
        float m1 = 1 / ((TM / 2.0f));
        float m2 = 1 / (TM - (TM / 2.0f));

        float b1 = 1 - (m1 * (TM / 2.0f));
        float b2 = 0 - (m2 * TM);

        if (timeIndex <= (TM / 2)) return (m1 * timeIndex + b1);
        else return (m2 * timeIndex + b2);
    }

    public float[] waveTable;
    public int waveTableSize = 2048;

    private void GenerateWaveTable()
    {
        waveTable = new float[waveTableSize];
        float f = FM / waveTableSize;
        for (int i = 0; i < waveTableSize; i++)
        {
            switch (waveFormType)
            {
                case WaveFormType.Sine:
                    waveTable[i] += CreateSeno(i, f);
                    break;
                case WaveFormType.Square:
                    waveTable[i] += CreateSquare(i, f);
                    break;

                case WaveFormType.Triangle:
                    waveTable[i] += CreateTriangle(i, f);
                    break;
                case WaveFormType.Sawtooth:
                    waveTable[i] += CreateSawTooth(i, f);
                    break;
            }
        }
    }

    public int Octava = 0;
    public void PlayPiano(float function)
    {
        frecuencia = function * Mathf.Pow(2, Octava);

        if (!audioSource.isPlaying)
        {
            timeIndex = 0;
            ADSRindex = 0;
            funcion = 0;
            //Funcion = (funcionDropDown);
            audioSource.Play();

        }
        else audioSource.Stop();

    }
    public void StopPiano()
    {
        audioSource.Stop();
        ADSRindex = 0;
        timeIndex = 0;

    }
    int Vref = 32768;
    float DBFStoLinear(float dBfs)
    {
        return Mathf.Pow(10f, (dBfs / 20f));
    }
    public float nivel = 1;

    [Range(5, 200)]
    public float A = 100;

    [Range(10, 300)]
    public float D = 100;

    [Range(100, 5000)]
    public float S = 100;

    [Range(0.001f, 1f)]
    public float SLevel = 0.7f;


    [Range(10, 500)]
    public float R = 100;

    int ADSRindex = 0;
    float[] env;

    float[] GetADSR()
    {
        int totalADSRSize = (int)(FM * (A + D + S + R));

        float[] envelope = new float[totalADSRSize];

        int ASamples = (int)(FM * A);
        int DSamples = (int)(FM * D);
        int SSamples = (int)(FM * S);
        int RSamples = (int)(FM * R);

        for (int i = 0; i < totalADSRSize; i++)
        {
            float value = 0f;

            if (i < ASamples) value = Mathf.Lerp(0f, 1f, (float)i / ASamples);
            else if (i < ASamples + DSamples) value = Mathf.Lerp(1f, SLevel, (float)i / DSamples);
            else if (i < ASamples + DSamples + SSamples) value = SLevel;
            else if (i < ASamples + DSamples + SSamples + RSamples) value = Mathf.Lerp(SLevel, 0f, (float)i / RSamples);
        }
        return envelope;
    }
    public bool isMono = true;
    float[] phase = new float[10];
    float phaseM;
    void OnAudioFilterRead(float[] data, int channels)
    {
        if (isMono)
        {
            for (int i = 0; i < data.Length; i += channels)
            {

                float E;
                if (ADSRindex < env.Length) E = env[ADSRindex];
                else E = 0.0001f;

                float currentSample = 0f;

                try
                {
                    currentSample += waveTable[(int)(phaseM * waveTableSize)];
                    data[i] = currentSample * nivel;
                    if (channels == 2) data[i + 1] = currentSample * nivel;
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    print("a An IndexOutOfRangeException occurred.");
                    print("Error message: " + ex.Message);
                }
                try
                {
                    phaseM += frecuencia / FM;
                    if (phaseM > 1f) phaseM -= 1f;
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    print("b An IndexOutOfRangeException occurred.");
                    print("Error message: " + ex.Message);
                }
                ADSRindex++;

            }

        }
        else
        {
            for (int i = 0; i < data.Length; i++)
            {
                float currentSample = 0;
                
                for (int j = 0; j < frecuencias.Count; j++)
                {
                    try
                    {
                        //if (j != 0) currentSample += waveTable[(int)(phase[j] * waveTableSize)] * nivel;
                        currentSample += waveTable[(int)(phaseM * waveTableSize)] * nivel;
                        data[i] = currentSample / frecuencias.Count;
                        //for (int channel = 0; channel < channels; channel++) data[i + channel] = currentSample / frecuencias.Count;

                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                        print(" c An IndexOutOfRangeException occurred.");
                        print(j.ToString() + " Error message: " + ex.Message);
                    }
                    try
                    {
                        phase[j] += frecuencias[j] / FM;
                        if (phase[j] > 1f) phase[j] -= 1f;
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                        print(" d An IndexOutOfRangeException occurred.");
                        print(j.ToString() + " Error message: " + ex.Message);
                    }
                }
                ADSRindex++;
            }
        }
    }
        ///
        //void OnAudioFilterRead(float[] data, int channels)
        //{
        //    if (isMono)
        //    {
        //        for (int i = 0; i < data.Length; i += channels)
        //        {
        //            float E;
        //            if (ADSRindex < env.Length) E = env[ADSRindex];
        //            else E = 0.0001f;

        //            float currentSample = 0f;

        //            for (int j = 0; j < frecuencias.Count; j++)
        //            {
        //                try
        //                {
        //                    float amplitude = waveTable[(int)(phase[j] * waveTableSize)] * nivel;
        //                    currentSample += amplitude;
        //                }
        //                catch (System.IndexOutOfRangeException ex)
        //                {
        //                    print("An IndexOutOfRangeException occurred.");
        //                    print(j.ToString() + " Error message: " + ex.Message);
        //                }
        //                try
        //                {
        //                    phase[j] += frecuencias[j] / FM;
        //                    if (phase[j] > 1f) phase[j] -= 1f;
        //                }
        //                catch (System.IndexOutOfRangeException ex)
        //                {
        //                    print("An IndexOutOfRangeException occurred.");
        //                    print(j.ToString() + " Error message: " + ex.Message);
        //                }
        //            }

        //            data[i] = currentSample * nivel;
        //            if (channels == 2) data[i + 1] = currentSample * nivel;

        //            ADSRindex++;
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < data.Length; i += channels)
        //        {
        //            float E;
        //            if (ADSRindex < env.Length) E = env[ADSRindex];
        //            else E = 0.0001f;

        //            float currentSampleLeft = 0f;
        //            float currentSampleRight = 0f;

        //            for (int j = 0; j < frecuencias.Count; j++)
        //            {
        //                try
        //                {
        //                    float amplitude = waveTable[(int)(phase[j] * waveTableSize)] * nivel;
        //                    currentSampleLeft += amplitude;
        //                    currentSampleRight += amplitude;
        //                }
        //                catch (System.IndexOutOfRangeException ex)
        //                {
        //                    print("An IndexOutOfRangeException occurred.");
        //                    print(j.ToString() + " Error message: " + ex.Message);
        //                }
        //                try
        //                {
        //                    phase[j] += frecuencias[j] / FM;
        //                    if (phase[j] > 1f) phase[j] -= 1f;
        //                }
        //                catch (System.IndexOutOfRangeException ex)
        //                {
        //                    print("An IndexOutOfRangeException occurred.");
        //                    print(j.ToString() + " Error message: " + ex.Message);
        //                }
        //            }

        //            data[i] = currentSampleLeft * nivel;
        //            data[i + 1] = currentSampleRight * nivel;

        //            ADSRindex++;
        //        }
        //    }
        //}

    }
