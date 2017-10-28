using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public struct JogoMemoria {
	public Button btn1;
	public Button btn2;
	public Button btn3;
	public string nameButton1;
	public string nameButton2;
	public string nameButton3;
	public int resposta;

	public JogoMemoria(Button btn1, Button btn2, Button btn3, int resposta, string nome1, string nome2, string nome3) {
		this.btn1 = btn1;
		this.btn2 = btn2;
		this.btn3 = btn3;
		this.resposta = resposta;
		this.nameButton1 = nome1;
		this.nameButton2 = nome2;
		this.nameButton3 = nome3;
	}

	public void setResposta(int r){
		this.resposta = r;
	} 
}

public class TelaMemoria : MonoBehaviour {

	public int pontosAcerto = 0;
	public int pontosErros= 0;
	public int resposta = 1;

	public List<JogoMemoria> jogos = new List<JogoMemoria> ();
	JogoMemoria jogo = new JogoMemoria();

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
		jogos.Add (new JogoMemoria (this.Button5, this.Button12, this.Button10, 1, "Button5","Button12","Button10"));
		jogos.Add (new JogoMemoria (this.Button2, this.Button10, this.Button7, 1, "Button2","Button10","Button7"));
		jogos.Add (new JogoMemoria (this.Button1, this.Button15, this.Button8, 1, "Button1","Button15","Button8"));
		jogos.Add (new JogoMemoria (this.Button4, this.Button2, this.Button9, 1, "Button4","Button2","Button9"));
		jogos.Add (new JogoMemoria (this.Button10, this.Button6, this.Button2, 1, "Button10","Button6","Button2"));
		jogos.Add (new JogoMemoria (this.Button3, this.Button11, this.Button13, 1, "Button3","Button11","Button13"));
		jogos.Add (new JogoMemoria (this.Button8, this.Button9, this.Button1, 1, "Button8","Button9","Button1"));
		jogos.Add (new JogoMemoria (this.Button15, this.Button12, this.Button5, 1, "Button15","Button12","Button5"));
		jogos.Add (new JogoMemoria (this.Button2, this.Button9, this.Button4, 1, "Button2","Button9","Button4"));
		jogos.Add (new JogoMemoria (this.Button7, this.Button9, this.Button3, 1, "Button7","Button9","Button3"));
		Invoke("FinalPartida", 29.0f);
		UpdatePerguntas();
		this.pontosAcerto = 0;
		this.pontosErros= 0;
		setNewButtons ();
		InvokeRepeating ("CountDown", 0f, 1.0f);
		InvokeRepeating ("setButton", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Resposta_Selecionada_Click(GameObject sender) {
		if (sender.name == this.jogo.nameButton1) {
			if (this.jogo.resposta == 1) {
				JogoMemoria temp = this.jogo;
				temp.setResposta(2);
				temp.btn1.enabled = false;
				temp.btn1.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
				this.jogo = temp;
//				
			} else {
				this.resposta = 1;
				JogoMemoria temp = this.jogo;
				temp.setResposta(1);
				this.jogo = temp;
				resetGame ();
				this.pontosErros++;
			}
		} else {
			if (sender.name == this.jogo.nameButton2) {
				if (this.jogo.resposta == 2) {
					JogoMemoria temp = this.jogo;
					temp.setResposta(3);
					temp.btn2.enabled = false;
					temp.btn2.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
					this.jogo = temp;
				} else {
					this.resposta = 1;
					this.jogo.setResposta(1);
					resetGame ();
					this.pontosErros++;
										
				}

			} else {
				if (sender.name == this.jogo.nameButton3) {
					if (this.jogo.resposta == 3) {
						JogoMemoria temp = this.jogo;
						temp.setResposta(1);
						temp.btn3.enabled = false;
						temp.btn3.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
						this.jogo = temp;
						resetGame();
						this.pontosAcerto++;
					} else {
						this.resposta = 1;
						JogoMemoria temp = this.jogo;
						temp.setResposta(1);
						this.jogo = temp;
						resetGame();
						this.pontosErros++;
					}

				}
			}
		
		}
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
//		but.enabled = true;
		but.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
		but.GetComponentInChildren<Image>().color = Color.blue;
	}

	public void setButton(){
		if (cont < 3) {
			if (cont == 0) {
				setButtonVisible (this.jogo.btn1);
				cont++;
			} else {
				if (cont == 1) {
					setButtonVisible (this.jogo.btn2);
					cont++;
				} else {
					if (cont == 2) {
						setButtonVisible (this.jogo.btn3);
						this.jogo.btn1.enabled = true;
						this.jogo.btn2.enabled = true;
						this.jogo.btn3.enabled = true;
						cont++;
					}
				}
			}
		}
	}

	public void resetGame(){
		this.cont = 0;
		setNewButtons();
		UpdatePerguntas ();
	}

	public void UpdatePerguntas(){
		JogoMemoria j = jogos [Random.Range(0, jogos.Count-1)];
		this.jogo = j;
	}
}
