using Newtonsoft.Json;

var myObj = new {
    Nome= "Fabrizio", // a string
    Numero=27, // a integer
    myArray = new string[] { "Small", "Medium", "Large" } // an array
};

var myObj2 = new {

    creationDate= DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
    userLocation = new
    {// another object
        type="Point",
        coordinates=new double[]{35.73146971344001, 19.674531822652536}
    } 

};

string output = JsonConvert.SerializeObject(myObj);
string output2 = JsonConvert.SerializeObject(myObj2,Formatting.Indented);// Use Formatting.Indented to Pretty Print

Console.WriteLine(output);
Console.WriteLine("");
Console.WriteLine(output2);
