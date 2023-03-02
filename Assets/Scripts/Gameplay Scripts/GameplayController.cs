using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField] private int char2UnlockScore = 10, char3UnlockScore = 50;
    [SerializeField] private GameObject[] player;

    private int selectedCharacter = 0;
    public int SelectedCharacter 
    { 
        get { return selectedCharacter; } 
        set { selectedCharacter = value; }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        int gameData = DataManager.GetData(TagManager.DATA_INITIALIZED);

        if (gameData == 0)
        {
            selectedCharacter = 0;
            DataManager.SaveData(TagManager.DATA_SELECTED_CHARACTER, selectedCharacter);
            DataManager.SaveData(TagManager.DATA_HIGHSCORE, 0);
            DataManager.SaveData(TagManager.DATA_CHARACTER + "0", 1);
            DataManager.SaveData(TagManager.DATA_CHARACTER + "1", 0);
            DataManager.SaveData(TagManager.DATA_CHARACTER + "2", 0);
            DataManager.SaveData(TagManager.DATA_SOUND_PLAY, 1);
            DataManager.SaveData(TagManager.DATA_INITIALIZED, 1);
        }
        else if (gameData == 1)
        {
            selectedCharacter = DataManager.GetData(TagManager.DATA_SELECTED_CHARACTER);
        }
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;    
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if(scene.name == TagManager.SCENE_NAME_GAMEPLAY)
        {
            LoadCharacter();
            GameObject.FindWithTag(TagManager.TAG_MAIN_CAMERA).GetComponent<CameraFollow>().FindPlayerReference();
        }
    }

    private void LoadCharacter()
    {
        Instantiate(player[DataManager.GetData(TagManager.DATA_SELECTED_CHARACTER)], Vector3.zero, Quaternion.identity);
    }

    public void CheackToUnlockCharacter(int score)
    {
        if (DataManager.GetData(TagManager.DATA_CHARACTER + "2") == 1) 
            return;

        if(score > char3UnlockScore)
        {
            DataManager.SaveData(TagManager.DATA_CHARACTER + "1", 1);
            DataManager.SaveData(TagManager.DATA_CHARACTER + "2", 1);
        }
        else if (score > char2UnlockScore)
        {
            DataManager.SaveData(TagManager.DATA_CHARACTER + "1", 1);
        }
    }
}
