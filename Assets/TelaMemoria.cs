using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TelaMemoria : MonoBehaviour {

	public int pontosAcerto = 0;
	public int pontosErros= 0;
	public Text pontuacaoAcerto;
	public Text pontuacaoErro;
	public GameObject panelGame;
	public GameObject panelPontuacao;

	public Text time;
	public int timerSeconds = 29;

	// Use this for initialization
	void Start () {

		this.pontosAcerto = 0;
		this.pontosErros= 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pontuacao_Button_Selecionar_Click(GameObject sender) {
		if (sender.name == "ButtonRepetir") {
			this.panelPontuacao.SetActive(false);
			this.panelGame.SetActive (true);
			Start ();
		}

		if (sender.name == "ButtonVoltar") {
//			FinalGame ();
		}
	}
}
