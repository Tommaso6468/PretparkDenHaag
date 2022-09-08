namespace Pretpark;
public class Attractie : KaartItem
{
    private int? _minimaleLengte;
    private int _angstLevel;
    private string _naam = "empty";

    public Attractie(Kaart k, Coordinaat c) : base(k, c) { }

    public override char Karakter
    {
        get { return 'A'; }
    }

}
