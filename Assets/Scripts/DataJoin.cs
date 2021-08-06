using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Start()
    {
        StartCoroutine(tiempo_de_carga(15));
    }

    public Data getBaseDato() {
        return BaseDato;
    }

    public int Npersonajes()
    {
        return BaseDato.personajes.Count;
    }

    public int Nversiones(int index)
    {
        Personajes pers = BaseDato.personajes[index - 1];
        return pers.GetNVersiones();
    }

    public void SetIndexPer(int index) {
        indexPers = index;
    }

    public int GetIndexPer() {
        return indexPers;
    }

    public void SetIndexVer(int index)
    {
        indexVer = index;
    }

    public int GetIndexVer()
    {
        return indexVer;
    }

    IEnumerator tiempo_de_carga(int seg) {
        cargar_datos();

        yield return new WaitForSeconds(seg);
        SceneManager.LoadScene("carga");

    }

    /*
    public void presentar_data() {
        foreach (Personajes p in BaseDato.personajes) {
            print("personaje: "+ p.GetName());

            foreach (Versiones v in p.Getversiones()) {
                print("version: "+v.GetVerName());
            }
        }

    }
    */



    public void cargar_datos() {

        string m_Path = Application.dataPath;

        string pathgaby = m_Path + "/Assets/imagenes/Personajes/modelos/menuGaby.png";
        string pathloly = m_Path + "/Assets/imagenes/Personajes/modelos/menuLoly.png";
        string pathoscar = m_Path + "/Assets/imagenes/Personajes/modelos/manuOscar.png";
        string pathkike = m_Path + "/Assets/imagenes/Personajes/modelos/menuKike.png";


        BaseDato = new Data();

        List<Personajes> figuras = new List<Personajes>();

        Personajes gaby = new Personajes("FP1", "GABY", pathgaby);
        Personajes kike = new Personajes("FP2", "KIKE", pathkike);
        Personajes loly = new Personajes("FP3", "LOLY", pathloly);
        Personajes oscar = new Personajes("FP4", "OSCAR", pathoscar);
        
        figuras.Add(gaby);
        figuras.Add(kike);
        figuras.Add(loly);
        figuras.Add(oscar);

        
        InformationGaby vergaby = new InformationGaby();
        gaby.SetVersiones(vergaby.GetVersiones());


        InformationLoly verloly = new InformationLoly();
        loly.SetVersiones(verloly.GetVersiones());


        InformationKike verkike = new InformationKike();
        kike.SetVersiones(verkike.GetVersiones());











        BaseDato.personajes = figuras;
    }


}
