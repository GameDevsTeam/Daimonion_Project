using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class battleController : MonoBehaviour
{
    public bool playerTurn;
    public bool enemyTurn;

    [Header("GameObjects")]
    [SerializeField] Button [] playerButtons;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletBoard;
    /*[SerializeField] SpriteRenderer bulletBoard;*/
    

    heartController heartControlsScript;
    enemy enemyScript;


    // Start is called before the first frame update
    void Start()
    {
        // Access to player script
        if (GameObject.Find("Player") != null) // just to avoid null pointer exceptions
        {
            heartControlsScript = GameObject.Find("Player").GetComponent<heartController>();
        }
        // Access to enemy script
        if (GameObject.Find("Enemy") != null) // just to avoid null pointer exceptions
        {
            enemyScript = GameObject.Find("Enemy").GetComponent<enemy>();
        }
        // Select the fight button as default
        EventSystem.current.SetSelectedGameObject(GameObject.Find("FightButton"));

        // Set battle turn
        playerTurn = true;
        enemyTurn = false;

        // Battle intro text
        Text textBox = bulletBoard.GetComponentInChildren<Text>();
        textBox.text = enemyScript.enemyData.battleIntroText;
    }

    // Update is called once per frame
    void Update()
    {
        // Player turn
        if (playerTurn)
        {
            // Disable heart movements (script)
            heartControlsScript.enabled = false;
            // Enable buttons for interactions
            for (int i = 0; i<playerButtons.Length; i++)
            {
                playerButtons[i].enabled = true;
                playerButtons[i].GetComponent<buttonNavigation>().enabled = true;
            }
        }
        // Enemy or whatever turn
        else
        {
            // Enable heart movements (script)
            heartControlsScript.enabled = true;

            // Disable buttons for interactions
            for (int i = 0; i < playerButtons.Length; i++)
            {
                playerButtons[i].enabled = false;
                playerButtons[i].GetComponent<buttonNavigation>().enabled = false;
            }
            
        }

        // FOR TEST AND DEBUG !
        // If dialogue from enemy => Wait for playerTurn*
        if (Input.GetKey(KeyCode.P))
        {
            playerTurn = !playerTurn;
            enemyTurn = !enemyTurn;
        }
    }

    // Coroutine for dialogue before beginning fight ?

    // methods for each type of button
    public void fight()
    {
        playerTurn = false;
        enemyTurn = true;
        ExecuteTrigger("Battle");
        player.transform.position = Vector3.zero;
    }
    public void act()
    {
        
    }

    // Method to execute animation trigger
    private void ExecuteTrigger(string trigger)
    {
        var animator = bulletBoard.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger(trigger);
        }
    }

}

