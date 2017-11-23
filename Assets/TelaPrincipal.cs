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
	

	// List<Memoria> arrayMemoria = new ArrayList<Memoria>();
	// List<Aprendizagem> arrayAprendizagem = new ArrayList<Aprendizagem>();
	// List<Atencao> arrayAtencao = new ArrayList<Atencao>();

	// Use this for initialization
	void Start () {

		if(PlayerPrefs.GetString("ArrayMemoriaAcertos") == null){
			PlayerPrefs.SetString ("ArrayMemoriaAcertos", "");
		}

		if(PlayerPrefs.GetString("ArrayMemoriaErros") == null){
			PlayerPrefs.SetString ("ArrayMemoriaErros", "");
		}

		if(PlayerPrefs.GetString("ArrayMemoriaPontosTotal") == null){
			PlayerPrefs.SetString ("ArrayMemoriaPontosTotal", "");
		}

		if(PlayerPrefs.GetString("ArrayAtencaoAcertos") == null){
			PlayerPrefs.SetString ("ArrayAtencaoAcertos", "");
		}

		if(PlayerPrefs.GetString("ArrayAtencaoErros") == null){
			PlayerPrefs.SetString ("ArrayAtencaoErros", "");
		}

		if(PlayerPrefs.GetString("ArrayAtencaoPontosTotal") == null){
			PlayerPrefs.SetString ("ArrayAtencaoPontosTotal", "");
		}

		if(PlayerPrefs.GetString("ArrayAprendizagemAcertos") == null){
			PlayerPrefs.SetString ("ArrayAprendizagemAcertos", "");
		}

		if(PlayerPrefs.GetString("ArrayAprendizagemErros") == null){
			PlayerPrefs.SetString ("ArrayAprendizagemErros", "");
		}

		if(PlayerPrefs.GetString("ArrayAprendizagemPontosTotal") == null){
			PlayerPrefs.SetString ("ArrayAprendizagemPontosTotal", "");
		}

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

		if (sender.name == "ButtonRanking") {
			SceneManager.LoadScene ("Ranking", LoadSceneMode.Single);
		}
	}
}
