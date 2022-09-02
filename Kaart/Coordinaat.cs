struct Coordinaat
{

    public readonly int x;
    public readonly int y;

    public Coordinaat(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Coordinaat operator +(Coordinaat c1, Coordinaat c2)
    {
        var x = c1.x + c2.x;
        var y = c1.y + c2.y;
        return new Coordinaat(x, y);
    }

}