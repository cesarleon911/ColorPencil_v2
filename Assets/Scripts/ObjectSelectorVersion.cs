using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VectorGraphics;

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

    
    public void cargar_graficos()
    {
        Personajes per = DataJoin.instance.getBaseDato().personajes[DataJoin.instance.GetIndexPer() - 1];

        int i = 1;
        foreach (Versiones ver in per.versiones) {
            string btn = "lienzo" + i.ToString();
            GameObject LienzoPrincipal = GameObject.Find(btn);
            
            foreach (Partes parte in ver.partes) {

                var tessOptions = new VectorUtils.TessellationOptions()
                {
                    StepDistance = 100.0f,
                    MaxCordDeviation = 0.5f,
                    MaxTanAngleDeviation = 0.1f,
                    SamplingStepSize = 0.01f
                };

                var sceneInfo = SVGParser.ImportSVG(new StringReader(parte.imagen));
                var shape = sceneInfo.NodeIDs[parte.nombre].Shapes[0];
                shape.Fill = new SolidFill() { Color = parte.color };
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

                obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                obj.transform.localPosition = new Vector3(-2,2.5f,0);

            }
            i++;


            //esto es solo para cargar la primera emocion
            if (ver.emociones.Count > 0) {
                cargarcara(btn, ver.emociones[0]);
            }
            
        }

    }

    public void cargarcara(string btn, Emociones carita) {

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

        obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        obj.transform.localPosition = new Vector3(-2, 2.5f, 0);
    }




}
