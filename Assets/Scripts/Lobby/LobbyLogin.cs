using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

//using UnityEditor;

public struct UserLogado {
	public string usuario;
	public string senha;

	public UserLogado(string user, string sen) {
		usuario = user;
		senha = sen;

	}
}

public class LobbyLogin : MonoBehaviour {

	public static LobbyLogin instance;

	public static LobbyLogin GetInstance(){
		return instance;
	}

	public bool isCheck = false;
	public InputField login;
	public InputField password;
	public Image progress;
	public Button singIn;
	public Button registrer;
	public Text salveUser;
	private GameObject panel;
	public Text mensagemErro;
	public Toggle check;
	public Image originalTrademark;
	public Image secondaryTrademark;

	public GameObject panelAtualizar;
	public GameObject panelAlert;
	//public List<UserLogado> user = new List<UserLogado>();

//	void Awake(){
//
//		instance = this;
//
//		Localizator.Localize(login.placeholder.GetComponent<Text>());
//		Localizator.Localize(password.placeholder.GetComponent<Text>());
//		Localizator.Localize (singIn.GetComponentInChildren<Text>());
//		Localizator.Localize (registrer.GetComponentInChildren<Text>());
//		Localizator.Localize (salveUser.GetComponent<Text>());
//
//		if (HTTPManager.IsBetsVersion ()) {
//			originalTrademark.gameObject.SetActive (true);
//			secondaryTrademark.gameObject.SetActive (false);
//		} else {
//			originalTrademark.gameObject.SetActive (false);
//			secondaryTrademark.gameObject.SetActive (true);
//		}
//	}

	// Use this for initialization
	void Start () {

//		panel = transform.Find ("PanelLoading").gameObject;
//		string token = PlayerPrefs.GetString ("token");
//		if (token != "") {
//			StartCoroutine(HTTPManager.RequestLogin (token, (error, response) => {
//				if(error != null){
//					print(error.ToString());
//					mensagemErro.text = error.ToString();
//				}else{
//					string status = response["status"];
//					if (status == "true") {
//						returnRequestToken(Application.version.ToString(), error, response);
//					} else {
//						mensagemErro.text = "Sua sessão expirou.";
//					}
//				}
//			}));
//			//gameObject.SetActive(false);
//		}
//		if (PlayerPrefs.GetInt ("isCheck") == 0) {
//			this.check.isOn = false;
//		} else {
//			this.check.isOn = true;
//		}
//		if (PlayerPrefs.GetString ("login") != null && this.check.isOn) {
//			login.text = PlayerPrefs.GetString("login");
//		}

	}	
		
//	public void returnRequestToken(string versionPlataforma,ConnectionError error, JSONNode response){
//		StartCoroutine(HTTPManager.RequestVersion (versionPlataforma, (err, resp) => {
//			if (error != null) {
//				print(error.ToString());
//				mensagemErro.text = err.ToString();
//			} else {
//				string status = resp["status"];
//				if(status == "true") {
//					LobbyTableViewController.GetInstance().namePlayer.GetComponent<Text>().text = response["name"];
//					float credits = float.Parse(response["credits"]);
//					LobbyTableViewController.GetInstance().credits.GetComponent<Text> ().text = formatString(credits);
//					PlayerPrefs.SetString ("underMnager", response ["underManager"]);
//					gameObject.SetActive(false);
//				}else{
//					//Chamar alerta
//					panelAtualizar.SetActive (true);
//					panelAlert.SetActive (true);
//				}
//			}
//		}));
//	}


//	public void returnRequestLogin(string versionPlataforma,ConnectionError error, JSONNode response){
//		StartCoroutine(HTTPManager.RequestVersion (versionPlataforma, (err, resp) => {
//			if (error != null) {
//				print(error.ToString());
//				mensagemErro.text = err.ToString();
//			} else {
//				string status = resp["status"];
//				if(status == "true"){
//					mensagemErro.text = "";
//					LoggedInWithResponse (response);
//				}else{
//					//Chamar alerta
//					panelAtualizar.SetActive (true);
//					panelAlert.SetActive (true);
//				}
//			}
//		}));
//	}

	//formatar creditos para PT-BR
	public string formatString(float credits){

		var culturaBr = new CultureInfo("pt-BR"); //pt-BR usada como base
		culturaBr.NumberFormat.NumberDecimalDigits = 2;
		culturaBr.NumberFormat.NumberGroupSeparator = ".";
		culturaBr.NumberFormat.NumberDecimalSeparator = ",";

		return string.Format(culturaBr, "R$ {0:N}", credits);
	}
//
//	public void Login_Cadastro_Click(GameObject sender) {
//		if (sender.name == "ButtonEntrar") {
//			//Começa a rodar o load
//			if (login.text != "" && password.text != "") {
//				SetLoading (true);
//				iTween.RotateBy (progress.gameObject, iTween.Hash ("z", -5, "time", 5, "looptype", "loop", "easetype", "linear"));
//				StartCoroutine (HTTPManager.RequestLogin (login.text, password.text, (error, response) => {
//					if (error != null) {
//						print (error.ToString ());
//						mensagemErro.text = error.ToString ();
//					} else {
//						returnRequestLogin(Application.version.ToString(), error, response);
//					}
//					SetLoading (false);
//				}));
//			} else {
//				mensagemErro.text = Localizator.Localize ("Fill in the fields.");
//			}
//		}
//
//		if (sender.name == "ButtonCadastrar") {
//			print("cadastre-se");
//			Application.OpenURL("http://games.bets99.com/");
//		}
//	}
//
//	public void SetLoading(bool loading){
//		panel.SetActive(loading);
//		progress.gameObject.SetActive(loading);
//	}

//	public void LoggedInWithResponse(JSONNode response){
//		if (PlayerPrefs.GetInt ("isCheck") == 1) {
//			PlayerPrefs.SetString("login", login.text);
//		} else {
//			PlayerPrefs.SetString("login", "");
//		}
//
//		LobbyTableViewController.GetInstance().namePlayer.GetComponent<Text>().text = response["name"];
//		float credits = float.Parse(response["credits"]);
//		LobbyTableViewController.GetInstance().credits.GetComponent<Text> ().text = formatString(credits);
//		string underManager  = response ["underManager"];
//		PlayerPrefs.SetString ("underManager", underManager);
//
//		if (underManager == "true") {
//			PlayerPrefs.SetString ("underMnager", response ["underManager"]);
//		}
//
//		PlayerPrefs.SetString ("token", response["token"]);
//		
//		gameObject.SetActive(false);
//	}

	public void ClearLogin(){
		if (PlayerPrefs.GetInt ("isCheck") == 0) {
			login.text = "";
		} else {
			if (PlayerPrefs.GetString ("login") != null) {
				login.text = PlayerPrefs.GetString("login");
			}
		}
		PlayerPrefs.SetString ("UserLogado", "");
		PlayerPrefs.SetString ("credits", "");
		password.text = "";
		gameObject.SetActive(true);
	}

	public void ToggleValue(Toggle toggle) {
		if (toggle.isOn)
			PlayerPrefs.SetInt ("isCheck", 1);
		else
			PlayerPrefs.SetInt ("isCheck", 0);

		isCheck = toggle.isOn;
	}

	public void ToggleValue(Text toggle) {
		if (this.check.isOn) {
			this.check.isOn = false;
			PlayerPrefs.SetInt ("isCheck", 0);
		} else {
			PlayerPrefs.SetInt ("isCheck", 1);
			this.check.isOn = true;
		}

		isCheck = this.check.isOn;
	}

	public void LoginText(Text loginText){
		login.text = loginText.text;
	}

	public void PasswordText(InputField passwordText){
		password.contentType = InputField.ContentType.Standard;
		password.text = passwordText.text;
		password.contentType = InputField.ContentType.Password;
	}

	public void Alert_Click(GameObject sender) {
		if (sender.name == "ButtonAtualizar") {
			Application.OpenURL("http://games.bets99.com/");
		}
	}
}
