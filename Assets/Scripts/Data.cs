using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se supone que este archivo es el almacenara datos adicionales
public class Data : MonoBehaviour
{
    public List<Personajes> personajes;         // lista de personajes (0-9)
    public int indexPersonaje;                  // debe de ser hasta 9 - para indicarle cual activar en el menu de personajes
    public int indexVersion;

    //getters and setters
}


public class Personajes : MonoBehaviour
{
    private string ID;
    private string nombre;
    private string URL_ref;
    private List<Versiones> versiones;

    //getters and setters
}

public class Versiones : MonoBehaviour
{
    private string idV;
    private string VerName;
    private List<Partes> partes;
    private List<Emociones> emociones;
    private List<Accesorios> accesorios;

    //getters and setters

}

public class Partes : MonoBehaviour
{
    private string idP;
    private string namePart;
    private string color;
    private string url;

    //getters and setters
}

public class Emociones : MonoBehaviour
{
    private string idE;
    private string nameEmo;
    private string color;
    private string url;

    //getters and setters
}

public class Accesorios : MonoBehaviour
{
    private string idA;
    private string nameAcc;
    private string color;
    private string url;

    //getters and setters
}

