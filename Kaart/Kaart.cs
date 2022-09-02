class Kaart
{
    public readonly int Breedte;
    public readonly int Hoogte;

    private List<KaartItem> kaartItems = new List<KaartItem>();
    private List<Pad> paden = new List<Pad>();

    public Kaart(int breedte, int hoogte)
    {
        this.Breedte = breedte;
        this.Hoogte = hoogte;
    }

    public void Teken()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(" ");
        }
        foreach (var i in paden)
        {
            i.TekenConsole();
        }
        foreach (var i in kaartItems)
        {
            i.TekenConsole();
        }
    }

    public void VoegItemToe(KaartItem item)
    {
        kaartItems.Add(item);
    }

    public void VoegPadToe(Pad pad)
    {
        paden.Add(pad);
    }

}