public class Memoria {

    public string pontosAcertos;
	public string pontosErro;
	public string pontosTotal;

    public Memoria(){
        this.pontosAcertos = "0";
        this.pontosErro = "0";
        this.pontosTotal = "0";
    }

    public Memoria(string acerto, string erros, string total){
        this.pontosAcertos = acerto;
        this.pontosErro = erros;
        this.pontosTotal = total;
    }
}
