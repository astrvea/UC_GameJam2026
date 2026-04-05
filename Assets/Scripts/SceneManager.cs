using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(LoadGameScene("intro"));
    }

    public void StoryBook(string name)
    {
        if (name == "intro")
        {
            StartCoroutine(LoadGameScene("level 1"));
        }else if (name == "epilogue")
        {
            StartCoroutine(LoadGameScene("credits"));
        }
    }

    public void LoadEpilogue()
    {
        StartCoroutine(LoadGameScene("epilogue"));
    }

    private IEnumerator LoadGameScene(string sceneIndex)
    {
        GameObject blackScreen = GameObject.FindWithTag("Fade");
        blackScreen.gameObject.transform.parent.GetComponent<Canvas>().sortingOrder = 100;
        Color screenColor = blackScreen.GetComponent<Image>().color;
        while (screenColor.a < 1)
        {
            screenColor.a += Time.deltaTime;
            blackScreen.GetComponent<Image>().color = screenColor;
            yield return null;
        }
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        blackScreen.gameObject.transform.parent.GetComponent<Canvas>().sortingOrder = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
