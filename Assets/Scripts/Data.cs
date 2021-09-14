using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se supone que este archivo es el almacenara datos adicionales
public class Data
{
    public string user;
    public List<Personajes> data;         // lista de personajes (0-9)

    public Data()
    {
    }



    //getters and setters
}


public class Personajes
{
    public int character_id;
    public string character_name;
    //public string url_ref;
    public List<Versiones> graphic_lines; 

    public Personajes()
    {
    }

    public Personajes(int id, string nombre, string url_ref)
    {
        this.character_id = id;
        this.character_name = nombre;
        //this.url_ref = url_ref;
        this.graphic_lines = new List<Versiones>();
    }
}

public class Versiones
{
    public int graphic_line_id;
    public string graphic_line_name;
    public string graphic_line_image;
    public List<Partes> graphic_line_parts;
    public List<Emociones> emociones;
    public List<Accesorios> accesorios;

    public Versiones()
    {
    }

    public Versiones(int idV, string name, string image)
    {
        this.graphic_line_id = idV;
        this.graphic_line_name = name;
        this.graphic_line_image = image;
        this.graphic_line_parts = new List<Partes>();
        this.accesorios = new List<Accesorios>();
        this.emociones = new List<Emociones>();
    }
}

public class Partes
{
    public int part_id;
    public string part_name;
    public string part_svg;
    public Color color;

    public Partes()
    {
    }

    public Partes(int idP, string name, string imagen, Color color)
    {
        this.part_id = idP;
        this.part_name = name;
        this.part_svg = imagen;
        this.color = color;
    }
}

public class Emociones
{
    public int emot_id;
    public string emot_svg;

    public Emociones()
    {
    }

    public Emociones(int idE, string imagen)
    {
        this.emot_id = idE;
        this.emot_svg = imagen;
    }



    //getters and setters
}

public class Accesorios
{
    public int acc_id;
    public string acc_svg;

    public Accesorios()
    {
    }

    public Accesorios(int idA, string imagen)
    {
        this.acc_id = idA;
        this.acc_svg = imagen;
    }



    //getters and setters
}

