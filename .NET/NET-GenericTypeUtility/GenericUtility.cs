public static class GenericUtility
{
    public static void PrintProperty<T>(T t, string property) where T : class
    {
        try
        {
            var fieldValue = t.GetType().GetProperty(property).GetValue(t);
            Console.WriteLine(fieldValue);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERRORE: {e.Message}");
        }

    }

    public static void PrintAllPropertyByType<T>(T t, Type type) where T : class
    {
        foreach (var propertyInfo in t.GetType().GetProperties())
        {
            if (propertyInfo.PropertyType == type)
            {
                var propertyType = type.ToString().Replace("System.", "");
                Console.WriteLine($"{propertyInfo.Name} : {propertyType} = {propertyInfo.GetValue(t, null)}");
            }
        }
    }

    public static void PrintAllProperty<T>(T t) where T : class
    {
        foreach (var propertyInfo in t.GetType().GetProperties())
        {
            var propertyType = propertyInfo.PropertyType.ToString().Replace("System.", "");
            Console.WriteLine($"{propertyInfo.Name} : {propertyType} = {propertyInfo.GetValue(t, null)}");
        }
    }

    public static bool CheckPropertySet<T>(T t, string property) where T : class
    {
        try
        {
            var fieldValue = t.GetType().GetProperty(property).GetValue(t);

            if (fieldValue == null)
                return false;
            else
                return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERRORE: {e.Message}");
            return false;
        }
    }
    public static bool CheckAllPropertySet<T>(T t) where T : class
    {
        foreach (var propertyInfo in t.GetType().GetProperties())
        {

            if (propertyInfo.GetValue(t, null) == null)
            {
                return false;
            }

        }

        return true;
    }

    public static void CallMethod<T>(T t, string name, object[] param) where T : class
    {
        try
        {
            var fieldValue = t.GetType().GetMethod(name).Invoke(t, param);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERRORE: {e.Message}");
        }

    }

    public static bool CheckMethodExist<T>(T t, string name) where T : class
    {
        foreach (var methodInfo in t.GetType().GetMethods())
        {
            
            if(methodInfo.Name == name)
               return true;
            else
                continue;

        }

        return false;
    }

    public static void PrintAllMethodByType<T>(T t, Type type) where T : class
    {
        foreach (var methodInfo in t.GetType().GetMethods())
        {
            var parameters = methodInfo.GetParameters();

            if (methodInfo.ReturnType == type)
            {

                var methodReturnType = methodInfo.ReturnType.ToString().Replace("System.", "");

                string methodParameters = "";

                foreach (var element in parameters)
                {
                    methodParameters += $"{element.Name}:{element.ParameterType} ";
                }

                methodParameters = methodParameters.Replace("System.", "").Trim();
                Console.WriteLine($"{methodInfo.Name}:{methodReturnType}({methodParameters})");
            }
        }
    }

    public static void PrintAllMethod<T>(T t) where T : class
    {
        foreach (var methodInfo in t.GetType().GetMethods())
        {
            var parameters = methodInfo.GetParameters();
            var methodReturnType = methodInfo.ReturnType.ToString().Replace("System.", "");

            string methodParameters = "";

            foreach (var element in parameters)
            {
                methodParameters += $"{element.Name}:{element.ParameterType} ";
            }

            methodParameters = methodParameters.Replace("System.", "").Trim();
            Console.WriteLine($"{methodInfo.Name}:{methodReturnType}({methodParameters})");
        }
    }
}