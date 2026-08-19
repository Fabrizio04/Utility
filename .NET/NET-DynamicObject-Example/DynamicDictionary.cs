using System.Collections;
using System.Dynamic;

public class DynamicDictionary : DynamicObject, IDictionary<string, object>
{
    private readonly IDictionary<string, object> _dictionary;

    public DynamicDictionary(bool ignoreCase = true)
    {
        _dictionary = new Dictionary<string, object>(ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
    }

    public void Add(KeyValuePair<string, object> item)
    {
        _dictionary.Add(item);
    }

    public void Clear()
    {
        _dictionary.Clear();
    }

    public bool Contains(KeyValuePair<string, object> item)
    {
        return _dictionary.Contains(item);
    }

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
        _dictionary.CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, object> item)
    {
        return _dictionary.Remove(item);
    }

    public int Count => _dictionary.Keys.Count;

    public bool IsReadOnly => _dictionary.IsReadOnly;

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool ContainsKey(string key)
    {
        return _dictionary.ContainsKey(key);
    }

    public void Add(string key, object value)
    {
        _dictionary.Add(key, value);
    }

    public bool Remove(string key)
    {
        return _dictionary.Remove(key);
    }

    public bool TryGetValue(string key, out object value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    public object this[string key]
    {
        get
        {
            object result;
            _dictionary.TryGetValue(key, out result);
            return result;
        }

        set { _dictionary[key] = value; }
    }

    public ICollection<string> Keys => _dictionary.Keys;

    public ICollection<object> Values => _dictionary.Values;

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (_dictionary.ContainsKey(binder.Name))
        {
            result = _dictionary[binder.Name];
            return true;
        }

        if (base.TryGetMember(binder, out result))
        {
            return true;
        }


        result = null;
        return true;
    }

    public override bool TrySetMember(SetMemberBinder binder, object result)
    {
        if (!_dictionary.ContainsKey(binder.Name)) { _dictionary.Add(binder.Name, result); }
        else { _dictionary[binder.Name] = result; }
        return true;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        if (_dictionary.ContainsKey(binder.Name) && _dictionary[binder.Name] is Delegate)
        {
            var del = (Delegate)_dictionary[binder.Name];
            result = del.DynamicInvoke(args);
            return true;
        }

        return base.TryInvokeMember(binder, args, out result);
    }

    public override bool TryDeleteMember(DeleteMemberBinder binder)
    {
        if (_dictionary.ContainsKey(binder.Name))
        {
            _dictionary.Remove(binder.Name);
            return true;
        }

        return base.TryDeleteMember(binder);
    }
}