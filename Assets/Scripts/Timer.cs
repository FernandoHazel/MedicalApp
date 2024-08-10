using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Variables para el timer
    public TextMeshProUGUI timerText;
    public float elapsedTime = 0f; //Tiempo transcurrido desde que inicia el temporalizador
    private bool isRunning = false;
    
    void Start()
    {
        //Tomamos el tiempo transcurrido de la variable global
        elapsedTime = GameManager.Instance.globalElapsedTime;
        isRunning = GameManager.Instance.isRunning;
        UpdateTimerText(elapsedTime);
    }

    //Este c�digo se ejecuta cuando la escena termina
    private void OnDestroy()
    {
        //Cuando la escena termina tomamos el tiempo de esta escena 
        //y lo asignamos a la variable global
        GameManager.Instance.globalElapsedTime = elapsedTime;
        GameManager.Instance.isRunning = isRunning;
    }

    void Update()
    {
        //Echamos a correr el tiempo solo si el booleano es verdadero
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("elapsedTime: " + elapsedTime);
            UpdateTimerText(elapsedTime);
        }
    }

    //El bot�n de inicio de tiempo ejecuta este m�todo
    public void StartTimer()
    {
        isRunning = true;
    }
    //El bot�n de detener tiempo ejecuta este m�todo
    public void StopTimer()
    {
        isRunning = false;
    }
    //El bot�n de reset usa este m�todo
    public void ResetTimer()
    {
        elapsedTime = 0f;
        timerText.text = "00:00:00";
    }

    private void UpdateTimerText(float time) //time son los segundos con decimales
    {
        //Una hora tiene 3600 segundos
        int hours = Mathf.FloorToInt(time / 3600f);
        //Los minutos son los segundos que sobran de las horas entre 60
        int minutes = Mathf.FloorToInt((time % 3600f) / 60f);
        //Los segundos son el sobrante de los minutos
        int seconds = Mathf.FloorToInt(time % 60f);
        //Debug.Log($"{hours}:{minutes}:{seconds}");

        //Aqu� le damos formato al texto en la UI y le pasamos las variables que obtuvimos
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
