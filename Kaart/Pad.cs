class Pad : Tekenbaar {

    private float? lengteBerekend;

    public Coordinaat van {
        set{
            this.van = van;
            this.lengteBerekend = null;
        } get{
            return this.van;
        }
    }

    public Coordinaat naar {
        set {
            this.naar = naar;
            this.lengteBerekend = null;
        } get {
            return this.naar;
        }
    }
 
    public float Lengte() {
        return (float) Math.Sqrt((Math.Pow(naar.x - van.x, 2) + Math.Pow(naar.y - van.y, 2)));
    }

    public float Afstand(Coordinaat c) {


        float resultaat = 0; //heftige berekeningen
        this.lengteBerekend = resultaat;
        return resultaat;
    }

    public void TekenConsole(ConsoleTekener t) {
        
    }

}