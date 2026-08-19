class Program {

    private static Func<string, string> convert = s => s.ToUpper();
	
    private static void ConcatenateString(Func<string, string, string> myFunc){
        Console.WriteLine(myFunc.Invoke("Fabrizio","Amorelli"));
    }

    private static void FormatString(Func<string, string, string> myFunc){
        string aa = myFunc("fabrizio","amorelli");
        Console.WriteLine(aa);
    }
    
    private static string Concatena(string a, string b){
        return $"{a}-{b}";
    }
    
    public static void Main(){
        // passo una lambda expression al delegate
        FormatString((str, str2) => {
            return str.ToUpper() +"-"+ str2.ToUpper();
        });

        // passo un metodo al delegate
        ConcatenateString(Concatena);

        // uso un attributo
        string a = convert("fabrizio");
        Console.WriteLine(a);
    }
}