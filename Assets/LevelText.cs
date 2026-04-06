using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EasyTextEffects;
using EasyTextEffects.Effects;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public string[] introPhrases =
    {
        "It is said that many many years ago, a rabbit became a companion of the moon.",
        "Once an inhabitant of the earth, the rabbit's kindness and selfishness was noticed by the skies and was granted eternal life among the stars.",
        "It can be seen to this day, living as a shadow across the moon's surface."
    };
    public string[] phrases = {
        "We're going on a trip in our favorite rocketship :DDD"
    }; // or whatever exposition phrases we wanna use
    public TextEffect textEffect;
    public GameObject player;
    public Effect_Color typewriter;
    private int currPhrase;
    private bool isTalking = false;
    private string[] whichPhrases;

    // Start is called before the first frame update
    void Start()
    {
        levelText = this.GetComponent<TextMeshProUGUI>();
        currPhrase = -1;
        textEffect.StartManualEffect("typewriter");
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "intro-to-level":
                whichPhrases = introPhrases;
                break;
            case "level 1":
                whichPhrases = phrases;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Continue();
        }
    }

    public void UpdateTalking()
    {
        Debug.Log("ran");
        textEffect.StopManualEffects();
        levelText.ForceMeshUpdate();
        isTalking = false;
    }

    public void FinishedSentence()
    {
        isTalking = false;
    }

    public void Continue()
    {
        if(!isTalking){
            currPhrase++;
            isTalking = true;
            if (currPhrase > whichPhrases.Length - 1)
            {
                if(player){
                    player.GetComponent<PlayerMovementIsometric>().enabled = true;
                }
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "intro-to-level")
                {
                    FindFirstObjectByType<SceneManager>().StoryBook(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }
                else
                {
                    levelText.gameObject.SetActive(false);
                    levelText.text = "";
                }
            }else{
                levelText.text = whichPhrases[currPhrase];
                if(player){
                    player.GetComponent<PlayerMovementIsometric>().enabled = false;
                }
                textEffect.Refresh();
                textEffect.StartManualEffect("typewriter");
            }
        }
        else
        {
            UpdateTalking();
        }
    }
}
