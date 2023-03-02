using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField] private Button[] characterSelectButton;
    [SerializeField] private GameObject[] selecteCharacterCheackbox;

    public void InitializeCharacterMenu()
    {
        for(int i = 0; i < characterSelectButton.Length; i++)
        {
            int charData = DataManager.GetData(TagManager.DATA_CHARACTER + i.ToString());

            if(charData == 0)
            {
                characterSelectButton[i].interactable = false;
            }

            selecteCharacterCheackbox[i].SetActive(false);   
        }

        selecteCharacterCheackbox[DataManager.GetData(TagManager.DATA_SELECTED_CHARACTER)].SetActive(true);
    }
}
