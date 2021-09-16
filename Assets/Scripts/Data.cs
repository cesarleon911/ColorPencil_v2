using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//se supone que este archivo es el almacenara datos adicionales
public class Data
{
    public string user { get; set; }
    public List<Personajes> data { get; set; }         // lista de personajes (0-9)

    public Data()
    {
    }



    //getters and setters
}


public class Personajes
{
    public int character_id { get; set; }
    public string character_name { get; set; }
    //public string url_ref { get; set; }
    public List<Versiones> graphic_lines { get; set; }

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
    public int graphic_line_id { get; set; }
    public string graphic_line_name { get; set; }
    public string graphic_line_image { get; set; }
    public List<Partes> graphic_line_parts { get; set; }
    public List<Emociones> emociones { get; set; }
    public List<Accesorios> accesorios { get; set; }

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
    public int part_id { get; set; }
    public string part_name { get; set; }
    public string part_svg { get; set; }
    public string color { get; set; }

    public Partes()
    {
    }

    public Partes(int idP, string name, string imagen, string color)
    {
        this.part_id = idP;
        this.part_name = name;
        this.part_svg = imagen;
        this.color = color;
    }
}

public class Emociones
{
    public int emot_id { get; set; }
    public string emot_svg { get; set; }

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
    public int acc_id { get; set; }
    public string acc_svg { get; set; }

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

