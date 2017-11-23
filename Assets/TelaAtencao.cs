using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public struct JogoAtencao {
	public string nomeCor1;
	public string nomeCor2;
	public Color color1;
	public Color Color2;
	public string resposta;

	public JogoAtencao(string nomeCor1, string nomeCor2, Color color1,  Color color2, string resposta) {
		this.nomeCor1 = nomeCor1;
		this.nomeCor2 = nomeCor2;
		this.color1 = color1;
		this.Color2 = color2;
		this.resposta = resposta;
	}
}

public class TelaAtencao : MonoBehaviour {

	public string resposta;
	public int pontosAcerto = 0;
	public int pontosErros= 0;
	public Button btnColor1;
	public Button btnColor2;

	public Text pontuacaoAcerto;
	public Text pontuacaoErro;
	public Text pontuacaoTotal;
	public GameObject panelGame;
	public GameObject panelPontuacao;

	public Text time;
	public int timerSeconds = 29;

	public List<JogoAtencao> jogos = new List<JogoAtencao> ();

	// Use this for initialization
	void Start () {

		Invoke("FinalPartida", 29.0f);
		this.timerSeconds = 29;
		this.pontosAcerto = 0;
		this.pontosErros= 0;
		jogos.Add (new JogoAtencao ("Amarelo", "Azul", Color.yellow, Color.green, "Azul"));
		jogos.Add (new JogoAtencao("Vermelho", "Amarelo",Color.blue, Color.yellow, "Vermelho"));
		jogos.Add (new JogoAtencao("Branco", "Preto",Color.blue, Color.black, "Branco"));
		jogos.Add (new JogoAtencao("Verde", "Azul", Color.white, Color.blue, "Verde"));
		jogos.Add (new JogoAtencao ("Azul", "Branco", Color.blue, Color.yellow, "Branco"));
		jogos.Add (new JogoAtencao ("Preto", "Azul", Color.yellow, Color.blue, "Preto"));
		jogos.Add (new JogoAtencao ("Branco", "Verde", Color.white, Color.green, "Verde"));
		jogos.Add (new JogoAtencao ("Preto", "Cinza", Color.black, Color.green, "Cinza"));
		jogos.Add (new JogoAtencao ("Cinza", "Vermelho", Color.gray, Color.white, "Vermelho"));
		jogos.Add (new JogoAtencao ("Verde", "Vermelho", Color.green, Color.blue, "Vermelho"));
		jogos.Add (new JogoAtencao ("Cinza", "Verde", Color.yellow, Color.green, "Cinza"));

		this.time.text = "" + timerSeconds;
		UpdatePerguntas();
		InvokeRepeating ("CountDown", 0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

	}

	//	public void StartGame(){
	//		InvokeRepeating("UpdatePerguntas", 5.0f, 5.0f);
	//	}

	public void Resposta_Selecionada_Click(GameObject sender) {
		if (sender.name == "ButtonColor1") {
			if (resposta == btnColor1.GetComponentInChildren<Text> ().text) {
				this.pontosAcerto++;
			} else {
				this.pontosErros++;
			}

		}

		if (sender.name == "ButtonColor2") {
			if (resposta == btnColor2.GetComponentInChildren<Text> ().text) {
				this.pontosAcerto++;
			} else {
				this.pontosErros++;
			}
		}
		UpdatePerguntas ();
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


	public void UpdatePerguntas(){

		JogoAtencao j = jogos [Random.Range(0, jogos.Count-1)];
		this.resposta = j.resposta;
		btnColor1.GetComponentInChildren<Image>().color = j.color1;
		btnColor2.GetComponentInChildren<Image>().color = j.Color2;
		btnColor1.GetComponentInChildren<Text>().text = j.nomeCor1;
		btnColor2.GetComponentInChildren<Text>().text = j.nomeCor2;
	}

	public void FinalGame(){
		SceneManager.LoadScene ("TelaPrincipal", LoadSceneMode.Single);
	}

	public void FinalPartida(){

		int pontosAcertosTotal = pontosAcerto * 100;
		int pontosErrosTotal = pontosErros * (-50);
		int total = pontosAcertosTotal + pontosErrosTotal;

		PlayerPrefs.SetString ("ArrayAtencaoAcertos", PlayerPrefs.GetString("ArrayAtencaoAcertos") + " " + pontosAcerto.ToString());
		this.pontuacaoAcerto.text = pontosAcerto.ToString();
		
		PlayerPrefs.SetString ("ArrayAtencaoErros", PlayerPrefs.GetString("ArrayAtencaoErros") + " " + pontosErros.ToString());
		this.pontuacaoErro.text = pontosErros.ToString();

		PlayerPrefs.SetString ("ArrayAtencaoPontosTotal", PlayerPrefs.GetString("ArrayAtencaoPontosTotal") + " " + total.ToString());
		this.pontuacaoTotal.text = total.ToString();

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
