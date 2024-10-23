using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButtons : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject[] howToPlayPanels;

    public void HowToPlayButton()
    {
        MainPanel.SetActive(false);
        howToPlayPanels[0].SetActive(true);
    }
    public void CloseHowToPlay()
    {
        ClosePanels();
        MainPanel.SetActive(true);
        
    }
    public void FirstPage()
    {
        ClosePanels();
        howToPlayPanels[0].SetActive(true);
    }
    public void SecondPage()
    {
        ClosePanels();
        howToPlayPanels[1].SetActive(true);
    }

    public void ThirdPage()
    {
        ClosePanels();
        howToPlayPanels[2].SetActive(true);

    }
    public void ClosePanels()
    {
        foreach (GameObject panel in howToPlayPanels)
        {
            panel.SetActive(false);
        }
    }

}
