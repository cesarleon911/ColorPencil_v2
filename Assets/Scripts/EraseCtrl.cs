using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        print("se supone que se debe de borrar los colores asignados");
        mensaje.SetActive(false);
    }

    public void btn_cancel()
    {
        mensaje.SetActive(false);
    }

}
