using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class DataJoin : MonoBehaviour
{
    public static DataJoin instance;
    private Data BaseDato;
    private int indexPers;
    private int indexVer;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start(){
        this.BaseDato = new Data();
        StartCoroutine(tiempo_de_carga(3));
    }

    public int Npersonajes()
    {
        return BaseDato.personajes.Count;
    }

    public Data getBaseDato()
    {
        return BaseDato;
    }

    public void SetIndexPer(int index)
    {
        indexPers = index;
    }

    public void SetIndexVer(int index)
    {
        indexVer = index;
    }

    public int GetIndexPer()
    {
        return indexPers;
    }

    public int Nversiones(int index)
    {
        Personajes pers = BaseDato.personajes[index-1];
        return pers.versiones.Count;
    }

    
    public int GetIndexVer(){
        return indexVer;
    }
    

    IEnumerator tiempo_de_carga(int seg) {
      
        //peticiones a las base de datos
        string uri_per = "localhost:4000/apipersonajes";
        string uri_ver = "localhost:4000/apiversiones";
        string uri_par = "localhost:4000/apipartes";
        string uri_emo = "localhost:4000/apiemociones";
        string uri_acc = "localhost:4000/apiaccesorios";

        List<Personajes> personajes = new List<Personajes>();
        List<Versiones> versiones = new List<Versiones>();
        List<Partes> partes = new List<Partes>();
        List<Emociones> emociones = new List<Emociones>();
        List<Accesorios> accesorios = new List<Accesorios>();


        //para cargar personajes
        UnityWebRequest webRequest1 = UnityWebRequest.Get(uri_per);
        yield return webRequest1.SendWebRequest();

        if (webRequest1.isNetworkError)
        {
            print(webRequest1.error);
        }
        else {
            var listado = JsonConvert.DeserializeObject<List<Personajes>>(webRequest1.downloadHandler.text);

       
            foreach (Personajes prod in listado)
            {
                Personajes aux = new Personajes(prod.id, prod.nombre, prod.url_ref);
                personajes.Add(aux);
            }
           
        }

        //para cargar versiones
        UnityWebRequest webRequest2 = UnityWebRequest.Get(uri_ver);
        yield return webRequest2.SendWebRequest();

        if (webRequest2.isNetworkError)
        {
            print(webRequest2.error);
        }
        else
        {
            var listado2 = JsonConvert.DeserializeObject<List<Versiones>>(webRequest2.downloadHandler.text);

            foreach (Versiones prod in listado2)
            {
                Versiones aux = new Versiones(prod.idV, prod.personaid, prod.numVersion);
                versiones.Add(aux);
            }
           
        }


        //cargar todas las partes
        UnityWebRequest webRequest3 = UnityWebRequest.Get(uri_par);
        yield return webRequest3.SendWebRequest();

        if (webRequest3.isNetworkError)
        {
            print(webRequest3.error);
        }
        else
        {
            var listado3 = JsonConvert.DeserializeObject<List<Partes>>(webRequest3.downloadHandler.text);

            foreach (Partes prod in listado3)
            {
                Partes aux = new Partes(prod.idP, prod.numParte, prod.nombre, prod.imagen, prod.numVersion, prod.personaid, Color.white);
                partes.Add(aux);
            }
            
        }

        //cargar todas las emociones
        UnityWebRequest webRequest4 = UnityWebRequest.Get(uri_emo);
        yield return webRequest4.SendWebRequest();

        if (webRequest4.isNetworkError)
        {
            print(webRequest4.error);
        }
        else
        {
            var listado = JsonConvert.DeserializeObject<List<Emociones>>(webRequest4.downloadHandler.text);

            foreach (Emociones prod in listado)
            {
                Emociones aux = new Emociones(prod.idE, prod.numEmo, prod.nombre, prod.imagen, prod.numVersion, prod.personaid, "#ffffff");
                emociones.Add(aux);
            }
            
        }

        //cargar todos los accesorios
        UnityWebRequest webRequest5 = UnityWebRequest.Get(uri_acc);
        yield return webRequest5.SendWebRequest();

        if (webRequest5.isNetworkError)
        {
            print(webRequest5.error);
        }
        else
        {
            var listado = JsonConvert.DeserializeObject<List<Accesorios>>(webRequest5.downloadHandler.text);

            foreach (Accesorios prod in listado)
            {
                Accesorios aux = new Accesorios(prod.idA, prod.numAcc, prod.nombre, prod.imagen, prod.numVersion, prod.personaid, "#ffffff");
                accesorios.Add(aux);
            }
            
        }

        //armar la base de datos
        foreach (Personajes p in personajes)
        {
            foreach (Versiones v in versiones)
            {
                if (v.personaid == p.id) {
                    p.versiones.Add(v);
                }
            }
        }

        foreach (Versiones v in versiones)
        {
            foreach (Accesorios a in accesorios)
            {
                if (a.personaid == v.personaid && a.numVersion == v.numVersion) {
                    v.accesorios.Add(a);
                }
            }

            foreach (Emociones e in emociones)
            {
                if (e.personaid == v.personaid && e.numVersion == v.numVersion)
                {
                    v.emociones.Add(e);
                }
            }

            foreach (Partes par in partes)
            {
                if (par.personaid == v.personaid && par.numVersion == v.numVersion)
                {
                    v.partes.Add(par);
                }
            }
        }

        this.BaseDato.user = "userofgamegenerate";
        this.BaseDato.personajes = personajes;

        yield return new WaitForSeconds(seg);

        //cargado de datos de los personajes
        SceneManager.LoadScene("carga");
    }
    

}
