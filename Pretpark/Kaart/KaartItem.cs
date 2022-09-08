using System;

namespace Pretpark;
public abstract class KaartItem : Tekenbaar
{
    private Coordinaat _locatie;
    private Kaart kaart;

    public KaartItem(Kaart kaart, Coordinaat _locatie)
    {
        this._locatie = _locatie;
        this.kaart = kaart;
    }

    public void TekenConsole()
    {
        Console.SetCursorPosition(this._locatie.x, this._locatie.y);
        Console.WriteLine(Karakter);
    }

    public Coordinaat Locatie
    {
        get
        {
            return this._locatie;
        }
        set
        {
            if (value.x < 0 || value.y < 0) throw new Exception("Het coordinaat mag niet negatief zijn");
            if (value.x > kaart.Breedte || value.y > kaart.Hoogte) throw new Exception("Het coordinaat valt niet binnen de kaart");
            this._locatie = value;
        }
    }

    public abstract char Karakter { get; }


}
