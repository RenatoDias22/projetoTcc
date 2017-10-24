using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using System;
using UnityEngine;



public struct JogoAprendiazgem {
	public string resposta;
	public string pergunta;
	public string pergunta1;
	public string pergunta2;
	public string pergunta3;
	public string pergunta4;

	public JogoAprendiazgem(string pergunta, string resposta, string pergunta1, string pergunta2, string pergunta3, string pergunta4) {
		this.pergunta = pergunta;
		this.resposta = resposta;
		this.pergunta1 = pergunta1;
		this.pergunta2 = pergunta2;
		this.pergunta3 = pergunta3;
		this.pergunta4 = pergunta4;

	}

//	public string getResposta1(){
//		return this.pergunta1;
//	}
}

public class TelaAprendizagem : MonoBehaviour {

	public Text pergunta;
	public Button resposta1;
	public Button resposta2;
	public Button resposta3;
	public Button resposta4;


	public List<JogoAprendiazgem> jogos = new List<JogoAprendiazgem> ();

	// Use this for initialization
	void Start () {
		jogos.Add (new JogoAprendiazgem ("2+3=", "5", "1", "3", "5", "2"));
		jogos.Add (new JogoAprendiazgem("2-3=", "-1", "-1", "2", "0", "1"));
		jogos.Add (new JogoAprendiazgem("(2-3)+2=", "1", "-1", "2", "0", "1"));
		jogos.Add (new JogoAprendiazgem("10-5=", "5", "-1", "5", "2", "4"));
		jogos.Add (new JogoAprendiazgem ("6-3=", "3", "5", "2", "3", "4"));
		jogos.Add (new JogoAprendiazgem ("1-9=", "-8", "10", "-8", "-10", "0"));
		jogos.Add (new JogoAprendiazgem ("-40+50=", "10", "-10", "10", "0", "1"));
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		InvokeRepeating("UpdatePerguntas", 1.0f, 5.0f);
	}

	public void Resposta_Selecionada_Click(GameObject sender) {
		if (sender.name == "ButtonResposta1") {
			
		}

		if (sender.name == "ButtonResposta2") {
			
		}

		if (sender.name == "ButtonResposta3") {
			
		}

		if (sender.name == "ButtonResposta4") {
			
		}
	}


	public void UpdatePerguntas(){

		JogoAprendiazgem j = jogos [Random.Range(0, jogos.Count-1)];
		pergunta.text = j.pergunta;
		resposta1.GetComponentInChildren<Text>().text = j.pergunta1;
		resposta2.GetComponentInChildren<Text>().text = j.pergunta2;
		resposta3.GetComponentInChildren<Text>().text = j.pergunta3;
		resposta4.GetComponentInChildren<Text>().text = j.pergunta4;
	}
		
}
