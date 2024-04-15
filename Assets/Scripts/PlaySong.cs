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
    /// <summary>
    /// S/////S
    /// </summary>
    Coroutine currentCoroutine;
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


        currentCoroutine = StartCoroutine(Song());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cancelar la Coroutine actual y empezar la nueva Coroutine
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(Song());
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Cancelar la Coroutine actual y empezar la nueva Coroutine
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(Song3());
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(Song2());
        }
    }

    public void Play()
    {
        //Oscilador1.Octava = 1;
        //Oscilador2.Octava = 1;
        StartCoroutine(Song());
        Oscilador1.AddComponent<AudioChorusFilter>();
    }

    IEnumerator Song3()
    {
        //float tempo = 70f;
        //float TimePerNote=60/tempo;
        //Oscilador1.PlayPiano(18.354f);
        //yield return new WaitForSeconds(TimePerNote / 2f);
        Oscilador1.StopPiano();
        float tempo = 70f;
        float TimePerNote = 60 / tempo;

        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Square;


        Oscilador2.waveFormType = WaveFormType.Triangle;

        while (true)
        {

            Oscilador2.frecuencias.Add(130.813f);
            Oscilador2.frecuencias.Add(164.814f);
            Oscilador2.frecuencias.Add(195.998f);
            Oscilador1.PlayPiano(246.942f);
            Kick.Play();
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Snare.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();


            Kick.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(192.998f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();


            Snare.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Oscilador2.frecuencias.Remove(130.813f);
            Oscilador2.frecuencias.Remove(164.814f);
            Oscilador2.frecuencias.Remove(195.998f);
            Snare.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();


            Kick.Play();
            Hithat.Play();
            Oscilador2.frecuencias.Add(293.665f);
            Oscilador2.frecuencias.Add(246.942f);
            Oscilador2.frecuencias.Add(195.998f);
            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Snare.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Snare.Stop();
            Hithat.Stop();

            Kick.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Oscilador2.frecuencias.Remove(293.665f);
            Oscilador2.frecuencias.Remove(246.942f);
            Oscilador2.frecuencias.Remove(195.998f);
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Snare.Play();
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Snare.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Kick.Play();
            Hithat.Play();
            Oscilador2.frecuencias.Add(130.813f);
            Oscilador2.frecuencias.Add(164.814f);
            Oscilador2.frecuencias.Add(195.998f);
            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Kick.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Snare.Play();
            Hithat.Play();
            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote / 2f);
            Oscilador1.StopPiano();
            Snare.Stop();
            Hithat.Stop();

            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote / 2f);
            Hithat.Stop();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();
            Oscilador2.frecuencias.Remove(130.813f);
            Oscilador2.frecuencias.Remove(164.814f);
            Oscilador2.frecuencias.Remove(195.998f);


            Oscilador2.frecuencias.Add(293.665f);
            Oscilador2.frecuencias.Add(246.942f);
            Oscilador2.frecuencias.Add(195.998f);
            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();
            Oscilador2.frecuencias.Remove(293.665f);
            Oscilador2.frecuencias.Remove(246.942f);
            Oscilador2.frecuencias.Remove(195.998f);

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(192.998f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(246.942f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(192.998f);
            yield return new WaitForSeconds(TimePerNote * 2f);
            Oscilador1.StopPiano();
        }
    }

    IEnumerator Song()
    {
        float tempo = 140f;
        float TimePerNote = 60 / tempo;


        Oscilador1.Octava = 1;
        Oscilador1.waveFormType = Osc.WaveFormType.Sawtooth;

        Oscilador2.waveFormType = WaveFormType.Triangle;

        while (true)
        {

            // Notas de la melodia principal
            Oscilador1.PlayPiano(329.63f); // E5
            Kick.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Kick.Stop();

            Oscilador1.PlayPiano(329.63f); // E5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(329.63f); // E5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Snare.Play();
            Oscilador1.PlayPiano(261.63f); // C5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Snare.Stop();

            Oscilador1.PlayPiano(392.00f); // G5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(196.00f); // G3
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Hithat.Stop();

            Oscilador1.PlayPiano(293.66f); // D4
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            // Segunda parte de la melod�a
            Oscilador1.PlayPiano(329.63f); // E5
            Kick.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Kick.Stop();

            Oscilador1.PlayPiano(392.00f); // G5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(196.00f); // G3
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Hithat.Stop();

            Oscilador1.PlayPiano(261.63f); // C5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(220.00f); // A4
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            Oscilador1.PlayPiano(174.61f); // F3
            Hithat.Play();
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();
            Hithat.Stop();

            Oscilador1.PlayPiano(261.63f); // C5
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            // Tercera parte de la melod�a
            Oscilador1.PlayPiano(392.00f); // G5
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

    IEnumerator Song2()
    {

        float tempo = 140f;
        float TimePerNote = 60 / tempo;


        Oscilador1.Octava = 3;
        Oscilador1.waveFormType = Osc.WaveFormType.Sawtooth;

        while(true)
        {
        
            //sol redonda
            Oscilador1.PlayPiano(24.4997f * 4);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //do
            Oscilador1.PlayPiano(16.3516f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //do
            Oscilador1.PlayPiano(16.3516f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol 
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //la
            Oscilador1.PlayPiano(27.5000f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //la
            Oscilador1.PlayPiano(27.5000f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol blanca
            Oscilador1.PlayPiano(24.4997f * 2);
            yield return new WaitForSeconds(TimePerNote* 2);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //re
            Oscilador1.PlayPiano(18.3540f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //re
            Oscilador1.PlayPiano(18.3540f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //do blanca
            Oscilador1.PlayPiano(16.3516f * 2);
            yield return new WaitForSeconds(TimePerNote* 2);
            Oscilador1.StopPiano();

            //|//|
            yield return new WaitForSeconds(TimePerNote);

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //re blanca
            Oscilador1.PlayPiano(18.3540f * 2);
            yield return new WaitForSeconds(TimePerNote* 2);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //re
            Oscilador1.PlayPiano(18.3540f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|//|
            yield return new WaitForSeconds(TimePerNote);

            //do
            Oscilador1.PlayPiano(16.3516f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //do
            Oscilador1.PlayPiano(16.3516f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol 
            Oscilador1.PlayPiano(24.4997f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //la
            Oscilador1.PlayPiano(27.5000f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //la
            Oscilador1.PlayPiano(27.5000f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //sol blanca
            Oscilador1.PlayPiano(24.4997f * 2);
            yield return new WaitForSeconds(TimePerNote* 2);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //fa
            Oscilador1.PlayPiano(21.8268f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //mi
            Oscilador1.PlayPiano(20.6017f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //|
            yield return new WaitForSeconds(TimePerNote);

            //re
            Oscilador1.PlayPiano(18.3540f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //re
            Oscilador1.PlayPiano(18.3540f);
            yield return new WaitForSeconds(TimePerNote);
            Oscilador1.StopPiano();

            //do blanca
            Oscilador1.PlayPiano(16.3516f * 2);
            yield return new WaitForSeconds(TimePerNote* 2);
            Oscilador1.StopPiano();
        }
    }
}
