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

        borrar_lienzos();
        cargarlienzos(4);
    }

    private void cargarlienzos(int cant)
    {
        personaje[cant-1].SetActive(true);
    }

    private void borrar_lienzos() {
        foreach (GameObject lienzo in personaje)
        {
            lienzo.SetActive(false);
        }
    }

}
