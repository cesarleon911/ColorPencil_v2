using System.IO;
using UnityEngine.UI;
using UnityEngine;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class PersonajeCtrl : MonoBehaviour
{
    public GameObject btnAcceso;
    public GameObject btnCarita;
    public GameObject pincel;

    public GameObject colors;
    public GameObject accesorios;
    public GameObject emociones;

    private Personajes per;
    private Versiones ver;

    private Vector3 Postion;//mouse or touch postion
    private Vector3 PostionBrush;//mouse or touch postion

    // Start is called before the first frame update
    void Start()
    {
        per = DataJoin.instance.getBaseDato().personajes[DataJoin.instance.GetIndexPer() - 1];
        ver = per.versiones[DataJoin.instance.GetIndexVer() - 1];

        colors.SetActive(false);
        pincel.SetActive(false);
        accesorios.SetActive(false);
        emociones.SetActive(false);
        btnAcceso.SetActive(false);
        btnCarita.SetActive(false);

        cargar_graficos();
        
    }

    public void Update(){
        Postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get click position
        PostionBrush = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get click position
        Postion.z = -5;
        PostionBrush.z = -5;
        PostionBrush[0] += 0.5f;
        PostionBrush[1] -= 0.5f;

        if (Input.GetMouseButtonDown(0))
        {
            RayCast2D();
        }

        if (pincel != null)
            pincel.transform.position = PostionBrush;//drag the brush
    }

    public void btn_brush() {
        emociones.SetActive(false);
        accesorios.SetActive(false);
        colors.SetActive(true);
        pincel.SetActive(true);
    }

    public void btn_accesorios() {
        colors.SetActive(false);
        emociones.SetActive(false);
        pincel.SetActive(false);
        accesorios.SetActive(true);

        cargar_accesorios();
    }

    public void btn_emociones()
    {
        colors.SetActive(false);
        emociones.SetActive(true);
        pincel.SetActive(false);
        accesorios.SetActive(false);

        cargar_emociones();
    }


    private void cargar_graficos()
    {

        int partes = ver.partes.Count;
        int emociones = ver.emociones.Count;
        int accesorios = ver.accesorios.Count;

        if (partes > 0)
        {
            colors.SetActive(true);
            pincel.SetActive(true);
            cargar_partes();
        }

        if (emociones > 0 && emociones < 5) {
            btnCarita.SetActive(true);
        }

        if (accesorios > 0 && accesorios < 5)
        {
            btnAcceso.SetActive(true);
        }
        

    }

    public void cargar_partes() {

        GameObject nombre = GameObject.Find("personaje");
        nombre.GetComponent<Text>().text = per.nombre;


        GameObject LienzoPrincipal = GameObject.Find("fondolienzo");

        foreach (Partes parte in ver.partes)
        {

            var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

            var sceneInfo = SVGParser.ImportSVG(new StringReader(parte.imagen));
            var shape = sceneInfo.NodeIDs[parte.nombre].Shapes[0];
            shape.Fill = new SolidFill() { Color = parte.color };
            var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



            //aqui debo crear los lienzos añadidos 
            GameObject obj = new GameObject();
            obj.name = parte.nombre;
            obj.tag = "ImagePart";

            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
            sr.sortingOrder = 3;
            sr.flipY = false;

            //aqui se agrega los poligonos
            int indicePath = parte.imagen.IndexOf("<path", 0);
            if(indicePath!=-1){
                AddPolygonCollider2D(obj, parte.imagen);
            }else{
                AddCircleCollider2D(obj, parte.imagen);
            }

            obj.transform.parent = LienzoPrincipal.transform;
            obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            obj.transform.localPosition = new Vector3(-2, 2.7f, 0);

        }

        if (ver.emociones.Count > 0)
        {
            cargarcara("fondolienzo", ver.emociones[0]);
        }
    }

    public void cargarcara(string btn, Emociones carita)
    {

        GameObject LienzoPrincipal = GameObject.Find(btn);

        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        var sceneInfo = SVGParser.ImportSVG(new StringReader(carita.imagen));
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



        //aqui debo crear los lienzos añadidos 
        GameObject obj = new GameObject();
        obj.name = carita.nombre;
        obj.tag = "carita";

        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
        sr.sortingOrder = 3;
        sr.flipY = false;


        //aqui me falla la wea
        obj.transform.parent = LienzoPrincipal.transform;

        obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        obj.transform.localPosition = new Vector3(-2, 2.7f, 0);
    }

    public void cargar_accesorios() {

        int i = 1;
        foreach (Accesorios acc in ver.accesorios)
        {
            string btn = "btnacc" + i.ToString();
            GameObject obj = GameObject.Find(btn);


            var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

            var sceneInfo = SVGParser.ImportSVG(new StringReader(acc.imagen));
            var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);


            //aqui debo crear los lienzos añadidos 
            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = VectorUtils.BuildSprite(geoms, 1.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
            sr.sortingOrder = 3;

            obj.transform.localPosition = new Vector3(-1, 2.5f, 0);
            //obj.transform.pivot = new Vector3(-1, 2.5f, 0);
            i++;
        }

    }

    public void cargar_emociones(){
        int i = 1;
        foreach (Emociones emo in ver.emociones)
        {
            string btn = "btnemo" + i.ToString();
            GameObject obj = GameObject.Find(btn);


            var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

            var sceneInfo = SVGParser.ImportSVG(new StringReader(emo.imagen));
            var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);


            //aqui debo crear los lienzos añadidos 
            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
            sr.sortingOrder = 3;

            obj.transform.localPosition = new Vector3(-5, 2.5f, 0);
            //obj.transform.pivot = new Vector3(-5, 2.5f, 0);
            i++;
        }


    }

    
    //go es el gameobject que representa la parte
    //svg es el string de svg
    
    public static void AddPolygonCollider2D(GameObject go, string svg)
    {
        go.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polygon = go.GetComponent<PolygonCollider2D>();
        List<Vector2> points = stringBetween(svg, " d=\"", "\"");
        //stringBetween(svg, "<path d=\"", "\"");
        //svg, "d=\"", "z\""
        //seteo todos los puntos que stringBetween me devuelve
        polygon.SetPath(0, points);
        polygon.offset = new Vector2(points[0][0], points[0][1]);
    }

    public static void AddCircleCollider2D(GameObject go, string svg)
    {
        go.AddComponent<CircleCollider2D>();
        CircleCollider2D circulo = go.GetComponent<CircleCollider2D>();
        var points = stringBetweenCirc(svg, "cx=\"", "cy=\"","r=\"");
        //seteo todos los puntos que stringBetween me devuelve
        circulo.radius = points[2];
        circulo.offset = new Vector2(points[0], points[1]);
    }



    //source es el string de svg
    //Start es el string desde donde quiero recortar en este caso es path
    //End es el string hasta donde voy a recortar en este caso es z"
    public static List<Vector2> stringBetween(string Source, string Start, string End)
    {
        Debug.Log("svg");
        Debug.Log(Source);
        string result1 = "";
        string result2 = "";
        int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
        result1 = Source.Substring(StartIndex);
        int EndIndex = result1.IndexOf(End, 0);
        result2 = result1.Substring(0, EndIndex);
        result2 = result2.Replace("-.", "-0.");
        result2 = result2.Replace("-", " -");
        var lista = result2.Split(new char[] { ' ', ',', 'm', 'l', 'c', 'z', 'Z', 'M', 'L', 'C', 'a', 'A', 'q', 'Q', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        List<Vector2> puntos = new List<Vector2>(lista.Length / 2);
        float valorXactual = 0.000000f;
        float valorYactual = 0.000000f;
        for (var i = 0; i < lista.Length; i = i + 2)
        {
            valorXactual = valorXactual + (float.Parse(lista[i], CultureInfo.InvariantCulture)) / 20.000000f;
            valorYactual = valorYactual + (-1.000000f * ((float.Parse(lista[i + 1], CultureInfo.InvariantCulture)) / 20.000000f));
            //Debug.Log(valorYactual);
            if (valorXactual != 0.0f && valorYactual != 0.0f)
            {
                puntos.Add(new Vector2(valorXactual, valorYactual));
            }
        }
        return puntos;
    }

    public static List<float> stringBetweenCirc(string Source, string cx, string cy, string r)
    {
        List<float> puntos = new List<float>(); 
        //obtengo la coordenada x
        string result1 = "";
        string result2 = "";
        int StartIndexCX = Source.IndexOf(cx, 0) + cx.Length;
        result1 = Source.Substring(StartIndexCX);
        int EndIndexCX = result1.IndexOf( "\"", 0);
        result2 = result1.Substring(0, EndIndexCX);
        float coox = (float.Parse(result2, CultureInfo.InvariantCulture))/20.000000f;
        puntos.Add(coox);
        
        //obtengo la coordenada y
        string result3 = "";
        string result4 = "";
        int StartIndexCY = Source.IndexOf(cy, 0) + cy.Length;
        result3 = Source.Substring(StartIndexCY);
        int EndIndexCY = result3.IndexOf( "\"", 0);
        result4 = result3.Substring(0, EndIndexCY);
        float cooy = (float.Parse(result4, CultureInfo.InvariantCulture))/20.000000f;
        puntos.Add(cooy);

        //obtengo el radio
        string result5 = "";
        string result6 = "";
        int StartIndexR = Source.IndexOf(cx, 0) + cx.Length;
        result5 = Source.Substring(StartIndexR);
        int EndIndexR = result5.IndexOf( "\"", 0);
        result6 = result5.Substring(0, EndIndexR);
        float radio = (float.Parse(result6, CultureInfo.InvariantCulture))/20.000000f;
        puntos.Add(radio);

        return puntos;
    }

    //2d screen raycast
    private void RayCast2D()
    {
        RaycastHit2D rayCastHit2D = Physics2D.Raycast(Postion, Vector2.zero);

        if (rayCastHit2D.collider == null)
        {
            return;
        }
        if (rayCastHit2D.collider.tag == "BrushColor")
        {
            //set brush color
            Debug.Log("pintas");
            Debug.Log(rayCastHit2D.collider.GetComponent<currentColor>().value);
            pincel.GetComponent<currentColor>().value = rayCastHit2D.collider.GetComponent<currentColor>().value;
            //pincel.transform.GetChild(0).GetComponent<SpriteRenderer>().color = brush.currentColor;
        }
        else if (rayCastHit2D.collider.tag == "ImagePart")
        {
                Debug.Log("pintas");
                Debug.Log(rayCastHit2D.collider.GetComponent<SpriteRenderer>().name);  
                Color color =pincel.GetComponent<currentColor>().value;
                //StartCoroutine(crearParte(false, rayCastHit2D.collider.GetComponent<SpriteRenderer>().name));  
                var nombre = rayCastHit2D.collider.GetComponent<SpriteRenderer>().name;
                
                var index = int.Parse(nombre.Replace("svg_",""));
                var parte= ver.partes[index-1];
                //aqui debo crear los lienzos añadidos 
                GameObject obj = GameObject.Find(nombre);
                cargarNParte(parte.imagen,obj,parte.nombre,color);         
        }
    }


    public void cargarNParte(string svgString, GameObject parte, string id, Color colorA){
        GameObject LienzoPrincipal = GameObject.Find("fondolienzo");
        GameObject obj = new GameObject();
        obj.name = parte.name;
        obj.tag = "ImagePart";
        var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

        var sceneInfo = SVGParser.ImportSVG(new StringReader(svgString));

                // Import the SVG at runtime
        var shape = sceneInfo.NodeIDs[id].Shapes[0];
        shape.Fill = new SolidFill() { Color = colorA };
        var index = int.Parse(parte.name.Replace("svg_",""));
        ver.partes[index-1].color = colorA;
        
        //pintas
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

        int indicePath = svgString.IndexOf("<path", 0);

        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
        sr.sortingOrder = 3;
        sr.flipY = false;

        Destroy(parte);

        //aqui se agrega los poligonos
        if(indicePath!=-1){
            AddPolygonCollider2D(obj, svgString);
            Debug.Log("debio de ponerse el collider");
        }else{
            AddCircleCollider2D(obj, svgString);
            Debug.Log("debio de ponerse el collider");
        }

        obj.transform.parent = LienzoPrincipal.transform;
        obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        obj.transform.localPosition = new Vector3(-2, 2.7f, 0);

    }
}
