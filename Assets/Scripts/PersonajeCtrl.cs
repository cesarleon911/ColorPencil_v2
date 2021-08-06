using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class PersonajeCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        cargar_graficos();
    }


    private void cargar_graficos()
    {
        Personajes per = DataJoin.instance.getBaseDato().personajes[DataJoin.instance.GetIndexPer() - 1];
        Versiones ver = per.Getversion(DataJoin.instance.GetIndexVer());

        GameObject nombre = GameObject.Find("personaje");
        nombre.GetComponent<Text>().text = per.GetName();


        GameObject LienzoPrincipal = GameObject.Find("fondolienzo");
        //Transform aux = LienzoPrincipal.transform;
        int sort = 3;
        foreach (Partes parte in ver.GetPartes())
        {

            //aqui debo crear los lienzos añadidos 
            GameObject obj = new GameObject();
            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sortingOrder = sort;
            sort++;
            Texture2D SpriteTexture = LoadTexture(parte.getURL());
            sr.sprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), 100.0f);

            //aqui me falla la wea
            obj.transform.parent = LienzoPrincipal.transform;
            obj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            obj.transform.localPosition = new Vector3(-2.5f, -3f, 0);

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
