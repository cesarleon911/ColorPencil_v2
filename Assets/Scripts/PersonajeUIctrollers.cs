using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;
using System.Globalization;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.IO;

public class PersonajeUIctrollers : MonoBehaviour
{
    private Personajes per;
    private Versiones ver;

    //para los botones
    public GameObject btnAcceso;
    public GameObject btnCarita;
    public GameObject pincel;
    public GameObject brush;

    //para los esquemas 
    public GameObject colors;
    public GameObject accesorios;
    public GameObject emociones;

    void start()
    {

        per = DataJoin.instance.getBaseDato().data[DataJoin.instance.GetIndexPer() - 1];
        ver = per.graphic_lines[DataJoin.instance.GetIndexVer() - 1];




        colors.SetActive(false);
        accesorios.SetActive(false);
        emociones.SetActive(false);
        brush.SetActive(false);

        btnAcceso.SetActive(false);
        btnCarita.SetActive(false);
        pincel.SetActive(false);

        cargar_ui_grafics();
    }

    public void cargar_ui_grafics()
    {

        int partes = 0;
        int emociones = 0;
        int accesorios = 0;

        if (ver.graphic_line_parts != null) {
            partes = ver.graphic_line_parts.Count;
        }

        /*
        if (ver.emociones != null) {
            emociones = ver.emociones.Count;
        }

        if (ver.accesorios != null) {
            accesorios = ver.accesorios.Count;
        }*/

        if (partes > 0)
        {
            colors.SetActive(true);
            pincel.SetActive(true);
            brush.SetActive(true);
        }

        if (emociones > 0)
        {
            btnCarita.SetActive(true);
        }

        if (accesorios > 0 )
        {
            btnAcceso.SetActive(true);
        }

    }

    public void btn_brush()
    {
        emociones.SetActive(false);
        accesorios.SetActive(false);

        colors.SetActive(true);
        brush.SetActive(true);
    }

    public void btn_accesorios()
    {
        colors.SetActive(false);
        emociones.SetActive(false);

        brush.SetActive(false);

        accesorios.SetActive(true);

        //cargar_accesorios();
    }

    public void btn_emociones()
    {
        colors.SetActive(false);
        brush.SetActive(false);
        accesorios.SetActive(false);

        emociones.SetActive(true);

        //cargar_emociones();
    }

    public void cargar_emociones()
    {
        int i = 1;
        foreach (Emociones emo in ver.emociones)
        {
            string btn = "btnemo" + i.ToString();
            GameObject fuente = GameObject.Find(btn);

            if (fuente.transform.childCount > 0)
            {
                Debug.Log("ya tiene hijos");
            }
            else {
                var tessOptions = new VectorUtils.TessellationOptions()
                {
                    StepDistance = 100.0f,
                    MaxCordDeviation = 0.5f,
                    MaxTanAngleDeviation = 0.1f,
                    SamplingStepSize = 0.01f
                };

                var sceneInfo = SVGParser.ImportSVG(new StringReader(emo.emot_svg));
                var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);


                //aqui debo crear los lienzos añadidos 
                GameObject obj = new GameObject();
                obj.AddComponent<SpriteRenderer>();
                SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
                sr.sortingOrder = 2;

                obj.transform.parent = fuente.transform;
                obj.transform.localPosition = new Vector3(-5, 2.5f, 0);
                //obj.transform.pivot = new Vector3(-5, 2.5f, 0);
                
            }


            i++;
        }
    }

    public void cargar_accesorios()
    {

        int i = 1;
        foreach (Accesorios acc in ver.accesorios)
        {
            string btn = "btnacc" + i.ToString();
            GameObject fuente = GameObject.Find(btn);

            if (fuente.transform.childCount > 0)
            {
                Debug.Log("ya tiene hijos");
            }else 
            {
                var tessOptions = new VectorUtils.TessellationOptions()
                {
                    StepDistance = 100.0f,
                    MaxCordDeviation = 0.5f,
                    MaxTanAngleDeviation = 0.1f,
                    SamplingStepSize = 0.01f
                };

                var sceneInfo = SVGParser.ImportSVG(new StringReader(acc.acc_svg));
                var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);


                //aqui debo crear los lienzos añadidos 
                GameObject obj = new GameObject();
                obj.AddComponent<SpriteRenderer>();
                SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

                sr.sprite = VectorUtils.BuildSprite(geoms, 1.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
                sr.sortingOrder = 2;

                obj.transform.parent = fuente.transform;
                obj.transform.localPosition = new Vector3(-1, 2.5f, 0);
                //obj.transform.pivot = new Vector3(-1, 2.5f, 0);
            }
            
            i++;
        }

    }

   
}
