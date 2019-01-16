using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

    public static void SaveSettingsData() {
        //playerPrefs for settings
    }

    public static void loadSettingsData() {
        //playerPrefs for settings
    }
    public static void SaveGameData(CharacterData data, string path) {
        //JSON for Data
        string jsonString = JsonUtility.ToJson(data);

        using (StreamWriter streamWriter = File.CreateText(path)) {
            streamWriter.Write(jsonString);
        }

    }

    public static CharacterData LoadGameData(string path) {
        //JSON for data

        using (StreamReader streamReader = File.OpenText(path)) {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<CharacterData>(jsonString);
        }
    }
}
