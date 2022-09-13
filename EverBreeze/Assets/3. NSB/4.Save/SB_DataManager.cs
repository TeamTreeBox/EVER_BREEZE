using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SB_DataManager : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }

    static SB_DataManager _instance;
    public static SB_DataManager Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "SB_DataManager";
                _instance = _container.AddComponent(typeof(SB_DataManager)) as SB_DataManager;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }

    //���� ������ �����̸� ����
    public string GameDataFileName = "EverBreeze.json";

    public SB_GameData _gameData;
    public SB_GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }


    private void Start()
    {
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
      

        //������ �Ǿ��ִٸ�
        if (File.Exists(filePath))
        {
            print("Here comes trouble");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<SB_GameData>(FromJsonData);
        }

        //������ �Ǿ������ʴٸ�
        else
        {
            print("Here come New Challenger");
            _gameData = new SB_GameData();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;

        // �̹� ����� ������ �ִٸ� �����
        File.WriteAllText(filePath, ToJsonData);

        // �ùٸ��� ����ƴ��� Ȯ��(���� ����)
        print("����Ϸ�");
        print("Ʃ�丮����" + gameData.isTutorial_Clear);
        print("��1" + gameData.isQuest_1_Clear);
        print("��2" + gameData.isQuest_2_Clear);
        print("��3" + gameData.isQuest_3_Clear);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }


}
