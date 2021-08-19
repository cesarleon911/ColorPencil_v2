﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
        cargarlienzos(DataJoin.instance.Npersonajes());
        StartCoroutine(cargar_graficos());
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

    IEnumerator cargar_graficos() {

        int i=1;
        foreach (Personajes per in DataJoin.instance.getBaseDato().personajes) {
            string btn = "btnL" + i.ToString();
            Image fuente = GameObject.Find(btn).GetComponent<Image>();

            Texture2D SpriteTexture = null;
           
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(per.url_ref);
            yield return webRequest.SendWebRequest();

            
            if (webRequest.isNetworkError)
            {
                print(webRequest.error);
            }
            else
            {
                SpriteTexture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            }

            
            Sprite newsprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), 100.0f);
            fuente.sprite = newsprite;
            i++;
        }
    }




    /*
     * 
     * carga de una textura desde un archivo en el directorio raiz del proyecto de unity
    private Texture2D LoadTexture(string FilePath)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           
            if (Tex2D.LoadImage(FileData))         
                return Tex2D;                 
        }
        return null;
    }*/
}
