using UnityEngine;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string wrapped = "{\"configs\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrapped);
        return wrapper.configs;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] configs;
    }
}