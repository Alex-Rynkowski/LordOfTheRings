using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saving_System
{
    public static class SaveSystem
    {
        public static void Save(Hud.Hud hud)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/.sav";
            FileStream fileStream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(hud);

            formatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public static PlayerData Load()
        {
            string path = Application.persistentDataPath + "/.sav";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(fileStream) as PlayerData;
                fileStream.Close();
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
}