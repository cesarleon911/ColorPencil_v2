using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se supone que este archivo es el almacenara datos adicionales
public class Data
{
    public string user;
    public List<Personajes> personajes;         // lista de personajes (0-9)

    //getters and setters
}


public class Personajes
{
    private string ID;
    private string nombre;
    private string URL_ref;
    private List<Versiones> versiones;

  
    public Personajes(string iD, string nombre, string uRL_ref, List<Versiones> versiones)
    {
        ID = iD;
        this.nombre = nombre;
        URL_ref = uRL_ref;
        this.versiones = versiones;
    }

    public Personajes(string iD, string nombre, string uRL_ref)
    {
        ID = iD;
        this.nombre = nombre;
        URL_ref = uRL_ref;
    }

    public string GetName() {
        return this.nombre;
    }

    public List<Versiones> Getversiones()
    {
        return versiones;
    }

    public Versiones Getversion(int index) {
        return versiones[index-1];
    }

    public int GetNVersiones() {
        return this.versiones.Count;
    }

    public string getURL() {
        return URL_ref;
    }
    //getters and setters

    public void SetVersiones(List<Versiones> versiones) {
        this.versiones = versiones;
    }

}

public class Versiones
{
    private string idV;
    private string VerName;
    private List<Partes> partes;
    private List<Emociones> emociones;
    private List<Accesorios> accesorios;

    public Versiones(string idV, string verName)
    {
        this.idV = idV;
        VerName = verName;
    }

    public Versiones(string idV, string verName, List<Partes> partes)
    {
        this.idV = idV;
        VerName = verName;
        this.partes = partes;
    }

    public int getNumPart()
    {
        return partes.Count;
    }

    public List<Partes> GetPartes() {
        return partes;
    }
    //getters and setters
    public string GetVerName() {
        return this.VerName;
    }

}

public class Partes
{
    private string idP;
    private string namePart;
    private string color;
    private string url;

    public Partes(string idP, string namePart, string color, string url)
    {
        this.idP = idP;
        this.namePart = namePart;
        this.color = color;
        this.url = url;
    }


    //getters and setters
    public string getPartName() {
        return namePart;
    }

    public string getURL() {
        return url;
    }
}

public class Emociones
{
    private string idE;
    private string nameEmo;
    private string color;
    private string url;

    //getters and setters
}

public class Accesorios
{
    private string idA;
    private string nameAcc;
    private string color;
    private string url;

    //getters and setters
}

