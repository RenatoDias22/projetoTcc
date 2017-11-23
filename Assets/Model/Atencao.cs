public class Atencao {

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
}