using UnityEngine;
using System.Collections;
using System;
using Tacticsoft;
using UnityEngine.UI;

public class LobbyCell : TableViewCell {

	void Awake(){
		transform.GetComponent<Button>().onClick.AddListener(didSelectRowTableView);
	}

    public Text m_quantidadeDeSalasLabel;
    public Text m_quantidadesDeJogadoresLabel;
	public Text m_quantidadeDeVisitantesLabel;
	public int id;
	public string realName;
	private string worker;

	public void SetLobbyCell(int idSala ,string sala ,int quantidadeVisitantes, int quantidadeJogadores, string realName, string worker) {
		id = idSala;
		m_quantidadeDeSalasLabel.text = sala;
		m_quantidadeDeVisitantesLabel.text = quantidadeVisitantes.ToString();
		m_quantidadesDeJogadoresLabel.text = quantidadeJogadores.ToString() + "/8";
		this.realName = realName;
		this.worker = worker;
	}
		
	private int m_numTimesBecameVisible;
    public void NotifyBecameVisible() {
        m_numTimesBecameVisible++;
		m_quantidadesDeJogadoresLabel.text = "# rows this cell showed : " + m_numTimesBecameVisible.ToString();
    }

	public void didSelectRowTableView() {
		PlayerPrefs.SetString("room", realName);
		PlayerPrefs.SetString ("worker", worker);
		//COLOCAR NO CANTO CERTO
		LobbyTableViewController lobbyController = LobbyTableViewController.GetInstance();
		//lobbyController.Progress();
		lobbyController.Alerta();

	}
}

