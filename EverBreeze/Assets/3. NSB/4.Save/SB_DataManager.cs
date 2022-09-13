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

    //게임 데이터 파일이름 설정
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
      

        //저장이 되어있다면
        if (File.Exists(filePath))
        {
            print("Here comes trouble");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<SB_GameData>(FromJsonData);
        }

        //저장이 되어있지않다면
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

        // 이미 저장된 파일이 있다면 덮어쓰기
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인(자유 변형)
        print("저장완료");
        print("튜토리얼은" + gameData.isTutorial_Clear);
        print("퀘1" + gameData.isQuest_1_Clear);
        print("퀘2" + gameData.isQuest_2_Clear);
        print("퀘3" + gameData.isQuest_3_Clear);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }


}
