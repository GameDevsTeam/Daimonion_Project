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


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player") != null) // just to avoid null pointer exceptions
        {
            heartControlsScript = GameObject.Find("Player").GetComponent<heartController>();
        }

        EventSystem.current.SetSelectedGameObject(GameObject.Find("FightButton"));

        playerTurn = true;
        enemyTurn = false;

        /*player.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn)
        {
            // Disable heart movements (script)
            heartControlsScript.enabled = false;
            // Enable buttons for interactions
            for (int i = 0; i<playerButtons.Length; i++)
            {
                playerButtons[i].enabled = true;
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
            }
        }
        // If dialogue from enemy => Wait for playerTurn*

        if (Input.GetKey(KeyCode.P))
        {
            playerTurn = !playerTurn;
            enemyTurn = !enemyTurn;
        }
    }

    // Coroutine for dialogue before beginning fight
    public void fight()
    {
        ExecuteTrigger("Interactions");
    }
    public void act()
    {
        ExecuteTrigger("Interactions");
    }

    private void ExecuteTrigger(string trigger)
    {
        var animator = bulletBoard.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger(trigger);
        }
    }
}

