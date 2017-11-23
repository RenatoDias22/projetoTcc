
using System;
using System.Collections.Generic;

public class Aprendizagem : IComparable<Aprendizagem> {

    public string pontosAcertos;
	public string pontosErro;
	public string pontosTotal;

    public Aprendizagem(){
        this.pontosAcertos = "0";
        this.pontosErro = "0";
        this.pontosTotal = "0";
    }

    public Aprendizagem(string acerto, string erros, string total){
        this.pontosAcertos = acerto;
        this.pontosErro = erros;
        this.pontosTotal = total;
    }
 
    public int CompareTo(Aprendizagem comparePart) {
        if (comparePart == null){
            return 1;
        } else { 
            return this.pontosTotal.CompareTo(comparePart.pontosTotal);
        }
    }
}