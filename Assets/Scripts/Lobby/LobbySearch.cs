using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Tacticsoft.Examples;
using System;
using System.Collections.Generic;
using System.Linq;

public class LobbySearch : MonoBehaviour {

	public LobbyTableViewController lobbyController;
//	public InputField mainInputField;
	// Use this for initialization

//	void Awake(){
//		search = gameObject.GetComponent<InputField>();
//		Localizator.Localize(search.GetComponentInChildren<Text>());
//	}
//
	public InputField search;

	void Start () {
		
		var se = new InputField.SubmitEvent();
		se.AddListener(SearchName);
		//Tava onValueChange
		search.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
		search.onEndEdit = se;
	}

	private void SearchName(string arg0) {

		if(arg0 != "") {
			List<Sala> resultList = lobbyController.salasArray.FindAll(delegate(Sala s) { 
				String sala = s.nomeSala.ToUpper();
				return sala.Contains(arg0.ToUpper()); 
			});
			lobbyController.salasSearch = resultList;

			lobbyController.isSearch = true;
		} else {
			lobbyController.isSearch = false;
		}

		lobbyController.m_tableView.ReloadData();
	}

	// Update is called once per frame
//	void Update () {
//		InputField inputFieldCo = gameObject.GetComponent<InputField> ();
//		if (inputFieldCo.text != "") {
//			var search = inputFieldCo.text;
//			search = search.ToUpper ();
//			SearchName (search);
//		} else {
//			lobbyController.isSearch = false;
//		}
//	}

	// Invoked when the value of the text field changes.
	public void ValueChangeCheck()
	{
		//InputField inputFieldCo = gameObject.GetComponent<InputField> ();
		//if (inputFieldCo.text != "") {
		var searchAux = search.text;
		searchAux = searchAux.ToUpper();
		SearchName(searchAux);
//		} else {
//			lobbyController.isSearch = false;
//			lobbyController.m_tableView.ReloadData();
//		}
	}

}
