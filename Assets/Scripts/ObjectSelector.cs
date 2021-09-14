using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using Unity.VectorGraphics;

public class ObjectSelector : MonoBehaviour
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
        indice = DataJoin.instance.Npersonajes();
        //indice = 17;
        cargarlienzos();
        

        StartCoroutine(cargar_graficos());
    }

    private void borrar_lienzos()
    {
        btn_avanza.SetActive(false);
        btn_retrocede.SetActive(false);

        foreach (GameObject lienzo in personaje)
        {
            lienzo.SetActive(false);
        }
    }

    private void cargarlienzos()
    {

        if (indice < 10)
        {
            personaje[indice-1].SetActive(true);
        }
        else {

            btn_avanza.SetActive(true);
            btn_retrocede.SetActive(true);

            personaje[8].SetActive(true);
            personaje[indice-1].SetActive(false);
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

    public void cambiazo(Camera main) {
        Vector3 aux = main.transform.position;
        if (aux.x > 0) {
            aux.x = 0;
            personaje[8].SetActive(true);
            personaje[indice-1].SetActive(false);
        } else if (aux.x == 0){
            aux.x = 18.5f;
            personaje[8].SetActive(false);
            personaje[indice - 1].SetActive(true);
        }

         main.transform.position = aux;

    }


    
    IEnumerator cargar_graficos() {
        

        int i=1;

        foreach (Personajes per in DataJoin.instance.getBaseDato().data) {

            if (per.graphic_lines.Count != 0 && per.graphic_lines[0].graphic_line_parts.Count != 0)
            {

                string btn = "lienzo" + i.ToString();
                GameObject padre = GameObject.Find(btn);

                UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture("http://207.246.65.177/static/media/" + per.graphic_lines[0].graphic_line_image);
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    print(webRequest.error);
                }
                else
                {
                    GameObject imagen = new GameObject();
                    //imagen.name = per.graphic_lines[0].graphic_line_name;
                    imagen.AddComponent<SpriteRenderer>();
                    SpriteRenderer sr = imagen.GetComponent<SpriteRenderer>();

                    var tessOptions = new VectorUtils.TessellationOptions()
                    {
                        StepDistance = 100.0f,
                        MaxCordDeviation = 0.5f,
                        MaxTanAngleDeviation = 0.1f,
                        SamplingStepSize = 0.01f
                    };

                    byte[] result = webRequest.downloadHandler.data;
                    string imagenSVG = System.Text.Encoding.Default.GetString(result);
                    var sceneInfo = SVGParser.ImportSVG(new StringReader(imagenSVG));
                    var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);
                    sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
                    sr.sortingOrder = 3;

                    imagen.transform.parent = padre.transform;
                    imagen.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                    imagen.transform.localPosition = new Vector3(-2, 2.5f, 0);

                }
            }
            i++;

        }
        
    }


}
