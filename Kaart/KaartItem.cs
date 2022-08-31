abstract class KaartItem : Tekenbaar {
    private Coordinaat _locatie;

    public KaartItem(Kaart kaart, Coordinaat _locatie) {
        this._locatie = _locatie;
    }

    public void TekenConsole(ConsoleTekener t) {

    }

    public Coordinaat Locatie { 
        get {
            return this._locatie;
        }
        set {
            //Controleer of loc in kaart
        }
    }

    public abstract char Karakter {get;}
    

}