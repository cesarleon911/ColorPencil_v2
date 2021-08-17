using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using Unity.VectorGraphics;
using System.Globalization;

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
        Versiones ver = per.versiones[DataJoin.instance.GetIndexVer()-1];

        GameObject nombre = GameObject.Find("personaje");
        nombre.GetComponent<Text>().text = per.nombre;


        GameObject LienzoPrincipal = GameObject.Find("fondolienzo");
    
        foreach (Partes parte in ver.partes)
        {

            var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

            var sceneInfo = SVGParser.ImportSVG(new StringReader(parte.imagen));
            var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



            //aqui debo crear los lienzos añadidos 
            GameObject obj = new GameObject();
            obj.name = parte.nombre;

            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
            sr.sortingOrder = 3;
            sr.flipY = false;

            //aqui se agrega los poligonos
            //AddPolygonCollider2D(obj, sr.sprite, parte.imagen);
           
            //aqui me falla la wea
            obj.transform.parent = LienzoPrincipal.transform;
            obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            obj.transform.localPosition = new Vector3(-2, 2.7f, 0);

        }

        if (ver.emociones.Count>0) {
            cargarcara("fondolienzo", ver.emociones[0]);
        }
        

    }

    public void cargarcara(string btn, Emociones carita)
    {

        GameObject LienzoPrincipal = GameObject.Find(btn);

        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        var sceneInfo = SVGParser.ImportSVG(new StringReader(carita.imagen));
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



        //aqui debo crear los lienzos añadidos 
        GameObject obj = new GameObject();

        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
        sr.sortingOrder = 3;
        sr.flipY = false;


        //aqui me falla la wea
        obj.transform.parent = LienzoPrincipal.transform;

        obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        obj.transform.localPosition = new Vector3(-2, 2.7f, 0);
    }


    /*
    //go es el gameobject que representa la parte
    //sprite es el sprtie creado a partir del svg
    //svg es el string de svg
    
    public static void AddPolygonCollider2D(GameObject go, Sprite sprite, string svg)
    {
        go.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polygon = go.GetComponent<PolygonCollider2D>();
        List<Vector2> points = stringBetween(svg, "<path d=\"", "\"");
        //seteo todos los puntos que stringBetween me devuelve
        polygon.SetPath(0, points);
        polygon.offset = new Vector2(points[0][0], points[0][1]);
    }

    //source es el string de svg
    //Start es el string desde donde quiero recortar en este caso es path
    //End es el string hasta donde voy a recortar en este caso es "
    public static List<Vector2> stringBetween(string Source, string Start, string End)
    {
        string result1 = "";
        string result2 = "";
        int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
        result1 = Source.Substring(StartIndex);
        int EndIndex = result1.IndexOf(End, 0);
        result2 = result1.Substring(0, EndIndex);
        var lista = result2.Split(new char[] { ' ', ',', 'm', 'l', 'c', 'z', 'Z', 'M', 'L', 'C', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        List<Vector2> puntos = new List<Vector2>(lista.Length / 2);
        float valorXactual = 0.000000f;
        float valorYactual = 0.000000f;
        for (var i = 0; i < lista.Length; i = i + 2)
        {
            valorXactual = valorXactual + (float.Parse(lista[i], CultureInfo.InvariantCulture)) / 20.000000f;
            Debug.Log("valory");
            valorYactual = valorYactual + (-1.000000f * ((float.Parse(lista[i + 1], CultureInfo.InvariantCulture)) / 20.000000f));
            Debug.Log(valorYactual);
            if (valorXactual != 0.0f && valorYactual != 0.0f)
            {
                puntos.Add(new Vector2(valorXactual, valorYactual));
            }
        }
        return puntos;
    }
    */


}
