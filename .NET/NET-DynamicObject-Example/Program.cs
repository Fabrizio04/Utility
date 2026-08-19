using System.Dynamic;
using Newtonsoft.Json.Linq;

//Example with Expando Object Class

dynamic persona = new ExpandoObject();

persona.nome = "Fabrizio";
persona.cognome = "Amorelli";
persona.eta = 27;

persona.printAllData = (Action)(() => {
    Console.WriteLine($"{persona.nome} - {persona.cognome} - {persona.eta}");
});

//persona.printAllData();
//DeleteProperty(persona, "nome");

//DynamicProperties.PrintAllProperties(persona);
//Console.WriteLine(DynamicProperties.CountProperties(persona));
//Console.WriteLine(DynamicProperties.SearchKey(persona, "nome"));
//Console.WriteLine(DynamicProperties.GetValueFromKey(persona, "cognome"));
//Console.WriteLine(DynamicProperties.SearchValue(persona, "Fabrizio"));
//Console.WriteLine(DynamicProperties.GetKeyFromValue(persona, "Fabrizio"));



// Example with Custom Dynamic Object Class

dynamic person = new DynamicDictionary(true);

//Dynamic properties
person.FirstName = "Fabrizio";
person.LastName = "Amorelli";

//Get number of Properties
//Console.WriteLine(person.Count);

//Delete a property with IDictionary class function
person.Remove("lastname");

//Print All Properties with Dynamic Properties Class
//DynamicProperties.PrintAllProperties(person);



//Example with JObject Class (Newtonsoft.Json)

dynamic person2 = new JObject();

person2.FirstName = "Fabrizio2";
person2.LastName = "Amorelli2";

//Delete a property with JObject class function
//person2.Remove("FirstName");

//Get number of properties
var c = (IEnumerable<dynamic>)person2;
Console.WriteLine(c.Count());

//Get Value from Key
var l = c.Where(x => x.Name == "FirstName").ToList();
Console.WriteLine(l.First().Value);

//Get Key from Value
var l2 = c.Where(x => x.Value == "Fabrizio2").ToList();
Console.WriteLine(l2.First().Name);

//Get all properties
foreach (JProperty property in person2.Properties())
{
    //Console.WriteLine(property.Name + ": " + property.Value);
}

//Print as JSON Object
//Console.WriteLine(person2);