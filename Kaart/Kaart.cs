class Kaart {
    public readonly int Breedte;
    public readonly int Hoogte;

    private List<KaartItem> kaartItems = new List<KaartItem>();
    private List<Pad> paden = new List<Pad>();

    public Kaart(int breedte, int hoogte) {
        this.Breedte = breedte;
        this.Hoogte = hoogte;
    }

    public void Teken(Tekener t) {

    }

    public void VoegItemToe(KaartItem item) {
        kaartItems.Add(item);
    }

    public void VoegPadToe(Pad pad) {
        paden.Add(pad);
    }

}