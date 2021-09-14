using System.IO;
using UnityEngine.UI;
using UnityEngine;
using Unity.VectorGraphics;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class PersonajeCtrl : MonoBehaviour
{
    public GameObject pincel;

    private Personajes per;
    private Versiones ver;

    private Vector3 Postion;//mouse or touch postion
    private Vector3 PostionBrush;//mouse or touch postion

    private int id_user;
    private int id_graphic_line;

    void Start()
    {
        per = DataJoin.instance.getBaseDato().data[DataJoin.instance.GetIndexPer() - 1];
        ver = per.graphic_lines[DataJoin.instance.GetIndexVer() - 1];
        id_user = DataJoin.instance.GetUser();
        id_graphic_line = ver.graphic_line_id;

        cargar_partes();
        writeNewData();

    }

    public void Update()
    {
        Postion = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get click position
        PostionBrush = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get click position
        Postion.z = -5;
        PostionBrush.z = -5;

        PostionBrush[0] += 1.0f;
        PostionBrush[1] -= 1.0f;

        if (Input.GetMouseButtonDown(0))
        {
            RayCast2D();
        }

        if (pincel != null)
            pincel.transform.position = PostionBrush;//drag the brush
    }

 
    public void cargar_partes()
    {

        GameObject nombre = GameObject.Find("personaje");
        nombre.GetComponent<Text>().text = per.character_name;

        GameObject LienzoPrincipal = GameObject.Find("fondolienzo");

        foreach (Partes parte in ver.graphic_line_parts)
        {

            var tessOptions = new VectorUtils.TessellationOptions()
            {
                StepDistance = 100.0f,
                MaxCordDeviation = 0.5f,
                MaxTanAngleDeviation = 0.1f,
                SamplingStepSize = 0.01f
            };

            var sceneInfo = SVGParser.ImportSVG(new StringReader(parte.part_svg));
            var shape = sceneInfo.NodeIDs[parte.part_name].Shapes[0];

            //var cambiarOrden = false;
            if ((SolidFill)sceneInfo.NodeIDs[parte.part_name].Shapes[0].Fill == null)
            {
                shape.Fill = new SolidFill() { Color = parte.color };
                //cambiarOrden = true;
            }
            var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);



            //aqui debo crear los lienzos añadidos 
            GameObject obj = new GameObject();
            int part_id = parte.part_id - 1;
            obj.name = parte.part_name;
            obj.tag = "ImagePart";

            obj.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            sr.sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.SVGOrigin, Vector2.zero, 128, true);
            sr.sortingOrder = 4;
            /*if (cambiarOrden)
            {
                sr.sortingOrder = 3;
            }*/
            sr.flipY = false;

            //aqui se agrega los poligonos
            int indicePath = parte.part_svg.IndexOf("<path", 0);
            if(indicePath!=-1){
                AddPolygonCollider2D(obj, parte.part_svg);
            }else{
                int indiceN = parte.part_svg.IndexOf("<circle", 0);
                if(indiceN!=-1){
                    AddCircleCollider2D(obj, parte.part_svg);
                }
                else{
                    int indiceN2 = parte.part_svg.IndexOf("<ellipse", 0);
                    if(indiceN2!=-1){
                       AddEllCollider2D(obj,parte.part_svg);      
                    }
                    else{
                        AddRectCollider2D(obj, parte.part_svg);
                    }
                }
            }

            obj.transform.parent = LienzoPrincipal.transform;
            obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            obj.transform.localPosition = new Vector3(-2, 2.7f, 0);

        }


    }


    //go es el gameobject que representa la parte
    //svg es el string de svg
    public void AddPolygonCollider2D(GameObject go, string svg)
    {
        go.AddComponent<PolygonCollider2D>();
        PolygonCollider2D polygon = go.GetComponent<PolygonCollider2D>();
        List<Vector2> points = stringBetween(svg, " d=\"", "\"");
        //seteo todos los puntos que stringBetween me devuelve
        polygon.SetPath(0, points);
        polygon.offset = new Vector2(points[0][0], points[0][1]);
    }

    public void AddCircleCollider2D(GameObject go, string svg)
    {
        go.AddComponent<CircleCollider2D>();
        CircleCollider2D circulo = go.GetComponent<CircleCollider2D>();
        var points = stringBetweenCirc(svg, "cx=\"", "cy=\"", "r=\"");
        //seteo todos los puntos que stringBetween me devuelve
        circulo.radius = points[2];
        circulo.offset = new Vector2(points[0], points[1]*-1);
    }

    public void AddRectCollider2D(GameObject go, string svg)
    {
        go.AddComponent<BoxCollider2D>();
        BoxCollider2D rect = go.GetComponent<BoxCollider2D>();
        var points = stringBetweenRec(svg, "width=\"", "height=\"");
        //seteo todos los puntos que stringBetween me devuelve
        rect.size = new Vector2(points[0], points[1]);
        //circulo.offset = new Vector2(points[0], points[1]);
    }


    public void AddEllCollider2D(GameObject go, string svg)
    {
        go.AddComponent<PolygonCollider2D>();
        PolygonCollider2D ell = go.GetComponent<PolygonCollider2D>();
        var points = stringBetweenEll(svg, "rx=\"", "ry=\"");
        //seteo todos los puntos que stringBetween me devuelve
        ell.SetPath(0, points);
        var off= offsetEll(svg, "cx=\"", "cy=\"");
        ell.offset = new Vector2(off[0],off[1]*-1);
    }

    public  Vector2 offsetEll(string Source, string cx, string cy){
        string result1 = "";
        string result2 = "";
        int StartIndexCX = Source.IndexOf(cx, 0) + cx.Length;
        result1 = Source.Substring(StartIndexCX);
        int EndIndexCX = result1.IndexOf( "\"", 0);
        result2 = result1.Substring(0, EndIndexCX);
        float offX = (float.Parse(result2, CultureInfo.InvariantCulture))/10.000000f;
        string result3 = "";
        string result4 = "";
        int StartIndexCY = Source.IndexOf(cy, 0) + cy.Length;
        result3 = Source.Substring(StartIndexCY);
        int EndIndexCY = result3.IndexOf( "\"", 0);
        result4 = result3.Substring(0, EndIndexCY);
        float offY = (float.Parse(result4, CultureInfo.InvariantCulture))/10.000000f;
        return new Vector2(offX,offY);
    }


    public List<Vector2> stringBetweenEll(string Source, string rx, string ry) {
        List<Vector2> points = new List<Vector2>();
        string result1 = "";
        string result2 = "";
        int StartIndexRX = Source.IndexOf(rx, 0) + rx.Length;
        result1 = Source.Substring(StartIndexRX);
        int EndIndexRX = result1.IndexOf( "\"", 0);
        result2 = result1.Substring(0, EndIndexRX);
        float radiusX = (float.Parse(result2, CultureInfo.InvariantCulture))/10.000000f;
        string result3 = "";
        string result4 = "";
        int StartIndexRY = Source.IndexOf(ry, 0) + ry.Length;
        result3 = Source.Substring(StartIndexRY);
        int EndIndexRY = result3.IndexOf( "\"", 0);
        result4 = result3.Substring(0, EndIndexRY);
        float radiusY = (float.Parse(result4, CultureInfo.InvariantCulture))/10.000000f;
        float angulo = 0;

        for (int i = 0; i <= 31; i++)
        {
            float a = angulo * Mathf.Deg2Rad;

            float x = radiusX * Mathf.Cos(a) * Mathf.Cos(0) - radiusY * Mathf.Sin(a) * Mathf.Sin(0);
            float y = -radiusX * Mathf.Cos(a) * Mathf.Sin(0) - radiusY * Mathf.Sin(a) * Mathf.Cos(0);
            points.Add(new Vector2(x, y));
            angulo += 360f/30;
        }

        return points;
    }

    public List<Vector2> puntosArco(Vector2 inicio,float rx, float ry, int rotation){
        float iniciox=inicio[0];
        float inicioy=inicio[1];
        List<Vector2> points = new List<Vector2>();
        float angulo = 0;
        float o = rotation * Mathf.Deg2Rad;

        for (int i = 0; i <= 31; i++){
            float a = angulo * Mathf.Deg2Rad;

            float x = iniciox + rx * Mathf.Cos(a) * Mathf.Cos(o) - ry * Mathf.Sin(a) * Mathf.Sin(o);
            float y = inicioy  -rx * Mathf.Cos(a) * Mathf.Sin(o) - ry * Mathf.Sin(a) * Mathf.Cos(o);

            points.Add(new Vector2(x, y));
            angulo += 360f/30;
        }

        return points;
    }



    //source es el string de svg
    //Start es el string desde donde quiero recortar en este caso es path
    //End es el string hasta donde voy a recortar en este caso es z"
    public List<Vector2> stringBetween(string Source, string Start, string End)
    {
        string result1 = "";
        string result2 = "";
        int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
        result1 = Source.Substring(StartIndex);
        int EndIndex = result1.IndexOf(End, 0);
        result2 = result1.Substring(0, EndIndex);
        result2 = result2.Replace("-.", "-0.");
        result2 = result2.Replace("-", " -");
        result2 = result2.Replace("v", " h ");
        result2 = result2.Replace("h", " v ");
        result2 = result2.Replace("q", " q ");
        result2 = result2.Replace("c", " c ");
        result2 = result2.Replace("s", " s ");
        result2 = result2.Replace("a", " a ");

        var lista = result2.Split(new char[] { ' ', ',','S','m', 'l', 'z', 'Z', 'M', 'L','C', 'A', 'Q', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        List<Vector2> puntos = new List<Vector2>(5);
        float iniciox = (float.Parse(lista[0], CultureInfo.InvariantCulture)) / 20.000000f;
        float inicioy= (-1.0f * ((float.Parse(lista[1], CultureInfo.InvariantCulture)) / 20.000000f));
        float valorXactual = 0.000000f;
        float valorYactual = 0.000000f;
        float valorxCurva= 0.000000f;
        float valorYcurva= 0.000000f;
        for (var i = 0; i < lista.Length; i = i + 2)
        {
            if(lista[i]!="v" && lista[i]!="h"){
                if(lista[i]=="c"){
                    float inicialX= valorXactual;
                    float inicialY= valorYactual;
                    valorXactual = valorXactual + (float.Parse(lista[i+1], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 2], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p1= new Vector2(valorXactual,valorYactual);
                    valorXactual = valorXactual + (float.Parse(lista[i+3], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 4], CultureInfo.InvariantCulture)) / 20.000000f));
                    valorxCurva= valorXactual;
                    valorYcurva= valorYactual;
                    Vector2 p2= new Vector2(valorXactual,valorYactual);
                    valorXactual = valorXactual + (float.Parse(lista[i+5], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 6], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p3= new Vector2(valorXactual,valorYactual);
                    List<Vector2> temp= puntosCubic(new Vector2(inicialX,inicialY),p1,p2,p3);
                    foreach(Vector2 punto in temp){
                        puntos.Add(punto);
                    }
                    i+=5;

                }else if(lista[i]=="q"){
                    float inicialX= valorXactual;
                    float inicialY= valorYactual;
                    valorXactual = valorXactual + (float.Parse(lista[i+1], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 2], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p1= new Vector2(valorXactual,valorYactual);
                    valorXactual = valorXactual + (float.Parse(lista[i+3], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 4], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p2= new Vector2(valorXactual,valorYactual);
                    List<Vector2> temp= puntosCuadra(new Vector2(inicialX,inicialY),p1,p2);
                    foreach(Vector2 punto in temp){
                        puntos.Add(punto);
                    }
                    i+=3;

                }else if(lista[i]=="s"){
                    float inicialX= valorXactual;
                    float inicialY= valorYactual;
                    valorXactual= inicialX + (valorXactual-valorxCurva);
                    valorYactual= inicialY + (valorYactual-valorYcurva);                    
                    Vector2 p1= new Vector2(valorXactual,valorYactual);
                    valorXactual = valorXactual + (float.Parse(lista[i+1], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 2], CultureInfo.InvariantCulture)) / 20.000000f));
                    valorxCurva= valorXactual;
                    valorYcurva= valorYactual;
                    Vector2 p2= new Vector2(valorXactual,valorYactual);
                    valorXactual = valorXactual + (float.Parse(lista[i+3], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 4], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p3= new Vector2(valorXactual,valorYactual);
                    List<Vector2> temp= puntosCubic(new Vector2(inicialX,inicialY),p1,p2,p3);
                    foreach(Vector2 punto in temp){
                        puntos.Add(punto);
                    }
                    i+=3;

                }else if(lista[i]=="a"){
                    float inicialX= valorXactual;
                    float inicialY= valorYactual;
                    float rx =(float.Parse(lista[i+1], CultureInfo.InvariantCulture)) / 20.000000f;
                    float ry = -1.0f * (float.Parse(lista[i+2], CultureInfo.InvariantCulture)) / 20.000000f;
                    int rotacion =  int.Parse(lista[i+3]);
                    valorXactual = valorXactual + (float.Parse(lista[i+6], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 7], CultureInfo.InvariantCulture)) / 20.000000f));
                    Vector2 p1= new Vector2(valorXactual,valorYactual);
                    List<Vector2> temp=puntosArco(new Vector2(inicialX,inicialY),rx,ry,rotacion);
                    foreach(Vector2 punto in temp){
                        puntos.Add(punto);
                    }
                    i+=6;
                }else{
                    valorXactual = valorXactual + (float.Parse(lista[i], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 1], CultureInfo.InvariantCulture)) / 20.000000f));
                    puntos.Add(new Vector2(valorXactual, valorYactual));
                }
            }
            else{
                if(lista[i]=="v"){
                    valorXactual = valorXactual + 0.0f;
                    valorYactual = valorYactual + (-1.0f * ((float.Parse(lista[i + 1], CultureInfo.InvariantCulture)) / 20.000000f));
                    puntos.Add(new Vector2(valorXactual, valorYactual));
                }
                if(lista[i]=="h"){
                    valorXactual = valorXactual + valorXactual + (float.Parse(lista[i+1], CultureInfo.InvariantCulture)) / 20.000000f;
                    valorYactual = valorYactual + 0.0f;
                    puntos.Add(new Vector2(valorXactual, valorYactual));
                }
            }
        }
        puntos.Add(new Vector2(iniciox,inicioy));
        puntos.Capacity= puntos.Count;
        return puntos;
    }


    public List<Vector2> puntosCuadra(Vector2 p0, Vector2 p1, Vector2 p2){
        int numP = 30;
        List<Vector2> puntos = new List<Vector2>(numP);
        for(int i= 1; i < numP +1;i++){
            float t= i/(float)numP;
            puntos.Add(puntoCuadr(t,p0,p1,p2));
        }

        return puntos;
    }

    public List<Vector2> puntosCubic(Vector2 p0, Vector2 p1, Vector2 p2,Vector2 p3){
        int numP = 30;
        List<Vector2> puntos = new List<Vector2>(numP);
        for(int i= 1; i < numP +1;i++){
            float t= i/(float)numP;
            puntos.Add(puntoCub(t,p0,p1,p2,p3));
        }

        return puntos;
    }


    public Vector2 puntoCuadr(float t, Vector2 p0, Vector2 p1, Vector2 p2){
        float u = 1 - t;
        float tt= t * t;
        float uu= u * u;
        Vector2 p= uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    public Vector2 puntoCub(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3){
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;
		
        Vector2 p = uuu * p0; 
        p += 3 * uu * t * p1; 
        p += 3 * u * tt * p2; 
        p += ttt * p3; 
		
        return p;
    }

    public  List<float> stringBetweenRec(string Source, string width, string heigth)
    {
        List<float> puntos = new List<float>();
        string result1 = "";
        string result2 = "";
        int StartIndexW = Source.IndexOf(width, 0) + width.Length;
        result1 = Source.Substring(StartIndexW);
        int EndIndexW = result1.IndexOf("\"", 0);
        result2 = result1.Substring(0, EndIndexW);
        float wid = (float.Parse(result2, CultureInfo.InvariantCulture)) / 10.000000f;
        puntos.Add(wid);


        string result3 = "";
        string result4 = "";
        int StartIndexH = Source.IndexOf(heigth, 0) + heigth.Length;
        result3 = Source.Substring(StartIndexH);
        int EndIndexH = result3.IndexOf("\"", 0);
        result4 = result3.Substring(0, EndIndexH);
        float heig = (float.Parse(result4, CultureInfo.InvariantCulture)) / 10.000000f;
        puntos.Add(heig);

        return puntos;
    }


    public List<float> stringBetweenCirc(string Source, string cx, string cy, string r)
    {
        List<float> puntos = new List<float>();
        //obtengo la coordenada x
        string result1 = "";
        string result2 = "";
        int StartIndexCX = Source.IndexOf(cx, 0) + cx.Length;
        result1 = Source.Substring(StartIndexCX);
        int EndIndexCX = result1.IndexOf("\"", 0);
        result2 = result1.Substring(0, EndIndexCX);
        float coox = (float.Parse(result2, CultureInfo.InvariantCulture)) / 10.000000f;
        puntos.Add(coox);

        //obtengo la coordenada y
        string result3 = "";
        string result4 = "";
        int StartIndexCY = Source.IndexOf(cy, 0) + cy.Length;
        result3 = Source.Substring(StartIndexCY);
        int EndIndexCY = result3.IndexOf("\"", 0);
        result4 = result3.Substring(0, EndIndexCY);
        float cooy = (float.Parse(result4, CultureInfo.InvariantCulture)) / 10.000000f;
        puntos.Add(cooy);

        //obtengo el radio
        string result5 = "";
        string result6 = "";
        int StartIndexR = Source.IndexOf(r, 0) + r.Length;
        result5 = Source.Substring(StartIndexR);
        int EndIndexR = result5.IndexOf("\"", 0);
        result6 = result5.Substring(0, EndIndexR);
        float radio = (float.Parse(result6, CultureInfo.InvariantCulture)) / 10.000000f;
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
            pincel.GetComponent<currentColor>().value = rayCastHit2D.collider.GetComponent<currentColor>().value;
            Color color = pincel.GetComponent<currentColor>().value;
            GameObject.Find("brush2").GetComponent<SpriteRenderer>().color = color;

        }
        else if (rayCastHit2D.collider.tag == "ImagePart")
        {  
            Color color = pincel.GetComponent<currentColor>().value; 
            var nombre = rayCastHit2D.collider.GetComponent<SpriteRenderer>().name;

            var index = int.Parse(nombre.Replace("el_", ""));
            var parte = ver.graphic_line_parts[index - 2];
            //aqui debo crear los lienzos añadidos 
            GameObject obj = GameObject.Find(nombre);
            cargarNParte(parte.part_svg, obj, parte.part_name, color);
        }
    }


    public void cargarNParte(string svgString, GameObject parte, string id, Color colorA)
    {
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

        if ((SolidFill)sceneInfo.NodeIDs[id].Shapes[0].Fill == null)
        {
            shape.Fill = new SolidFill() { Color = colorA };
            var index = int.Parse(parte.name.Replace("el_", ""));
            if (ver.graphic_line_name != "nieves_01")
            {
                ver.graphic_line_parts[index - 2].color = colorA;
            }
            else
            {
                ver.graphic_line_parts[index - 2].color = colorA;
            }
        }

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
        }else{
            int indiceN = svgString.IndexOf("<circle", 0);
            if(indiceN!=-1){
                AddCircleCollider2D(obj, svgString);
            }
            else{
                    int indiceN2 = svgString.IndexOf("<ellipse", 0);
                    if(indiceN2!=-1){
                       AddEllCollider2D(obj,svgString);      
                    }
                    else{
                        AddRectCollider2D(obj, svgString);
                    }
            }
        }
        obj.transform.parent = LienzoPrincipal.transform;
        obj.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        obj.transform.localPosition = new Vector3(-2, 2.7f, 0);

    }


    IEnumerator PostColoredGraphicLine(string data_send, System.Action<string> callback)
    {
        var uwr = new UnityWebRequest("http://207.246.65.177/api/colored_character/", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data_send);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }

        callback?.Invoke(uwr.downloadHandler.text);
    }


    public void writeNewData()
    {
        int id_expression = 1;

        List<Clothes> clothes = new List<Clothes>();
        List<Body> body = new List<Body>();

        Colored cl = new Colored(id_user, id_graphic_line, id_expression, clothes, body);
        string json_django = JsonConvert.SerializeObject(cl);

        StartCoroutine(PostColoredGraphicLine(json_django, response =>
        {
            Debug.Log(response);
        }));
    }

}



public class Body
{
    public int id_body_part;
    public string color_code;

    public Body(int id_body_part, string color_code)
    {
        this.id_body_part = id_body_part;
        this.color_code = color_code;
    }
}

public class Clothes
{
    public int id_clothes_type;
    public string color_code;

    public Clothes(int id_clothes_type, string color_code)
    {
        this.id_clothes_type = id_clothes_type;
        this.color_code = color_code;
    }
}


public class Colored
{
    public int id_user, id_graphic_line, id_expression;
    public List<Clothes> clothes = new List<Clothes>();
    public List<Body> body = new List<Body>();

    public Colored(int id_user, int id_graphic_line, int id_expression, List<Clothes> clothes, List<Body> body)
    {
        this.id_user = id_user;
        this.id_graphic_line = id_graphic_line;
        this.id_expression = id_expression;
        this.clothes = clothes;
        this.body = body;
    }
}
