class VerificatieToken {

    private string? token_ = null;
    public string? token {
        get {return token_;} 
        set {if (token_ == null) token_ = value;}
    }

    private DateTime? verloopDatum_ = null;
    public DateTime? verloopDatum {
        get {return verloopDatum_;} 
        set {if (verloopDatum_ == null) verloopDatum_ = value;}
    }

    public VerificatieToken() {
        Initialize();
    }

    private void Initialize() {
        Random rand = new Random();
        int stringlen = rand.Next(1, 1000);
        int randValue;
        string str = "";
        char letter;
        for (int i = 0; i < stringlen; i++)
        {
        randValue = rand.Next(33, 126);
        letter = Convert.ToChar(randValue);
        str = str + letter;
        }
        this.token = str;

        verloopDatum = DateTime.Now.AddDays(3).Date;
    }

    public void ResetToken() {
        this.verloopDatum_ = null;
        this.token_ = null;
        Initialize();
    }

}