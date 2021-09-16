using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.IO;

public class EraseCtrl : MonoBehaviour
{
    private GameObject mensaje;
 
    // Start is called before the first frame update
    void Start()
    {
        mensaje = GameObject.Find("Mensaje");
        mensaje.SetActive(false);
    }

    public void btn_erase() {
        mensaje.SetActive(true);
    }

    public void btn_acccept()
    {
        List<Personajes> listapersonajes = DataJoin.instance.getBaseDato().data;

        foreach (Personajes per in listapersonajes) {
            foreach (Versiones ver in per.graphic_lines) {
                foreach (Partes p in ver.graphic_line_parts) {
                    Colorimetria colores = new Colorimetria();
                    p.color = colores.getStringfromColor(new Color(1, 1, 1, 1));
                }
            }
        }

        guardar_data_persistente();
        SceneManager.LoadScene("MenuPersonajes");
    }

    public void guardar_data_persistente()
    {
        string path = Application.persistentDataPath + "/guardado.json";
        string jsonStringSave = JsonConvert.SerializeObject(DataJoin.instance.getBaseDato().data);
        File.WriteAllText(path, jsonStringSave);
    }

    public void btn_cancel()
    {
        mensaje.SetActive(false);
    }

}
