using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    public static void SaveGameData(CharacterData data) {

        string path = getPath(false);

        //Binary for Data

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate)) {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    public static CharacterData LoadGameData() {

        string path = getPath(true);
        if (path == null) {
            return null;
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(path, FileMode.Open)) {
            return (CharacterData)binaryFormatter.Deserialize(fileStream);
        }
    }

    private static string getPath(bool loadData) {
        string folderPath = Path.Combine(Application.persistentDataPath, "GameData");

        if (loadData) {
            if (folderPath.Length > 0)
                return Directory.GetFiles(folderPath, "Player1.dat")[0];
            else return null;
        } else {
            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }
            return Path.Combine(folderPath, "Player1.dat");
        }
    }
}
