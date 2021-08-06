using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationGaby
{
    private List<Versiones> versiones;
    private string m_Path;

    public InformationGaby()
    {
        this.versiones = new List<Versiones>();
        this.m_Path = Application.dataPath;
        versiones.Add(gaby1());
        versiones.Add(gaby2());
        versiones.Add(gaby3());
        versiones.Add(gaby4());
        //versiones.Add(gaby5());
    }

    public List<Versiones> GetVersiones() {
        return this.versiones;
    }


    public Versiones gaby1() {
        //version 1 de gaby
        List<Partes> parte1 = new List<Partes>();

        string g1p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte1.png";
        Partes part1 = new Partes("G1P1", "gaby1parte1", "#fffff", g1p1);
        string g1p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte2.png";
        Partes part2 = new Partes("G1P2", "gaby1parte2", "#fffff", g1p2);
        string g1p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte3.png";
        Partes part3 = new Partes("G1P3", "gaby1parte3", "#fffff", g1p3);
        string g1p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte4.png";
        Partes part4 = new Partes("G1P4", "gaby1parte4", "#fffff", g1p4);
        string g1p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte5.png";
        Partes part5 = new Partes("G1P5", "gaby1parte5", "#fffff", g1p5);
        string g1p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte6.png";
        Partes part6 = new Partes("G1P6", "gaby1parte6", "#fffff", g1p6);
        string g1p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte7.png";
        Partes part7 = new Partes("G1P7", "gaby1parte7", "#fffff", g1p7);
        string g1p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte8.png";
        Partes part8 = new Partes("G1P8", "gaby1parte8", "#fffff", g1p8);
        string g1p9 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte9.png";
        Partes part9 = new Partes("G1P9", "gaby1parte9", "#fffff", g1p9);
        string g1p10 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte10.png";
        Partes part10 = new Partes("G1P10", "gaby1parte10", "#fffff", g1p10);
        string g1p11 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte11.png";
        Partes part11 = new Partes("G1P11", "gaby1parte11", "#fffff", g1p11);
        string g1p12 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte12.png";
        Partes part12 = new Partes("G1P12", "gaby1parte12", "#fffff", g1p12);

        parte1.Add(part1);
        parte1.Add(part2);
        parte1.Add(part3);
        parte1.Add(part4);
        parte1.Add(part5);
        parte1.Add(part6);
        parte1.Add(part7);
        parte1.Add(part8);
        parte1.Add(part9);
        parte1.Add(part10);
        parte1.Add(part11);
        parte1.Add(part12);

        Versiones gabymodelo1 = new Versiones("G1", "GABY1", parte1);
        return gabymodelo1;
    }

    public Versiones gaby2()
    {
        List<Partes> parte1 = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte1.png";
        Partes part1 = new Partes("G2P1", "gaby2parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte2.png";
        Partes part2 = new Partes("G2P2", "gaby2parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte3.png";
        Partes part3 = new Partes("G2P3", "gaby2parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte4.png";
        Partes part4 = new Partes("G2P4", "gaby2parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte5.png";
        Partes part5 = new Partes("G2P5", "gaby2parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte6.png";
        Partes part6 = new Partes("G2P6", "gaby2parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte7.png";
        Partes part7 = new Partes("G2P7", "gaby2parte7", "#fffff", p7);
        string p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby2_parte8.png";
        Partes part8 = new Partes("G2P8", "gaby2parte8", "#fffff", p8);
        string p9 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte9.png";
        Partes part9 = new Partes("G2P9", "gaby2parte9", "#fffff", p9);
        string p10 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte10.png";
        Partes part10 = new Partes("G2P10", "gaby2parte10", "#fffff", p10);
        string p11 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby1_parte11.png";
        Partes part11 = new Partes("G2P11", "gaby2parte11", "#fffff", p11);
      
        parte1.Add(part1);
        parte1.Add(part2);
        parte1.Add(part3);
        parte1.Add(part4);
        parte1.Add(part5);
        parte1.Add(part6);
        parte1.Add(part7);
        parte1.Add(part8);
        parte1.Add(part9);
        parte1.Add(part10);
        parte1.Add(part11);
    
        Versiones gabymodelo2 = new Versiones("G2", "GABY2", parte1);
        return gabymodelo2;

    }
    public Versiones gaby3()
    {
        List<Partes> parte1 = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte1.png";
        Partes part1 = new Partes("G3P1", "gaby3parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte2.png";
        Partes part2 = new Partes("G3P2", "gaby3parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte3.png";
        Partes part3 = new Partes("G3P3", "gaby3parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte4.png";
        Partes part4 = new Partes("G3P4", "gaby3parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte5.png";
        Partes part5 = new Partes("G3P5", "gaby3parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte6.png";
        Partes part6 = new Partes("G3P6", "gaby3parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte7.png";
        Partes part7 = new Partes("G3P7", "gaby3parte7", "#fffff", p7);
        string p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby3_parte8.png";
        Partes part8 = new Partes("G3P8", "gaby3parte8", "#fffff", p8);

        parte1.Add(part1);
        parte1.Add(part2);
        parte1.Add(part3);
        parte1.Add(part4);
        parte1.Add(part5);
        parte1.Add(part6);
        parte1.Add(part7);
        parte1.Add(part8);

        Versiones gabymodelo3 = new Versiones("G3", "GABY3", parte1);
        return gabymodelo3;


    }
    public Versiones gaby4()
    {
        List<Partes> parte1 = new List<Partes>();

        string p1 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte1.png";
        Partes part1 = new Partes("G4P1", "gaby4parte1", "#fffff", p1);
        string p2 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte2.png";
        Partes part2 = new Partes("G4P2", "gaby4parte2", "#fffff", p2);
        string p3 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte3.png";
        Partes part3 = new Partes("G4P3", "gaby4parte3", "#fffff", p3);
        string p4 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte4.png";
        Partes part4 = new Partes("G4P4", "gaby4parte4", "#fffff", p4);
        string p5 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte5.png";
        Partes part5 = new Partes("G4P5", "gaby4parte5", "#fffff", p5);
        string p6 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte6.png";
        Partes part6 = new Partes("G4P6", "gaby4parte6", "#fffff", p6);
        string p7 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte7.png";
        Partes part7 = new Partes("G4P7", "gaby4parte7", "#fffff", p7);
        string p8 = m_Path + "/Assets/imagenes/Personajes/versiones/Gaby/gaby4_parte8.png";
        Partes part8 = new Partes("G4P8", "gaby4parte8", "#fffff", p8);

        parte1.Add(part1);
        parte1.Add(part2);
        parte1.Add(part3);
        parte1.Add(part4);
        parte1.Add(part5);
        parte1.Add(part6);
        parte1.Add(part7);
        parte1.Add(part8);

        Versiones gabymodelo2 = new Versiones("G4", "GABY4", parte1);
        return gabymodelo2;


    }






}
