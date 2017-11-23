using System;
using System.Collections.Generic;

public class Atencao : IComparable<Atencao> {

    public string pontosAcertos;
	public string pontosErro;
	public string pontosTotal;

    public Atencao(){
        this.pontosAcertos = "0";
        this.pontosErro = "0";
        this.pontosTotal = "0";
    }

    public Atencao(string acerto, string erros, string total){
        this.pontosAcertos = acerto;
        this.pontosErro = erros;
        this.pontosTotal = total;
    }

    // implement IComparable interface
    public int CompareTo(Atencao comparePart) {
        if (comparePart == null){
            return 1;
        } else {
            return this.pontosTotal.CompareTo(comparePart.pontosTotal);
        }
    }
}