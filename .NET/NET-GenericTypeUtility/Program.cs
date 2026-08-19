Persona p = new Persona(){nome="Fabrizio", cognome="Amorelli", eta=27};

GenericUtility.PrintProperty<Persona>(p, "eta2");

GenericUtility.PrintAllPropertyByType<Persona>(p, typeof(uint));

GenericUtility.PrintAllProperty<Persona>(p);

Console.WriteLine(GenericUtility.CheckPropertySet<Persona>(p,"eta"));

Console.WriteLine(GenericUtility.CheckAllPropertySet(p));

GenericUtility.PrintAllMethod<Persona>(p);

GenericUtility.CallMethod<Persona>(p, "printEta",null);

GenericUtility.CallMethod<Persona>(p, "printPersona", new object[]{"ciao",2});

GenericUtility.PrintAllMethodByType<Persona>(p,typeof(void));

GenericUtility.PrintAllMethod<Persona>(p);

Console.WriteLine(GenericUtility.CheckMethodExist<Persona>(p,"printEta"));