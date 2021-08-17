using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenectrl : MonoBehaviour
{
    
    public void btn_back_creditos() {
        SceneManager.LoadScene("carga");
    }

    public void btn_cerrar_carga() {
        SceneManager.LoadSceneAsync("espol");
        Application.Quit();
    }

    public void btn_info_carga() {
        SceneManager.LoadScene("creditos");
    }

    public void btn_play() {
        SceneManager.LoadScene("MenuPersonajes");
    }

    public void btn_back_versiones() {
        SceneManager.LoadScene("MenuPersonajes");
    }

    public void btn_back_pintado() {
        SceneManager.LoadScene("MenuVersionesPersonajes");
    }

    public void btn_selected_character(int op) {
        DataJoin.instance.SetIndexPer(op);
        SceneManager.LoadScene("MenuVersionesPersonajes");
    }

    public void btn_selected_version(int op) {
        DataJoin.instance.SetIndexVer(op);
        SceneManager.LoadScene("MLienzoPersonajes");
    }

  
}
