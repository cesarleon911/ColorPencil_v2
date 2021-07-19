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
        SceneManager.LoadScene("espol");
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

    public void btn_selected_character() {
        SceneManager.LoadScene("MenuVersionesPersonajes");
    }

    public void btn_selected_version() {
        SceneManager.LoadScene("MLienzoPersonajes");
    }

  
}
