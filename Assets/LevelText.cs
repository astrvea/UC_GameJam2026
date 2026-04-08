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
        "I want to help this rabbit go to the moon... so that I could go too...",
        "But to do that I need to build a rocket!",
        "I can find three things in my room to make our dreams come true.",
        "The moon is but a hop away!"
    };
    public string[] phrases = {
        "It is said that many many years ago, a rabbit had a hungry fluffy companion on the moon.",
        "Once an inhabitant of the earth, the rabbit was guided by a light source so it could find its way.",
        "The rabbit saw visions of a natural phenomenon, one that shot fire into the sky, so bright that it could be stars!"
    }; // or whatever exposition phrases we wanna use
    public TextEffect textEffect;
    public Effect_Color typewriter;
    [SerializeField] private int currPhrase;
    private bool isTalking = false;
    private string[] whichPhrases;

    // Start is called before the first frame update
    void Start()
    {
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
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "level 1"){
            levelText.gameObject.SetActive(false);
            levelText.text = "";
        }
    }

    public void FinishedSentence()
    {
        isTalking = false;
    }

    public void Continue()
    {
        levelText.gameObject.SetActive(true);
        if(!isTalking){
            currPhrase++;
            isTalking = true;
            if (currPhrase > whichPhrases.Length - 1)
            {
                isTalking = false;
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "intro-to-level")
                {
                    FindFirstObjectByType<SceneManager>().StoryBook(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                }
                else
                {
                    currPhrase = 0;
                    levelText.text = whichPhrases[currPhrase];
                    textEffect.Refresh();
                    textEffect.StartManualEffect("typewriter");
                    isTalking = true;
                }
            }else{
                levelText.text = whichPhrases[currPhrase];
                textEffect.Refresh();
                textEffect.StartManualEffect("typewriter");
            }
        }
        else
        {
            textEffect.StopManualEffects();
            levelText.text = whichPhrases[currPhrase];
            levelText.ForceMeshUpdate();
            isTalking = false;
        }
    }
}
