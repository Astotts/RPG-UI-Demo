using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject actionCanvas;
    [SerializeField] GameObject enemyCanvas;
    [SerializeField] GameObject itemCanvas;
    [SerializeField] private Character[] characters;
    [SerializeField] private Character[] enemies;
    [SerializeField] private UnityEngine.UI.Button[] characterButtons;
    [SerializeField] private Sprite[] images;
    [SerializeField] private UnityEngine.UI.Image itemRenderer;
    int character, itemID;
    public void CharacterSelected(int characterIndex){
        actionCanvas.SetActive(true);
        character = characterIndex;
    }

    public void ActionSelected(int actionIndex){
        switch(actionIndex){
            case 0: 
                //Attack
                enemyCanvas.SetActive(true);
                itemCanvas.SetActive(false);
            break;
            case 1: 
                //Items
                itemCanvas.SetActive(true);
                enemyCanvas.SetActive(false);
            break;
            case 2: 
                //Flee
                itemCanvas.SetActive(false);
                enemyCanvas.SetActive(false);
                actionCanvas.SetActive(false);
            break;
        }
    }

    public void EnemySelected(int index){
        characterButtons[character].interactable = false;
        characters[character].Attack(enemies[index]);
        itemCanvas.SetActive(false);
        actionCanvas.SetActive(false);
        enemyCanvas.SetActive(false);
        if(!characterButtons[0].interactable && !characterButtons[1].interactable && !characterButtons[2].interactable){
            characterButtons[0].interactable = true;
            characterButtons[1].interactable = true;
            characterButtons[2].interactable = true;
        }
    }

    public void NextItem(int move){
        itemID += move;
        itemID = Mathf.Clamp(itemID, 0, 4);
        itemRenderer.sprite = images[itemID];
    }

    public void ChoseItem(){
        //Give Status Effect
        characterButtons[character].interactable = false;
        characters[character].Effect(images[itemID]);
        itemCanvas.SetActive(false);
        actionCanvas.SetActive(false);
        enemyCanvas.SetActive(false);
        if(!characterButtons[0].interactable && !characterButtons[1].interactable && !characterButtons[2].interactable){
            characterButtons[0].interactable = true;
            characterButtons[1].interactable = true;
            characterButtons[2].interactable = true;
        }
    }
}
