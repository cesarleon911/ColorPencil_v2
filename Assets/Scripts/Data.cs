using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se supone que este archivo es el almacenara datos adicionales
public class Data
{
    public string user;
    public List<Personajes> personajes;         // lista de personajes (0-9)

    public Data()
    {
    }



    //getters and setters
}


public class Personajes
{
    public int id;
    public string nombre;
    public string url_ref;
    public List<Versiones> versiones; 

    public Personajes()
    {
    }

    public Personajes(int id, string nombre, string url_ref)
    {
        this.id = id;
        this.nombre = nombre;
        this.url_ref = url_ref;
        this.versiones = new List<Versiones>();
    }
}

public class Versiones
{
    public int idV;
    public int personaid;
    public int numVersion;
    public List<Partes> partes;
    public List<Emociones> emociones;
    public List<Accesorios> accesorios;

    public Versiones()
    {
    }

    public Versiones(int idV, int personaid, int numVersion)
    {
        this.idV = idV;
        this.personaid = personaid;
        this.numVersion = numVersion;
        this.partes = new List<Partes>();
        this.accesorios = new List<Accesorios>();
        this.emociones = new List<Emociones>();
    }
}

public class Partes
{
    public int idP;
    public int numParte;
    public string nombre;
    public string imagen;
    public int numVersion;
    public int personaid;
    public Color color;

    public Partes()
    {
    }

    public Partes(int idP, int numParte, string nombre, string imagen, int numVersion, int personaid, Color color)
    {
        this.idP = idP;
        this.numParte = numParte;
        this.nombre = nombre;
        this.imagen = imagen;
        this.numVersion = numVersion;
        this.personaid = personaid;
        this.color = color;
    }
}

public class Emociones
{
    public int idE;
    public int numEmo;
    public string nombre;
    public string imagen;
    public int numVersion;
    public int personaid;
    public string color;

    public Emociones()
    {
    }

    public Emociones(int idE, int numEmo, string nombre, string imagen, int numVersion, int personaid, string color)
    {
        this.idE = idE;
        this.numEmo = numEmo;
        this.nombre = nombre;
        this.imagen = imagen;
        this.numVersion = numVersion;
        this.personaid = personaid;
        this.color = color;
    }



    //getters and setters
}

public class Accesorios
{
    public int idA;
    public int numAcc;
    public string nombre;
    public string imagen;
    public int numVersion;
    public int personaid;
    public string color;

    public Accesorios()
    {
    }

    public Accesorios(int idA, int numAcc, string nombre, string imagen, int numVersion, int personaid, string color)
    {
        this.idA = idA;
        this.numAcc = numAcc;
        this.nombre = nombre;
        this.imagen = imagen;
        this.numVersion = numVersion;
        this.personaid = personaid;
        this.color = color;
    }



    //getters and setters
}

