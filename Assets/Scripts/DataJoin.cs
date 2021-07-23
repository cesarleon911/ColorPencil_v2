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

    public void presentar_data() {
        foreach (Personajes p in BaseDato.personajes) {
            print("personaje: "+ p.GetName());

            foreach (Versiones v in p.Getversiones()) {
                print("version: "+v.GetVerName());
            }
        }

    }



    public void cargar_datos() {
        BaseDato = new Data();

        List<Personajes> figuras = new List<Personajes>();

        List<Versiones> versper1 = new List<Versiones>();
        List<Versiones> versper2 = new List<Versiones>();
        List<Versiones> versper3 = new List<Versiones>();
        List<Versiones> versper4 = new List<Versiones>();
        List<Versiones> versper5 = new List<Versiones>();

        List<Partes> parte1 = new List<Partes>();
        List<Partes> parte2 = new List<Partes>();

        Partes part1 = new Partes("p1ver1per1", "ver 1 Parte1", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver11.png");
        Partes part2 = new Partes("p1ver1per1", "ver 1 Parte2", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver12.png");
        Partes part3 = new Partes("p1ver1per1", "ver 1 Parte3", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver13.png");
        Partes part4 = new Partes("p1ver1per1", "ver 1 Parte4", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver14.png");
        parte1.Add(part1);
        parte1.Add(part2);
        parte1.Add(part3);
        parte1.Add(part4);

        Partes part5 = new Partes("p1ver1per1", "ver2 Parte1", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver21.png");
        Partes part6 = new Partes("p1ver1per1", "ver2 Parte2", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver22.png");
        Partes part7 = new Partes("p1ver1per1", "ver2 Parte3", "#fffff", "C:\\Users\\Stefy\\Documents\\pruebasunity\\ver23.png");
        parte2.Add(part5);
        parte2.Add(part6);
        parte2.Add(part7);

        Versiones ver1 = new Versiones("ver1per1", "rectangulo 1", parte1);
        Versiones ver2 = new Versiones("ver2per1", "rectangulo 2", parte2);
        versper1.Add(ver1);
        versper1.Add(ver2);



        Versiones ver3 = new Versiones("ver1per2", "numero 1");
        Versiones ver4 = new Versiones("ver2per2", "numero 2");
        Versiones ver5 = new Versiones("ver3per2", "numero 3");
        versper2.Add(ver3);
        versper2.Add(ver4);
        versper2.Add(ver5);


        Versiones ver6 = new Versiones("ver1per3", "numero 1");
        Versiones ver7 = new Versiones("ver2per3", "numero 2");
        Versiones ver8 = new Versiones("ver3per3", "numero 3");
        Versiones ver9 = new Versiones("ver4per3", "numero 4");
        Versiones ver10 = new Versiones("ver5per3", "numero 5");
        versper3.Add(ver6);
        versper3.Add(ver7);
        versper3.Add(ver8);
        versper3.Add(ver9);
        versper3.Add(ver10);


        Versiones ver11 = new Versiones("ver1per4", "numero 1");
        Versiones ver12 = new Versiones("ver2per4", "numero 2");
        versper4.Add(ver11);
        versper4.Add(ver12);

        Versiones ver13 = new Versiones("ver1per5", "numero 1");
        versper5.Add(ver13);



        Personajes personaje1 = new Personajes("FP1", "cuadrados", "C:\\Users\\Stefy\\Documents\\pruebasunity\\rec_reference.png", versper1);
        Personajes personaje2 = new Personajes("FP2", "Numero 2", "D:\\Unity\\ColorPencil_v2\\Assets\\Assets\\imagenes\\Numero\\2.png", versper2);
        Personajes personaje3 = new Personajes("FP3", "Numero 3", "D:\\Unity\\ColorPencil_v2\\Assets\\Assets\\imagenes\\Numero\\3.png", versper3);
        Personajes personaje4 = new Personajes("FP4", "Numero 4", "D:\\Unity\\ColorPencil_v2\\Assets\\Assets\\imagenes\\Numero\\4.png", versper4);
        Personajes personaje5 = new Personajes("FP5", "Numero 5", "D:\\Unity\\ColorPencil_v2\\Assets\\Assets\\imagenes\\Numero\\5.png", versper5);

        figuras.Add(personaje1);
        figuras.Add(personaje2);
        figuras.Add(personaje3);
        figuras.Add(personaje4);
        figuras.Add(personaje5);


        BaseDato.personajes = figuras;
    }


}
