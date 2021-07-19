using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public List<GameObject> personaje;

    private void Start()
    {
        personaje.Add(GameObject.Find("1"));
        personaje.Add(GameObject.Find("2"));
        personaje.Add(GameObject.Find("3"));
        personaje.Add(GameObject.Find("4"));
        personaje.Add(GameObject.Find("5"));
        personaje.Add(GameObject.Find("6"));
        personaje.Add(GameObject.Find("7"));
        personaje.Add(GameObject.Find("8"));
        personaje.Add(GameObject.Find("9"));

        foreach(GameObject lienzo in personaje) 
        {
            lienzo.SetActive(false);
        }



        //aqui se supone que se debe de cargar los elementos a la base local 

        //con la cantidad de personajes se activa la opcion de personajes
        cargarlienzos(3);
        //luego de que se carga los lienzos con las imagenes de referencia


    }

    private void cargarlienzos(int cant)
    {
        personaje[cant-1].SetActive(true);
    }

    
}
