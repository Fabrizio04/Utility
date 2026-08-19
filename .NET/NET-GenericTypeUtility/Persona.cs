public class Persona{
    public string nome {get; set;}
    public string cognome {get; set;}
    public uint? eta {get; set;}

    public void printPersona()
    {
        Console.WriteLine($"Ciao {nome} {cognome}");
    }

    public void printEta()
    {
        Console.WriteLine($"{nome} ha {eta} anni");
    }
}