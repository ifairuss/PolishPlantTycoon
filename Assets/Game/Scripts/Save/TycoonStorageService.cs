using System.IO;
using UnityEngine;

public class TycoonStorageService : MonoBehaviour
{
    private const string _key = "TycoonSaveData"; // название файла сохр храниться будет - (Application.persistentDataPath + "/" + _key) тобто в AppData/LocaLow(Название компании/Название проекта)

    private void OnSave()
    {
        // Этот метод будет вызываться каждые 30 сек и будет сохранять данные в json формате
    }

    private void OnLoad()
    {
        // Этот метод будет визиваться при старте игры в EntryPoint и загружать сохранение перед этим десереализировать их
    }
}
