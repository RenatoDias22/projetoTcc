using UnityEngine;
using System.Collections.Generic;
using Tacticsoft;
using UnityEngine.SceneManagement;

namespace Tacticsoft.Examples
{
    //An example implementation of a class that communicates with a TableView
    public class DynamicHeightTableViewController : MonoBehaviour, ITableViewDataSource
    {
        public DynamicHeightCell m_cellPrefab;
        public TableView m_tableView;

        List<Aprendizagem> aprendizagemArray = new List<Aprendizagem>();
        List<Atencao> atencaoArray = new List<Atencao>();
        List<Memoria> memoriaArray = new List<Memoria>();

        public int m_numRows = 0;
        private int m_numInstancesCreated = 0;

        private Dictionary<int, float> m_customRowHeights;

        //Register as the TableView's delegate (required) and data source (optional)
        //to receive the calls
        void Start() {
            m_customRowHeights = new Dictionary<int, float>();
            m_tableView.dataSource = this;
        }

        public void SendBeer() {
            // Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?business=contact@tacticsoft.net&cmd=_xclick&item_name=Beer%20for%20TSTableView&currency_code=USD&amount=5.00");
        }

        #region ITableViewDataSource

        //Will be called by the TableView to know how many rows are in this table
        public int GetNumberOfRowsForTableView(TableView tableView) {

            if (m_numRows == 1){
                return aprendizagemArray.Count;
            }
            if(m_numRows == 2){
                return atencaoArray.Count;
            }
            return memoriaArray.Count;
        }

        //Will be called by the TableView to know what is the height of each row
        public float GetHeightForRowInTableView(TableView tableView, int row) {
            return GetHeightOfRow(row);
        }

        //Will be called by the TableView when a cell needs to be created for display
        public TableViewCell GetCellForRowInTableView(TableView tableView, int row) {
            DynamicHeightCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as DynamicHeightCell;
            if (cell == null) {
                cell = (DynamicHeightCell)GameObject.Instantiate(m_cellPrefab);
                cell.name = "DynamicHeightCellInstance_" + (++m_numInstancesCreated).ToString();
                cell.onCellHeightChanged.AddListener(OnCellHeightChanged);
            }

            cell.rowNumber = row;
            if(m_numRows == 0){
                if(this.memoriaArray.Count > 0){
                    cell.acertos = this.memoriaArray[row].pontosAcertos;
                    cell.erros = this.memoriaArray[row].pontosErro;
                    cell.total = this.memoriaArray[row].pontosTotal;
                }
            }

            if(m_numRows == 1){
                if(this.aprendizagemArray.Count > 0){
                    cell.acertos = this.aprendizagemArray[row].pontosAcertos;
                    cell.erros = this.aprendizagemArray[row].pontosErro;
                    cell.total = this.aprendizagemArray[row].pontosTotal;
                }
            }

            if(m_numRows == 2){
                if(this.atencaoArray.Count > 0){
                    cell.acertos = this.atencaoArray[row].pontosAcertos;
                    cell.erros = this.atencaoArray[row].pontosErro;
                    cell.total = this.atencaoArray[row].pontosTotal;
                }
            }

            cell.height = GetHeightOfRow(row);

            return cell;
        }

        #endregion

        private float GetHeightOfRow(int row) {
            if (m_customRowHeights.ContainsKey(row)) {
                return m_customRowHeights[row];
            } else {
                return m_cellPrefab.height;
            }
        }

        private void OnCellHeightChanged(int row, float newHeight) {
            if (GetHeightOfRow(row) == newHeight) {
                return;
            }
            //Debug.Log(string.Format("Cell {0} height changed to {1}", row, newHeight));
            m_customRowHeights[row] = newHeight;
            m_tableView.NotifyCellDimensionsChanged(row);
        }

        public void Jogo_Selecionado_Click(GameObject sender) {
            if (sender.name == "ButtonRankMemoria") {
                string acertos = PlayerPrefs.GetString("ArrayMemoriaAcertos");
                string[] acertosArray = acertos.Split(' ');
                string erros = PlayerPrefs.GetString("ArrayMemoriaErros");
                string[] errosArray = erros.Split(' ');
                string total = PlayerPrefs.GetString("ArrayMemoriaPontosTotal");
                string[] totalArray = total.Split(' ');
                if(acertosArray.Length > 0){
                    memoriaArray = new List<Memoria>();
                    m_numRows = 0;
                    for (int i = 1; i < acertosArray.Length; i++){
                        memoriaArray.Add(new Memoria(acertosArray[i],errosArray[i],totalArray[i]));
                    }
                    m_tableView.ReloadData();
                }
            }

            if (sender.name == "ButtonRankAprendizagem") {
                string acertos = PlayerPrefs.GetString("ArrayAprendizagemAcertos");
                string[] acertosArray = acertos.Split(' ');
                string erros = PlayerPrefs.GetString("ArrayAprendizagemErros");
                string[] errosArray = erros.Split(' ');
                string total = PlayerPrefs.GetString("ArrayAprendizagemPontosTotal");
                string[] totalArray = total.Split(' ');
                if(acertosArray.Length > 0){
                    m_numRows = 1;
                    aprendizagemArray = new List<Aprendizagem>();
                    for (int i = 1; i < acertosArray.Length; i++){
                        aprendizagemArray.Add(new Aprendizagem(acertosArray[i],errosArray[i],totalArray[i]));
                    }
                    m_tableView.ReloadData();
                }
            }

            if (sender.name == "ButtonRankAtencao") {
                string acertos = PlayerPrefs.GetString("ArrayAtencaoAcertos");
                string[] acertosArray = acertos.Split(' ');
                string erros = PlayerPrefs.GetString("ArrayAtencaoErros");
                string[] errosArray = erros.Split(' ');
                string total = PlayerPrefs.GetString("ArrayAtencaoPontosTotal");
                string[] totalArray = total.Split(' ');
                if(acertosArray.Length > 0){
                    m_numRows = 2;
                    atencaoArray = new List<Atencao>();
                    for (int i = 1; i < acertosArray.Length; i++){
                        atencaoArray.Add(new Atencao(acertosArray[i],errosArray[i],totalArray[i]));
                    }
                    m_tableView.ReloadData();
                }
            }

            if (sender.name == "ButtonRankVoltar") {
                SceneManager.LoadScene ("TelaPrincipal", LoadSceneMode.Single);
            }
        }

    }
}
