public static class DynamicProperties
{
    public static void PrintAllProperties(dynamic myObj)
    {
        var dict = (IDictionary<string, object>)myObj;
        dict.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
    }

    public static void DeleteProperty(dynamic myObj, string key)
    {
        var dict = (IDictionary<string, object>)myObj;
        dict.Remove(key);
    }

    public static int CountProperties(dynamic myObj)
    {
        var dict = (IDictionary<string, object>)myObj;
        return dict.Count();
    }

    public static bool SearchKey(dynamic myObj, string key)
    {
        var dict = (IDictionary<string, object>)myObj;
        return dict.ContainsKey(key);
    }

    public static object GetValueFromKey(dynamic myObj, string key)
    {
        var dict = (IDictionary<string, object>)myObj;
        if (dict.ContainsKey(key))
            return dict[key];
        else
            return "";
    }

    public static bool SearchValue(dynamic myObj, object value){
        var dict = (IDictionary<string, object>)myObj;
        var key = dict.FirstOrDefault(x => x.Value == value).Key;
        if(key == null)
            return false;
        else
            return true;
    }

    public static object GetKeyFromValue(dynamic myObj, object value)
    {
        var dict = (IDictionary<string, object>)myObj;
        var key = dict.FirstOrDefault(x => x.Value == value).Key;
        if(key == null)
            return "";
        else
            return key;
    }
}