using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;	
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TelaPrincipal : MonoBehaviour {

	public Button memoria;
	public Button aprendizagem;
	public Button atencao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jogo_Selecionado_Click(GameObject sender) {
		if (sender.name == "ButtonMemoria") {
			SceneManager.LoadScene ("Memoria", LoadSceneMode.Single);
		}

		if (sender.name == "ButtonAprendizagem") {
			SceneManager.LoadScene ("Aprendizagem", LoadSceneMode.Single);
		}

		if (sender.name == "ButtonAtencao") {
			SceneManager.LoadScene ("Atencao", LoadSceneMode.Single);
		}
	}
}
