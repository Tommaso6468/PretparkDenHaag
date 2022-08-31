class Pad : Tekenbaar {

    private float? lengteBerekend;

    public Coordinaat van {set; get;}
    public Coordinaat naar {set; get;}
 
    public float Lengte() {
        return 0;
    }

    public float Afstand(Coordinaat c) {
        return 0;
    }

    public void TekenConsole(ConsoleTekener t) {

    }

}