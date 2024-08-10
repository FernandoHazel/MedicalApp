using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public y static nos va a ayudar a poder referencias GameManager.Instance desde
    //cualquier script sin necesidad de una referencia
    public static GameManager Instance;

    //Este es el tiempo global transcurrido que pasaremos de una escena a otra
    public float globalElapsedTime = 0f;
    public bool isRunning= false;

    private void Awake()
    {
        //Esto se llama SINGLETON, es un patrón que garantiza
        //que siempre exista solo una instancia en la escena
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //Ahora podemos llamar a GameManager.Instance desde cualquier otra clase
        //Ya no hace falta tener una referencia
        Instance = this;

        //Nos aseguramos de que el objeto no se destruya entre escenas
        DontDestroyOnLoad(gameObject);
    }
}
