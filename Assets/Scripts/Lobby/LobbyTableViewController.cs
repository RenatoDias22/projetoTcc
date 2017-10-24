using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tacticsoft;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Sala {

	public int id;
	public string nomeSala;
	public string worker;

	public int visitantes;
	public int jogadores;

	public LobbyCell lobbyCell;
	public string nomeDeVerdade;

	public Sala(int idSala, string sala, int visitante, int jogador, string nomeDeVerdade, string worker) {
		nomeSala = sala;
		visitantes = visitante;
		jogadores = jogador;
		id = idSala;
		this.nomeDeVerdade = nomeDeVerdade;
		this.worker = worker;
	}

	public void updateLobbyCell(int quantidadeVisitantes, int quantidadeJogadores){
		visitantes = quantidadeVisitantes;
		jogadores = quantidadeJogadores;
		//Debug.Log ("lobbyCell " + lobbyCell + " da sala " + nomeSala);
		//		lobbyCell.SetLobbyCell (quantidadeVisitantes, quantidadeJogadores);
	}

	public void setLobbCell(LobbyCell cell){
		lobbyCell = cell;
	}

}

public class LobbyTableViewController : MonoBehaviour, ITableViewDataSource {

	public static LobbyTableViewController instance;

	public static LobbyTableViewController GetInstance(){
		return instance;
	}


	public LobbyCell m_cellPrefab;
	public TableView m_tableView;
	public int m_numRows;
	private int m_numInstancesCreated = 0;

	public Image originalTrademark;
	public Image secondaryTrademark;

	public Text singOut;
	public Text salas;
	public Text visitantes;
	public Text jogadores;
	public Text salvarUsuario;

	public Text namePlayer;
	public Text credits;

	//Variaveis do Alert
	public Text player;
	public Text spectator;
	public Text labelAlert;
	public Text creditoFinal;
	public Text creditoInicial;
	public Text totalReceber;
	public Text totalLucro;
	public Text totalBar;
	public Text porcentagemLucro;
	public Text porcentagemBar;

	public List<Sala> salasArray = new List<Sala>();
	public List<Sala> salasSearch = new List<Sala>();
	public Dictionary<int, Sala> dictionarySalas = new Dictionary<int, Sala>();
	public bool isSearch = false;
	public bool orderSala = false;
	public bool orderJogador = false;
	public bool orderVisitantes = false;
	private bool isSorted = false;

	public Image progress;
	public Text roomName;
	private GameObject panel;
	private GameObject panelAlert;
	private GameObject panelGanhos;
	private GameObject panelAlertGanhos;

	private string labelRooms;
	private string labelSpectators;
	private string labelPlayers;

//	void Awake(){
//		instance = this;
//
//		Localizator.Localize (singOut.GetComponent<Text>());
//		Localizator.Localize (salas.GetComponent<Text>());
//		Localizator.Localize (visitantes.GetComponent<Text>());
//		Localizator.Localize (jogadores.GetComponent<Text>());
//		Localizator.Localize (salvarUsuario.GetComponent<Text>());
//		Localizator.Localize (player.GetComponent<Text>());
//		Localizator.Localize (spectator.GetComponent<Text>());
//		Localizator.Localize (labelAlert.GetComponent<Text>());
//
//		if (HTTPManager.IsBetsVersion ()) {
//			originalTrademark.gameObject.SetActive (true);
//			secondaryTrademark.gameObject.SetActive (false);
//		} else {
//			originalTrademark.gameObject.SetActive (false);
//			secondaryTrademark.gameObject.SetActive (true);
//		}
//	}

	void Start() {
		m_tableView.dataSource = this;

		panel = transform.parent.Find("PanelLoading").gameObject;
		panelAlert = panel.transform.GetChild(0).Find("PanelAlert").gameObject;
		panelGanhos = transform.parent.Find ("PanelGanhos").gameObject;
		panelAlertGanhos = panelGanhos.transform.GetChild(0).Find("PanelAlertGanhos").gameObject;

		roomName = panelAlert.transform.GetChild (0).GetComponentInChildren<Text> ();
		labelRooms = salas.GetComponent<Text>().text;
		labelSpectators = visitantes.GetComponent<Text>().text;
		labelPlayers = jogadores.GetComponent<Text>().text;
		StartUpdatingRooms ();
	}

	public void Alerta(){
		panel.SetActive (true);
		panelAlert.SetActive (true);
		roomName.text = PlayerPrefs.GetString("room");
	}

	public void Alert_Click(GameObject sender) {
		if (sender.name == "ButtonJogador") {
			PlayerPrefs.SetInt("spectator", 0);
		}
		if (sender.name == "ButtonEspectador") {
			PlayerPrefs.SetInt("spectator", 1);
		}

		if (sender.name == "ExitButton") {
			panel.SetActive (false);
			panelAlert.SetActive (false);
		} else {
//			Progress ();
		}
	}

//	public void Progress() {
//		panelAlert.transform.parent.gameObject.SetActive (false);
//		//panelAlert.SetActive (false);
//		progress.gameObject.SetActive(true);
//		iTween.RotateBy(progress.gameObject, iTween.Hash("z", -5, "time", 5, "looptype", "loop", "easetype", "linear"));
//		Invoke ("MoveToNextScene", 5);
//	}

	public void MoveToNextScene(){
		SceneManager.LoadScene ("Mobile");
		//Application.LoadLevel("Mobile");
	}

	public void StartUpdatingRooms(){
		InvokeRepeating("UpdateRooms", 1.0f, 5.0f);
		//UpdateRooms();
	}

	public void UpdateRooms() {
//		StartCoroutine(HTTPManager.RequestRooms ((error, roomsJson) => {
//			if(error != null){
//				print(error.ToString());
//				return;
//			}
//
//			if (salasArray.Count() > roomsJson.Childs.Count()){
//				salasArray.Clear();
//				dictionarySalas.Clear();
//
//			}
//			//bool didCreateRoom = false;
//			if(salasArray.Count > roomsJson.Childs.Count()){
//				salasArray.Clear();
//				dictionarySalas.Clear();
//			}
//			foreach(JSONNode roomJson in roomsJson.Childs){
//				Sala sala = null;
//				//Criando id a partir do nome da sala: roomJson["name"].ToString().GetHashCode()
//				int id = roomJson["id"].AsInt;
//				//print(id);
//				dictionarySalas.TryGetValue(id, out sala);
//				if(sala != null){
//					UpdateRoomWithJson(sala, roomJson);
//				}else{
//					CreateRoomFromJson(roomJson, id);
//					//didCreateRoom = true;
//				}
//			}
//			if(isSorted){
//				m_tableView.ReloadData();
//			}else{
//				//Ordena pelos nomes, já dá um ReloadData()
//				Salas_Click(salas.gameObject);
//			}
//		}));
	}

//	public void UpdateRoomWithJson(Sala sala, JSONNode roomJson){
//		//print ("Atualizando room " + sala.nomeSala + " com espectador: " + roomJson ["numberOfSpectators"].AsInt + " e jogadores " + roomJson ["numberOfPlayers"].AsInt);
//		sala.updateLobbyCell (roomJson ["numberOfSpectators"].AsInt, roomJson ["numberOfPlayers"].AsInt);
//	}
//
//	public void CreateRoomFromJson(JSONNode roomJson, int id){
//		Sala sala = new Sala (id, roomJson ["name"], roomJson ["numberOfSpectators"].AsInt, roomJson ["numberOfPlayers"].AsInt, roomJson["realName"], roomJson["worker"]);
//		salasArray.Add (sala);
//		dictionarySalas[id] = sala;
//		isSorted = false;
//	}

	public void Salas_Click(GameObject sender) {
		isSorted = true;
		if (sender.name == "Salas") {
			if (orderSala == false) {
				salasArray = salasArray.OrderBy(x => PadNumbers(x.nomeSala)).ToList();
				salasSearch = salasSearch.OrderBy(x => PadNumbers(x.nomeSala)).ToList();
			} else {
				salasArray = salasArray.OrderBy(x => PadNumbers(x.nomeSala)).Reverse().ToList();
				salasSearch = salasSearch.OrderBy(x => PadNumbers(x.nomeSala)).Reverse().ToList();
			}
			salas.text = labelRooms + ( (orderSala) ? "\t▲" : "\t▼");
			visitantes.text = labelSpectators;
			jogadores.text = labelPlayers;
			orderSala = !orderSala;
			orderJogador = false;
			orderVisitantes = false;
		} 
		if (sender.name == "Jogadores") {
			if (orderJogador == false) {
				salasArray.Sort ((x, y) => x.jogadores.CompareTo (y.jogadores));
				salasSearch.Sort ((x, y) => x.jogadores.CompareTo (y.jogadores));
			} else {
				salasArray.Sort ((x, y) => y.jogadores.CompareTo (x.jogadores));
				salasSearch.Sort ((x, y) => y.jogadores.CompareTo (x.jogadores));
			}
			jogadores.text = labelPlayers + ( (orderJogador) ? "\t▲" : "\t▼");
			visitantes.text = labelSpectators;
			salas.text = labelRooms;
			orderJogador = !orderJogador;
			orderSala = false;
			orderVisitantes = false;
		}
		if (sender.name == "Visitantes") {
			if (orderVisitantes == false) {
				salasArray.Sort ((x, y) => x.visitantes.CompareTo (y.visitantes));
				salasSearch.Sort ((x, y) => x.visitantes.CompareTo (y.visitantes));
			} else {
				salasArray.Sort ((x, y) => y.visitantes.CompareTo (x.visitantes));
				salasSearch.Sort ((x, y) => y.visitantes.CompareTo (x.visitantes));
			}
			visitantes.text = labelSpectators + ( (orderVisitantes) ? "\t▲" : "\t▼");
			salas.text = labelRooms;
			jogadores.text = labelPlayers;
			orderVisitantes = !orderVisitantes;
			orderSala = false;
			orderJogador = false;
		}

		m_tableView.ReloadData();
	}

	public static string PadNumbers(string input)
	{
		return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
	}

	public void ButtonSairClick(GameObject sender) {

//		string underManager = PlayerPrefs.GetString ("underManager");
//		if ( underManager == "true") {
//			panelAlertGanhos.SetActive (true);
//			panelGanhos.SetActive (true);
//			//chamar load.
//			//request dos ganhos
//			string token = PlayerPrefs.GetString ("token");
//			StartCoroutine(HTTPManager.RequestCloseUnderManager (token, (error, response) => {
//				if(error != null){
//					print(error.ToString());
//				}else{
//					float inicialCredits = float.Parse(response["initialCredits"]);
//					float finalCredits = float.Parse(response["finalCredits"]);
//					float managerPays = float.Parse(response["managerPays"]);
//					float userEarnings = float.Parse( response["userEarnings"]);
//					float managerEarnings = float.Parse(response["managerEarnings"]);
//
//					if(finalCredits > inicialCredits){
//						this.porcentagemLucro.text = "97%";
//						this.porcentagemBar.text = "03%";
//					}else{
//						this.porcentagemLucro.text = "0%";
//						this.porcentagemBar.text = "0%";
//					}
//
//					this.creditoInicial.text = LobbyLogin.GetInstance().formatString(inicialCredits);
//					this.creditoFinal.text = LobbyLogin.GetInstance().formatString(finalCredits);
//					this.totalReceber.text = LobbyLogin.GetInstance().formatString(managerPays);
//					this.totalLucro.text = LobbyLogin.GetInstance().formatString(userEarnings);
//					this.totalBar.text = LobbyLogin.GetInstance().formatString(managerEarnings);
//
//				}
//			}));
//		} else {
//			ResetUser();
//		}

	}
	public void ButtonGanhosOk(GameObject sender) {
		ResetUser ();
		//PlayerPrefs.SetString ("login", "");
		panelAlertGanhos.SetActive(false);
		panelGanhos.SetActive (false);

	}

	private void ResetUser() {
		LobbyLogin lobbyLogin = LobbyLogin.GetInstance();
		lobbyLogin.ClearLogin();
		PlayerPrefs.SetString ("token", "");
		PlayerPrefs.SetString ("UserLogado", "");
		PlayerPrefs.SetString ("credits", "");

		PlayerPrefs.DeleteKey("creditsIniciais");
	}

	#region ITableViewDataSource

	//Will be called by the TableView to know how many rows are in this table
	public int GetNumberOfRowsForTableView(TableView tableView) {
		if (!isSearch) {
			//print (salasArray.Count);
			return salasArray.Count;
		}
		else
			return salasSearch.Count;
	}

	public float GetHeightForRowInTableView(TableView tableView, int row) {
		return (m_cellPrefab.transform as RectTransform).rect.height;
	}

	public TableViewCell GetCellForRowInTableView(TableView tableView, int row) {
		LobbyCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as LobbyCell;
		//print ("linha " + row);
		if (cell == null) {
			cell = (LobbyCell)GameObject.Instantiate(m_cellPrefab);
			cell.name = "VisibleCounterCellInstance_" + (++m_numInstancesCreated).ToString();
		}
		//			salasArray[row].setLobbCell(cell);
		//			print ("entrou aqui");
		//print (salasArray [row].nomeSala);
		Sala sala;
		int id = salasArray[row].id;
		dictionarySalas.TryGetValue(id, out sala);
		if(sala != null){
			dictionarySalas [id] = salasArray[row];
		}
		//
		if (!isSearch) 
			cell.SetLobbyCell(row,salasArray[row].nomeSala, salasArray[row].visitantes, salasArray[row].jogadores, salasArray[row].nomeDeVerdade, salasArray[row].worker);
		else 
			cell.SetLobbyCell(row,salasSearch[row].nomeSala, salasSearch[row].visitantes, salasSearch[row].jogadores, salasArray[row].nomeDeVerdade, salasArray[row].worker);

		return cell;
	}

	#endregion

	#region Table View event handlers

	//Will be called by the TableView when a cell's visibility changed
	public void TableViewCellVisibilityChanged(int row, bool isVisible) {
		//Debug.Log(string.Format("Row {0} visibility changed to {1}", row, isVisible));
		if (isVisible) {
			LobbyCell cell = (LobbyCell)m_tableView.GetCellAtRow(row);
			cell.NotifyBecameVisible();
		}
	}

	#endregion

}
//}
