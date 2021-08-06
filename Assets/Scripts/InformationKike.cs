using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationKike 
{
    private List<Versiones> versiones;
    private string m_Path;

    public InformationKike()
    {
        this.versiones = new List<Versiones>();
        this.m_Path = Application.dataPath;
        versiones.Add(kike1());
        versiones.Add(kike2());
        versiones.Add(kike3());
        //versiones.Add(kike4());
        //versiones.Add(kike5());
    }

    public List<Versiones> GetVersiones()
    {
        return this.versiones;
    }

    public Versiones kike1()
    {
        List<Partes> parte = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte1.png";
        Partes part1 = new Partes("K1P1", "kike1parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte2.png";
        Partes part2 = new Partes("K1P2", "kike1parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte3.png";
        Partes part3 = new Partes("K1P3", "kike1parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte4.png";
        Partes part4 = new Partes("K1P4", "kike1parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte5.png";
        Partes part5 = new Partes("K1P5", "kike1parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte6.png";
        Partes part6 = new Partes("K1P6", "kike1parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte7.png";
        Partes part7 = new Partes("K1P7", "kike1parte7", "#fffff", p7);
        string p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte8.png";
        Partes part8 = new Partes("K1P8", "kike1parte8", "#fffff", p8);
        string p9 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike1_parte9.png";
        Partes part9 = new Partes("K1P9", "kike1parte9", "#fffff", p9);

        parte.Add(part1);
        parte.Add(part2);
        parte.Add(part3);
        parte.Add(part4);
        parte.Add(part5);
        parte.Add(part6);
        parte.Add(part7);
        parte.Add(part8);
        parte.Add(part9);

        Versiones modelo = new Versiones("K1", "KIKE1", parte);
        return modelo;
    }

    public Versiones kike2()
    {
        List<Partes> parte = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte1.png";
        Partes part1 = new Partes("K2P1", "kike2parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte2.png";
        Partes part2 = new Partes("K2P2", "kike2parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte3.png";
        Partes part3 = new Partes("K2P3", "kike2parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte4.png";
        Partes part4 = new Partes("K2P4", "kike2parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte5.png";
        Partes part5 = new Partes("K2P5", "kike2parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte6.png";
        Partes part6 = new Partes("K2P6", "kike2parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike2_parte7.png";
        Partes part7 = new Partes("K2P7", "kike2parte7", "#fffff", p7);

        parte.Add(part1);
        parte.Add(part2);
        parte.Add(part3);
        parte.Add(part4);
        parte.Add(part5);
        parte.Add(part6);
        parte.Add(part7);

        Versiones modelo = new Versiones("K2", "KIKE2", parte);
        return modelo;
    }

    public Versiones kike3()
    {
        List<Partes> parte = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte1.png";
        Partes part1 = new Partes("K3P1", "kike3parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte2.png";
        Partes part2 = new Partes("K3P2", "kike3parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte3.png";
        Partes part3 = new Partes("K3P3", "kike3parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte4.png";
        Partes part4 = new Partes("K3P4", "kike3parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte5.png";
        Partes part5 = new Partes("K3P5", "kike3parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte6.png";
        Partes part6 = new Partes("K3P6", "kike3parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Kike/kike3_parte7.png";
        Partes part7 = new Partes("K3P7", "kike3parte7", "#fffff", p7);

        parte.Add(part1);
        parte.Add(part2);
        parte.Add(part3);
        parte.Add(part4);
        parte.Add(part5);
        parte.Add(part6);
        parte.Add(part7);

        Versiones modelo = new Versiones("K3", "KIKE3", parte);
        return modelo;
    }


}
