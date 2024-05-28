using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Osc;

public class PlaySong : MonoBehaviour
{
    public Osc Oscilador1, Oscilador2;

    public AudioSource Kick, Snare, Hithat;

    public AudioClip Kick_Clip, Snare_Clip, Hithat_Clip;

    private bool isLose=false;
    /// <summary>
    /// S/////S
    /// </summary>
    Coroutine currentCoroutine;
    Coroutine currentCoroutine2;
    void Start()
    {
        Oscilador1.isMono = true;
        Oscilador2.isMono = true;

        Oscilador1.nivel = 0.7f;
        Oscilador2.nivel = 0.6f;

        

        Kick.volume = 0.8f;
        Snare.volume = 0.8f;
        Hithat.volume = 0.8f;
        //Kick.volume = 0.0f;
        //Snare.volume = 0.0f;
        //Hithat.volume = 0.0f;

        Kick.clip = Kick_Clip;
        Snare.clip = Snare_Clip;
        Hithat.clip = Hithat_Clip;

        isLose = false;
        currentCoroutine = StartCoroutine(Song());
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cancelar la Coroutine actual y empezar la nueva Coroutine
            if (currentCoroutine2 != null)
                StopCoroutine(currentCoroutine2);
            currentCoroutine2 = StartCoroutine(JumpSong());
        }
        //if (isLose)
        //{
        //    print("isLoseTrue");
        //    // Cancelar la Coroutine actual y empezar la nueva Coroutine
        //    if (currentCoroutine != null)
        //        StopCoroutine(currentCoroutine);
        //    currentCoroutine = StartCoroutine(Lose());

        //}
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(Lose());
        }
    }


    public void Play()
    {
        //Oscilador1.Octava = 1;
        //Oscilador2.Octava = 1;
        StartCoroutine(Song());
        Oscilador1.AddComponent<AudioChorusFilter>();
        Oscilador2.AddComponent<AudioChorusFilter>();
    }
    //Muerte
    public void setLooseSong(bool f)
    {
      

        if (f)
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(Lose());
        }
    } 
    
     IEnumerator Lose()
    {
        //float tempo = 70f;
        //float TimePerNote=60/tempo;
        //Oscilador1.PlayPiano(18.354f);
        //yield return new WaitForSeconds(TimePerNote / 2f);
        //Oscilador1.StopPiano();
        float tempo = 200f;
        float TimePerNote = 60 / tempo;

        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Sine;


        Oscilador2.waveFormType = WaveFormType.Triangle;

        float[] frequency = new float[] { 130.81f, 138.59f, 146.83f, 155.56f, 174.61f, 185.00f, 196.00f, 207.65f, 220.00f, 233.08f, 246.94f, 261.63f, 277.18f, 293.66f, 311.13f };
        float decrement = 0.1f;
        while (true)
        {
            for (int i = 1; i < frequency.Length; i++)
            {
                Oscilador1.PlayPiano(frequency[i]);
                yield return new WaitForSeconds(TimePerNote - (decrement * i));
                Oscilador1.StopPiano();
                //TimePerNote = Mathf.Max(TimePerNote - decrement, 60);
            }

        }
        
    } 
    //Saltar
    IEnumerator JumpSong()
    {
        //float tempo = 70f;
        //float TimePerNote=60/tempo;
        //Oscilador1.PlayPiano(18.354f);
        //yield return new WaitForSeconds(TimePerNote / 2f);
        //Oscilador1.StopPiano();
        float tempo = 60f;
        float TimePerNote = 0.3f;
        Oscilador1.nivel = 0.0f;
        Oscilador2.nivel = 1.0f;
        Oscilador2.Octava = 1;
        //Oscilador1.waveFormType = Osc.WaveFormType.Sine;


        Oscilador2.waveFormType = WaveFormType.Triangle;

        float[] frequency = new float[] { 124.81f}; 

       

        for (int i = 0; i < frequency.Length; i++)
        {
            Oscilador2.PlayPiano(frequency[i]);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador2.StopPiano();
            //TimePerNote = Mathf.Max(TimePerNote - decrement, 60);
        }
        Oscilador1.nivel = 1f;

    }

    //Principal nivel 1

    IEnumerator Song()
    {
        float tempo = 70f;
        float TimePerNote = 60 / tempo;


        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Sawtooth;

        Oscilador2.waveFormType = WaveFormType.Triangle;

        while (true)
        {

            
            // Tercera parte de la melod�a
            Oscilador1.PlayPiano(195.998f); // G5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(196.00f); // G3
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Hithat.Stop();

            Oscilador1.PlayPiano(196.00f); // G3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            // Melod�a final
            Oscilador1.PlayPiano(196.00f); // G3
            Kick.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Kick.Stop();

            Oscilador1.PlayPiano(146.83f); // D3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(174.61f); // F3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(130.81f); // C3
            Snare.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Snare.Stop();

            Oscilador1.PlayPiano(146.83f); // D3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            // Final de la canci�n
            Oscilador1.PlayPiano(174.61f); // F3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(164.81f); // E3
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Hithat.Stop();

            Oscilador1.PlayPiano(146.83f); // D3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(138.59f); // Db3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(130.81f); // C3
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(123.47f); // B2
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(110.00f); // A2
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
        }

    }

    //Ganar
    IEnumerator Ganar()
    {

        float tempo = 100f;
        float TimePerNote = 60f / tempo;


        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Square;

        //float[] frequency = new float[] { 329.63f, 329.63f, 329.63f, 261.63f, 329.63f, 392.00f, 261.63f, 392.00f, 329.63f, 440.00f, 493.88f, 466.16f, 440.00f, 392.00f, 329.63f, 392.00f, 440.00f, 349.23f, 392.00f, 329.63f, 261.63f, 293.66f, 493.88f, 261.63f, 392.00f, 329.63f, 440.00f, 493.88f, 466.16f, 440.00f, 392.00f, 329.63f, 392.00f, 440.00f, 349.23f, 392.00f, 329.63f, 261.63f, 293.66f, 493.88f, 392.00f, 369.99f, 349.23f, 311.13f, 329.63f, 415.30f, 440.00f, 261.63f };

        float[] frequency = {
            // Notas del acorde F
            349.23f, // F
            392.00f, // G
            466.16f, // Bb

            // Notas del acorde Bb
            466.16f, // Bb
            523.25f, // C
            587.33f, // D

            // Notas del acorde C
            523.25f, // C
            587.33f, // D
            659.26f  // E
        };

            for (int i = 0; i < frequency.Length; i++)
            {
                Oscilador1.PlayPiano(frequency[i]);
                yield return new WaitForSeconds(TimePerNote);
                Oscilador1.StopPiano();
            }

        //while (true)
        //{


        //}
    }
    IEnumerator Song2()
    {

        float tempo = 120f;
        float TimePerNote = 60f / tempo;


        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Square;

        float[] frequency = new float[]
        {
            220.00f,  // A3
            220.00f,  // A3
            174.61f,  // F3
            195.998f, // G3
            146.83f,  // D3
            164.81f,  // E3
            195.998f, // G3
            184.997f, // F#3
            164.81f,  // E3
            155.56f,  // Eb3
            146.83f,  // D3
            138.59f,  // Db3
            123.47f,  // B2
            220.00f,  // A3
            195.998f, // G3
            184.997f, // F#3
            164.81f,  // E3
            146.83f,  // D3
        };
        while (true)
        {

            for (int i = 0; i < frequency.Length; i++)
            {
                Oscilador1.PlayPiano(frequency[i]);
                yield return new WaitForSeconds(TimePerNote);
                Oscilador1.StopPiano();
            }
        }
        //while (true)
        //{


        //}
    }
    IEnumerator Song3()
    {

        float tempo = 140f;
        float TimePerNote = 60f / tempo;


        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Square;

        float[] frequency = new float[]
        {
            261.63f,  // C4
            293.66f,  // D4
            329.63f,  // E4
            349.23f,  // F4
            392.00f,  // G4
            440.00f,  // A4
            493.88f,  // B4
            523.25f,  // C5
            493.88f,  // B4
            440.00f,  // A4
            392.00f,  // G4
            349.23f,  // F4
            329.63f,  // E4
            293.66f,  // D4
            261.63f,  // C4
            220.00f,  // A3
            246.94f,  // B3
            261.63f,  // C4
            293.66f,  // D4
            329.63f,  // E4
        };
        while (true)
        {

            for (int i = 0; i < frequency.Length; i++)
            {
                Oscilador1.PlayPiano(frequency[i]);
                yield return new WaitForSeconds(TimePerNote);
                Oscilador1.StopPiano();
            }
        }
        //while (true)
        //{


        //}
    }
}
