using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class Config
{
    public string color;
    public string wheel;
}

[System.Serializable]
public class ConfigList
{
    public Config[] configs;
}

public class AISuggestionManager : MonoBehaviour
{
    public TMP_InputField themeInput;

    public TextMeshProUGUI suggestion1Text;
    public TextMeshProUGUI suggestion2Text;
    public TextMeshProUGUI suggestion3Text;

    public CarColorController colorController;
    public WheelManager wheelManager;

    Config[] currentConfigs;

    public void GenerateSuggestions()
    {
        StartCoroutine(CallAI(themeInput.text));
    }

    IEnumerator CallAI(string theme)
    {
        string url = "http://127.0.0.1:8000/suggest";

        string json = "{\"theme\":\"" + theme + "\"}";

        UnityWebRequest request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;

            currentConfigs = JsonHelper.FromJson<Config>(response);

            UpdateUI();
        }
        else
        {
            Debug.Log("API Error: " + request.error);
        }
    }

    void UpdateUI()
    {
        suggestion1Text.text = currentConfigs[0].color + " + " + currentConfigs[0].wheel;
        suggestion2Text.text = currentConfigs[1].color + " + " + currentConfigs[1].wheel;
        suggestion3Text.text = currentConfigs[2].color + " + " + currentConfigs[2].wheel;
    }

    public void ApplySuggestion1()
    {
        ApplyConfig(currentConfigs[0]);
    }

    public void ApplySuggestion2()
    {
        ApplyConfig(currentConfigs[1]);
    }

    public void ApplySuggestion3()
    {
        ApplyConfig(currentConfigs[2]);
    }

    void ApplyConfig(Config config)
    {
        // COLOR

        if (config.color == "red") colorController.SetRed();
        if (config.color == "blue") colorController.SetBlue();
        if (config.color == "black") colorController.SetBlack();

        // WHEELS

        if (config.wheel == "sport") wheelManager.SetSport();
        if (config.wheel == "luxury") wheelManager.SetLuxury();
        if (config.wheel == "classic") wheelManager.SetClassic();
    }
}