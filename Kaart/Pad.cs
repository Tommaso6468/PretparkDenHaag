class Pad : Tekenbaar
{

    private float? lengteBerekend;
    private Coordinaat van_;
    private Coordinaat naar_;

    public Coordinaat van
    {
        set
        {
            this.van_ = value;
            this.lengteBerekend = null;
        }
        get
        {
            return this.van_;
        }
    }

    public Coordinaat naar
    {
        set
        {
            this.naar_ = value;
            this.lengteBerekend = null;
        }
        get
        {
            return this.naar_;
        }
    }

    public float Lengte()
    {
        float result = (float)Math.Sqrt((Math.Pow(naar.x - van.x, 2) + Math.Pow(naar.y - van.y, 2))) * 1000;
        this.lengteBerekend = result;
        return result;
    }

    public float Afstand(Coordinaat c)
    {


        float resultaat = 0; //heftige berekeningen
        this.lengteBerekend = resultaat;
        return resultaat;
    }

    public void TekenConsole()
    {
        int dx = Math.Abs(naar.x - van.x);
        int dy = Math.Abs(naar.y - van.y);
        int x = van.x;
        int y = van.y;
        int n = 1 + dx + dy;
        int x_inc = (naar.x > van.x) ? 1 : -1;
        int y_inc = (naar.y > van.y) ? 1 : -1;
        int error = dx - dy;
        dx *= 2;
        dy *= 2;

        for (; n > 0; --n)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("#");

            if (error > 0)
            {
                x += x_inc;
                error -= dy;
            }
            else
            {
                y += y_inc;
                error += dx;
            }
        }

        int avgX = (int)(van.x + naar.x) / 2;
        int avgY = (int)(van.y + naar.y) / 2;
        Console.SetCursorPosition(avgX, avgY);
        Console.WriteLine(Lengte().metSuffixen());
    }

}