using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Application.Extensions;

public static class SessionHelper
{
    public static void SetObject<T>(ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetObject<T>(ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }

    public static void SetString(ISession session, string key, string value)
    {
        session.SetString(key, value);
    }

    public static string? GetString(ISession session, string key)
    {
        return session.GetString(key);
    }

    public static void Remove(ISession session, string key)
    {
        session.Remove(key);
    }

    public static void SelectGiaiDau(ISession session,string idGiaiDau)
    {
        session.SetString("idGiaiDau", idGiaiDau);
    }
    public static string? GiaiDauId(ISession session)
    {
        return session.GetString("idGiaiDau");
    }
}
