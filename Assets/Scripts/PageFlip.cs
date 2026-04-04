using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlip : MonoBehaviour
{
    public GameObject[] pages; // array for pages

    public Button rightButton;
    public Button leftButton;

    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        rightButton.onClick.AddListener(FlipRight); // flip right page
        leftButton.onClick.AddListener(FlipLeft); // flip left page

        for (int i = 0; i < pages.Length; i++)
            pages[i].gameObject.SetActive(i == 0);

        UpdateArrows();
    }

    void FlipRight()
    {
        // show next pages
        if (currentIndex >= pages.Length - 1) return;
        pages[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        pages[currentIndex].gameObject.SetActive(true);

        UpdateArrows();
    }

    void FlipLeft()
    {
        // show previous pages
        if (currentIndex <= 0) return;
        pages[currentIndex].gameObject.SetActive(false);
        currentIndex--;
        pages[currentIndex].gameObject.SetActive(true);

        UpdateArrows();
    }

    void UpdateArrows()
    {
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < pages.Length - 1;
    }
}
