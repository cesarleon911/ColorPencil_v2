using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class DataJoin : MonoBehaviour
{
    public static DataJoin instance;
    private Data BaseDato;
    private int indexPers;
    private int indexVer;

    private string url = "http://207.246.65.177/api/graphic_lines/?format=json";
    private string post_result = "";
    private int user;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start(){
        this.BaseDato = new Data();
        StartCoroutine(tiempo_de_carga(3));
    }

    public int Npersonajes()
    {
        return BaseDato.data.Count;
    }

    public Data getBaseDato()
    {
        return BaseDato;
    }

    public void SetIndexPer(int index)
    {
        indexPers = index;
    }

    public void SetIndexVer(int index)
    {
        indexVer = index;
    }

    public int GetIndexPer()
    {
        return indexPers;
    }

    public string GetPostResult()
    {
        return post_result;
    }

    public int Nversiones(int index)
    {
        Personajes pers = BaseDato.data[index - 1];
        return pers.graphic_lines.Count;
    }


    public int GetIndexVer()
    {
        return indexVer;
    }

    public int GetUser()
    {
        return user;
    }


    IEnumerator tiempo_de_carga(int seg) {
      

        var uwr = new UnityWebRequest(url, "GET");
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Application.Quit();
            Debug.Log(uwr.error);
        }
        else {
            this.BaseDato = JsonConvert.DeserializeObject<Data>(uwr.downloadHandler.text);

        }

        yield return new WaitForSeconds(seg);

        //cargado de datos de los personajes
        StartCoroutine(NewUser(response =>
        {
            post_result = response;
            JObject usuarioB = JObject.Parse(post_result);
            this.user = (int)usuarioB["id_user"];
            SceneManager.LoadScene("carga");
        }));
    
       
    }

    IEnumerator NewUser(System.Action<string> callback){
        string deviceId = SystemInfo.deviceUniqueIdentifier;

        User u = new User(deviceId);
        string data_send = JsonConvert.SerializeObject(u);

        var uwr = new UnityWebRequest("http://207.246.65.177/api/users/", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data_send);

        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError){
            Debug.Log("Error While Sending: " + uwr.error);
        }

        callback?.Invoke(uwr.downloadHandler.text);
    }


}

public class User
{
    public string device;

    public User(string device)
    {
        this.device = device;
    }
}
