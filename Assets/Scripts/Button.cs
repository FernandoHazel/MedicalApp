using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //Cargamos la escena que nos pidan
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
