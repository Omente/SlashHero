using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject characterSelectionPanel;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private CharacterSelectMenu characterSelectMenu;

    private void Start()
    {
        characterSelectMenu = gameObject.GetComponent<CharacterSelectMenu>();
        highscoreText.text = $"Highscore: {DataManager.GetData(TagManager.DATA_HIGHSCORE)}M";
    }

    public void OpenCloseCharacterPanel(bool open)
    {
        if(open)
            characterSelectMenu.InitializeCharacterMenu();

        characterSelectionPanel.SetActive(open);
    }

    public void SelectCharacter()
    {
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameplayController.instance.SelectedCharacter = selectedCharacter;
        
        DataManager.SaveData(TagManager.DATA_SELECTED_CHARACTER, selectedCharacter);
        characterSelectMenu.InitializeCharacterMenu();
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.SCENE_NAME_GAMEPLAY);
    }
}
