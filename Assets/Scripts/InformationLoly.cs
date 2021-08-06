using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationLoly
{
    private List<Versiones> versiones;
    private string m_Path;

    public InformationLoly()
    {
        this.versiones = new List<Versiones>();
        this.m_Path = Application.dataPath;
        versiones.Add(loly1());
        //versiones.Add(loly2());
        //versiones.Add(loly3());
        //versiones.Add(loly4());
        //versiones.Add(loly5());
    }

    public List<Versiones> GetVersiones()
    {
        return this.versiones;
    }

    public Versiones loly1()
    {
        List<Partes> parte = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte1.png";
        Partes part1 = new Partes("L1P1", "loli1parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte2.png";
        Partes part2 = new Partes("L1P2", "loli1parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte3.png";
        Partes part3 = new Partes("L1P3", "loli1parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte4.png";
        Partes part4 = new Partes("L1P4", "loli1parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte5.png";
        Partes part5 = new Partes("L1P5", "loli1parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte6.png";
        Partes part6 = new Partes("L1P6", "loli1parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte7.png";
        Partes part7 = new Partes("L1P7", "loli1parte7", "#fffff", p7);
        string p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte8.png";
        Partes part8 = new Partes("L1P8", "loli1parte8", "#fffff", p8);
        string p9 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte9.png";
        Partes part9 = new Partes("L1P9", "loli1parte9", "#fffff", p9);
        string p10 = m_Path + "/Assets/imagenes/Personajes/versiones/Loly/loli1_parte10.png";
        Partes part10 = new Partes("L1P10", "loli1parte10", "#fffff", p10);

        parte.Add(part1);
        parte.Add(part2);
        parte.Add(part3);
        parte.Add(part4);
        parte.Add(part5);
        parte.Add(part6);
        parte.Add(part7);
        parte.Add(part8);
        parte.Add(part9);
        parte.Add(part10);

        Versiones modelo = new Versiones("L1", "LOLY1", parte);
        return modelo;
    }
}
