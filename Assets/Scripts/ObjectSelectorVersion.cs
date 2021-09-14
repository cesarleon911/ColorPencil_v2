using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VectorGraphics;

public class ObjectSelectorVersion : MonoBehaviour
{
    public List<GameObject> personaje;
    public GameObject btn_avanza;
    public GameObject btn_retrocede;
    private int indice;

    private void Start()
    {
        btn_avanza = GameObject.Find("btnAvanza");
        btn_retrocede = GameObject.Find("btnRetrocede");

        personaje.Add(GameObject.Find("1"));
        personaje.Add(GameObject.Find("2"));
        personaje.Add(GameObject.Find("3"));
        personaje.Add(GameObject.Find("4"));
        personaje.Add(GameObject.Find("5"));
        personaje.Add(GameObject.Find("6"));
        personaje.Add(GameObject.Find("7"));
        personaje.Add(GameObject.Find("8"));
        personaje.Add(GameObject.Find("9"));
        personaje.Add(GameObject.Find("10"));
        personaje.Add(GameObject.Find("11"));
        personaje.Add(GameObject.Find("12"));
        personaje.Add(GameObject.Find("13"));
        personaje.Add(GameObject.Find("14"));
        personaje.Add(GameObject.Find("15"));
        personaje.Add(GameObject.Find("16"));
        personaje.Add(GameObject.Find("17"));
        personaje.Add(GameObject.Find("18"));

        borrar_lienzos();

        indice = DataJoin.instance.Nversiones(DataJoin.instance.GetIndexPer());
        //indice = 14;
        cargarlienzos();
        cargar_graficos();
    }

    public void borrar_lienzos()
    {
        btn_avanza.SetActive(false);
        btn_retrocede.SetActive(false);

        foreach (GameObject lienzo in personaje)
        {
            lienzo.SetActive(false);
        }


    }

    public void cargarlienzos() {

        if (indice < 10)
        {
            personaje[indice - 1].SetActive(true);
        }
        else
        {

            btn_avanza.SetActive(true);
            btn_retrocede.SetActive(true);

            personaje[8].SetActive(true);
            personaje[indice - 1].SetActive(false);
        }
    }

    public void btn_new_page(Camera main)
    {
        cambiazo(main);
    }

    public void btn_back_page(Camera main)
    {
        cambiazo(main);
    }

    public void cambiazo(Camera main)
    {
        Vector3 aux = main.transform.position;
        if (aux.x > 0)
        {
            aux.x = 0;
            personaje[8].SetActive(true);
            personaje[indice - 1].SetActive(false);
        }
        else if (aux.x == 0)
        {
            aux.x = 18.5f;
            personaje[8].SetActive(false);
            personaje[indice - 1].SetActive(true);
        }

        main.transform.position = aux;

    }

    public void cargar_graficos() {
        Personajes per = DataJoin.instance.getBaseDato().data[DataJoin.instance.GetIndexPer() - 1];
        int i = 1;

        foreach (Versiones ver in per.graphic_lines) {
            if (ver.graphic_line_parts.Count != 0) {
                string btn = "lienzo" + i.ToString();
                GameObject LienzoPrincipal = GameObject.Find(btn);

                foreach (Partes parte in ver.graphic_line_parts) {

                    var tessOptions = new VectorUtils.TessellationOptions()
                    {
                        StepDistance = 100.0f,
                        MaxCordDeviation = 0.5f,
                        MaxTanAngleDeviation = 0.1f,
                        SamplingStepSize = 0.01f
                    };

                    var sceneInfo = SVGParser.ImportSVG(new StringReader(parte.part_svg));
                    var shape = sceneInfo.NodeIDs[parte.part_name].Shapes[0];
                    if ((SolidFill)sceneInfo.NodeIDs[parte.part_name].Shapes[0].Fill == null)
                    {
                        shape.Fill = new SolidFill() { Color = parte.color };
                    }

                    var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);


                    GameObject obj = new GameObject();
                    obj.AddComponent<SpriteRenderer>();
                    SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
                    sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
                    sr.sortingOrder = 3;
                   
                    sr.flipY = false;

                    
                    obj.transform.parent = LienzoPrincipal.transform;

                    obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    obj.transform.localPosition = new Vector3(-2, 2.5f, 0);

                   
                }
            }
            i++;
               
        }
    }
}
