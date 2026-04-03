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

        ShowLayout();
        UpdateArrows();
    }

    void FlipRight()
    {
        // show next pages
        if (currentIndex + 2 >= pages.Length - 1) return;
        currentIndex += 2;

        ShowLayout();
        UpdateArrows();
    }

    void FlipLeft()
    {
        // show previous pages
        if (currentIndex -2 < 0) return;
        currentIndex -= 2;

        ShowLayout();
        UpdateArrows();
    }

    void ShowLayout()
    {
        // shows current two page layout
        for (int i = 0; i < pages.Length; i++)
            pages[i].gameObject.SetActive(i == currentIndex || i == currentIndex + 1);
    }

    void UpdateArrows()
    {
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex + 2 < pages.Length;
    }
}
