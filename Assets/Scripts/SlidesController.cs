using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidesController : MonoBehaviour
{
    // Lo primero que hacemos nada más iniciar es tomar a todos los hijos (las diapositivas)
    // y las guardamos en una lista, esto nos permite quitar y añadir las queramos sin afectar el fucionamiento
    public List<GameObject> slides = new List<GameObject>();

    //Tomamos los botones
    public GameObject nextButton;
    public GameObject prevButton;

    //El contador definirá el slide en el que vamos
    private int slideIndex = 0;
    void Start()
    {
        // Añadir todos los hijos a la lista slides
        foreach (Transform child in transform)
        {
            slides.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        //Activamos la primer diapositiva y escondemos el botón de anterior
        ActivateSlide(slideIndex);
        controlButtonsVisibility();
    }

    private void ActivateSlide(int slideIndex)
    {
        Debug.Log("slideIndex:" + slideIndex);
        //Primero nos aseguramos de desactivar todas las demas slides
        foreach(GameObject child in slides)
        {
            child.SetActive(false);
        }
        slides[slideIndex].SetActive(true);
    }

    public void NextSlide()
    {
        //Aumentamos el número de slides
        //Solo nos aseguramos de no pasarnos de la última
        if(slideIndex < slides.Count)
        {
            slideIndex++;
            ActivateSlide(slideIndex);
            controlButtonsVisibility();
        }
    }
    public void PrevSlide()
    {
        //Reducimos el ínice de la diapositiva
        //Solo nos aseguramos de no bajar de 0
        if(slideIndex > 0)
        {
            slideIndex--;
            ActivateSlide(slideIndex);
            controlButtonsVisibility();
        }
        
    }

    private void controlButtonsVisibility()
    {
        //Si llegamos al final de la lista desaparecemos el botón de "siguiente"
        if (slideIndex >= slides.Count - 1)
        {
            nextButton.SetActive(false);
        } else {
            nextButton.SetActive(true);
        }

        //Si llegamos a la primera diapositiva desaparecemos el botón de "anterior"
        if (slideIndex <= 0)
        {
            prevButton.SetActive(false);
        } else {
            prevButton.SetActive(true);
        }
    }
}
