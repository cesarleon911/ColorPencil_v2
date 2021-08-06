using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectSelectorVersion : MonoBehaviour
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
        cargarlienzos(DataJoin.instance.Nversiones(DataJoin.instance.GetIndexPer()));
    }

    private void cargarlienzos(int cant)
    {
        personaje[cant - 1].SetActive(true);
        cargar_graficos();
    }

    private void borrar_lienzos()
    {
        foreach (GameObject lienzo in personaje)
        {
            lienzo.SetActive(false);
        }
    }

    private void cargar_graficos()
    {
        Personajes per = DataJoin.instance.getBaseDato().personajes[DataJoin.instance.GetIndexPer() - 1];

        int i = 1;
        foreach (Versiones ver in per.Getversiones()) {
            string btn = "lienzo" + i.ToString();
            GameObject LienzoPrincipal = GameObject.Find(btn);

            int sort = 3;
            foreach (Partes parte in ver.GetPartes()) {
                //aqui debo crear los lienzos añadidos 
                GameObject obj = new GameObject();
                obj.AddComponent<SpriteRenderer>();
                obj.AddComponent<PolygonCollider2D>();
                SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                sr.sortingOrder = sort;
                sort++;
                Texture2D SpriteTexture = LoadTexture(parte.getURL());
                sr.sprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0,0), 100.0f);

                //aqui me falla la wea
                obj.transform.parent = LienzoPrincipal.transform;

        
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                obj.transform.localPosition = new Vector3(-2, -2, 0);

            }
            i++;
        }

    }

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
    }
}
