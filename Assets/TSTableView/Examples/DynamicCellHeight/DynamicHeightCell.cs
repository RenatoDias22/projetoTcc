using UnityEngine;
using System.Collections;
using Tacticsoft;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Tacticsoft.Examples
{
    //Inherit from TableViewCell instead of MonoBehavior to use the GameObject
    //containing this component as a cell in a TableView
    public class DynamicHeightCell : TableViewCell
    {
        public Text m_rowNumberAcertos;
        public Text m_rowNumberErros;
        public Text m_rowNumberPontuacao;
        public Text m_rowNumber;
        public Slider m_cellHeightSlider;

        public string acertos { get; set; }
        public string erros { get; set; }
        public string total { get; set; }
        public int rowNumber { get; set; }

        [System.Serializable]
        public class CellHeightChangedEvent : UnityEvent<int, float> { }
        public CellHeightChangedEvent onCellHeightChanged;

        void Update() {
            m_rowNumberAcertos.text = acertos;//"Acertos " + rowNumber.ToString();
            m_rowNumberErros.text = erros;//"Erros " + rowNumber.ToString();
            m_rowNumberPontuacao.text = total;//"Pontuação " + rowNumber.ToString();
            m_rowNumber.text = rowNumber.ToString();
        }

        public void SliderValueChanged(float value) {
            onCellHeightChanged.Invoke(rowNumber, value);
        }

        public float height {
            get { return m_cellHeightSlider.value; }
            set { m_cellHeightSlider.value = value; }
        }


    }
}
