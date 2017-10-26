using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TelaMemoria : MonoBehaviour {

	public int pontosAcerto = 0;
	public int pontosErros= 0;
	public int resposta = 1;

	public Text pontuacaoAcerto;
	public Text pontuacaoErro;
	public GameObject panelGame;
	public GameObject panelPontuacao;
	public Button Button1;
	public Button Button2;
	public Button Button3;
	public Button Button4;
	public Button Button5;
	public Button Button6;
	public Button Button7;
	public Button Button8;
	public Button Button9;
	public Button Button10;
	public Button Button11;
	public Button Button12;
	public Button Button13;
	public Button Button14;
	public Button Button15;

	public Text time;
	public int timerSeconds = 29;

	// Use this for initialization
	void Start () {
		
		Invoke("FinalPartida", 29.0f);
		this.pontosAcerto = 0;
		this.pontosErros= 0;
		InvokeRepeating ("CountDown", 0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Resposta_Selecionada_Click(GameObject sender) {
		if (sender.name == "Button1") {
			if (resposta == 1) {
				resposta++;
			} else {
				if (respota == 2) {
					resposta++;
				} else {
					if (resposta == 3) {
						resposta++;
						this.pontosAcerto++;
					} else {
						resposta == 1;
						this.pontosErros++;
					}
				}
			}
		}
//
//		if (sender.name == "ButtonColor2") {
//			if (resposta == btnColor2.GetComponentInChildren<Text> ().text) {
//				this.pontosAcerto++;
//			} else {
//				this.pontosErros++;
//			}
//		}
//		UpdatePerguntas ();
	}

	public void Pontuacao_Button_Selecionar_Click(GameObject sender) {
		if (sender.name == "ButtonRepetir") {
			this.panelPontuacao.SetActive(false);
			this.panelGame.SetActive (true);
			Start ();
		}

		if (sender.name == "ButtonVoltar") {
			FinalGame ();
		}
	}

	public void FinalGame(){
		SceneManager.LoadScene ("TelaPrincipal", LoadSceneMode.Single);
	}

	public void FinalPartida(){
		this.pontuacaoAcerto.text = pontosAcerto.ToString();
		this.pontuacaoErro.text = pontosErros.ToString();
		this.panelPontuacao.SetActive(true);
		this.panelGame.SetActive (false);
	}

	void CountDown() {

		this.time.text =timerSeconds.ToString();
		timerSeconds--;
		if(timerSeconds < 1) {
			CancelInvoke("CountDown");
		}
	}

}
