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
	public int cont = 0;

	// Use this for initialization
	void Start () {
		
		Invoke("FinalPartida", 29.0f);
		this.pontosAcerto = 0;
		this.pontosErros= 0;
		setNewButtons ();
		InvokeRepeating ("CountDown", 0f, 1.0f);
		InvokeRepeating ("setButton", 0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Resposta_Selecionada_Click(GameObject sender) {
		if (sender.name == "Button1") {
			if (resposta == 1) {
				resposta++;
			} else {
				if (resposta == 2) {
					resposta++;
				} else {
					if (resposta == 3) {
						resposta++;
						this.pontosAcerto++;
					} else {
						this.resposta = 1;
						this.cont = 0;
						this.pontosErros++;
					}
				}
			}
		}

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

	public void setNewButtons(){

		this.Button1.enabled = false;
		this.Button1.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button2.enabled = false;
		this.Button2.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button3.enabled = false;
		this.Button3.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button4.enabled = false;
		this.Button4.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button5.enabled = false;
		this.Button5.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button6.enabled = false;
		this.Button6.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button7.enabled = false;
		this.Button7.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button8.enabled = false;
		this.Button8.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button9.enabled = false;
		this.Button9.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button10.enabled = false;
		this.Button10.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button11.enabled = false;
		this.Button11.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button12.enabled = false;
		this.Button12.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button13.enabled = false;
		this.Button13.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button14.enabled = false;
		this.Button14.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		this.Button15.enabled = false;
		this.Button15.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);

	}

	public void setButtonVisible(Button but) {
		but.enabled = true;
		but.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
	}

	public void setButton(){
		if (cont < 3) {
			if(cont == 0){
				setButtonVisible (Button1);
				cont++;
			}
			if(cont == 1){
				setButtonVisible (Button2);
				cont++;
			}
			if(cont == 2){
				setButtonVisible (Button3);
				cont++;
			}
		}
	}
}
