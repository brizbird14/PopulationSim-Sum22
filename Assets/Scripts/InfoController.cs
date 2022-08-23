using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{

    /*
    The order and timing of things happening is fairly hard-coded
    based on how I think it looks best with the pop-up text
    */

    [SerializeField] string introMsg, controlMsg, guideMsg;
    public char[] intro, control, guide;
    [SerializeField] float betweenSentencePause, betweenLettersPause;
    Time startPrint, startPause;
    [SerializeField] bool infoStart;
    
    [SerializeField] GameObject darkOverlay, background;

    [SerializeField] TextMeshProUGUI infoText;

    IEnumerator printCoroutine;
    bool killPrint; // if true, stops print in coroutine

    // Sprites that are displayed with each slide
    [SerializeField] SpriteRenderer foxSprite, chickenSprite, mushroomSprite;
    [SerializeField] SpriteRenderer sunsliderSprite, pondbuttonSprite;
    [SerializeField] SpriteRenderer fkcSprite;

    void Start() {
        infoStart = false;
        killPrint = false;
        intro = new char[introMsg.Length];
        control = new char[controlMsg.Length];
        guide = new char[guideMsg.Length];

        intro = introMsg.ToCharArray();
        control = controlMsg.ToCharArray();
        guide = guideMsg.ToCharArray();
    }

    public void EnterInfoScreen() {
        printCoroutine = PrintMsg();
        // If already in info screen, clicking button again will exit
        if (infoStart == true) {
            ExitInfoScreen();
            return;
        }

        infoStart = true;
        killPrint = false;

        // Turn all the stuff on
        darkOverlay.SetActive(true);
        background.SetActive(true);
        StartCoroutine(printCoroutine);
    }

    public void ExitInfoScreen() {
        infoStart = false;
        killPrint = true;

        // turn off all sprites
        chickenSprite.enabled = false;
        foxSprite.enabled = false;
        mushroomSprite.enabled = false;
        sunsliderSprite.enabled = false;
        pondbuttonSprite.enabled = false;
        fkcSprite.enabled = false;

        StopCoroutine(printCoroutine);
        darkOverlay.SetActive(false);
        background.SetActive(false);
        infoText.text = "";
    }

    char[] tempArr;
    IEnumerator PrintMsg() {
        for (int iIntro = 0; iIntro < intro.Length; iIntro++) {
            if (killPrint) break;
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + intro[iIntro];
            switch (iIntro) {
                case 31:
                    chickenSprite.enabled = true;
                    break;
                case 41:
                    foxSprite.enabled = true;
                    break;
                case 52:
                    mushroomSprite.enabled = true;
                    break;
            }
        }
        if (killPrint) {
            infoText.text = "";
            yield break;
        }
        yield return new WaitForSeconds(betweenSentencePause);
        chickenSprite.enabled = false;
        foxSprite.enabled = false;
        mushroomSprite.enabled = false;
        infoText.text = "";

        for (int iControl = 0; iControl < control.Length; iControl++) {
            if (killPrint) break;
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + control[iControl];
            if (iControl == 3) {
                sunsliderSprite.enabled = true;
                pondbuttonSprite.enabled = true;
            }
        }
        if (killPrint) {
            infoText.text = "";
            yield break;
        }
        yield return new WaitForSeconds(betweenSentencePause);
        sunsliderSprite.enabled = false;
        pondbuttonSprite.enabled = false;
        infoText.text = "";
        
        for (int iGuide = 0; iGuide < guide.Length; iGuide++) {
            if (killPrint) break;
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + guide[iGuide];
            if (iGuide == 3) {
                fkcSprite.enabled = true;
            }
        }
        if (killPrint) {
            infoText.text = "";
            yield break;
        }
        yield return new WaitForSeconds(betweenSentencePause + 3.0f);
        fkcSprite.enabled = false;

        infoStart = false;
        ExitInfoScreen();
    }
}
