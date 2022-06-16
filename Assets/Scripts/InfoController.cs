using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoController : MonoBehaviour
{
    [SerializeField] string introMsg, controlMsg, guideMsg;
    public char[] intro, control, guide;
    [SerializeField] float betweenSentencePause, betweenLettersPause;
    Time startPrint, startPause;
    bool infoStart;
    
    [SerializeField] GameObject darkOverlay, background;

    [SerializeField] TextMeshProUGUI infoText;

    void Start() {
        infoStart = false;
        intro = new char[introMsg.Length];
        control = new char[controlMsg.Length];
        guide = new char[guideMsg.Length];

        intro = introMsg.ToCharArray();
        control = controlMsg.ToCharArray();
        guide = guideMsg.ToCharArray();
    }

    public void EnterInfoScreen() {
        infoStart = true;

        // Turn all the stuff on
        darkOverlay.SetActive(true);
        background.SetActive(true);
        StartCoroutine(PrintMsg());
    }

    char[] tempArr;
    IEnumerator PrintMsg() {
        /**switch(msgNum) {
            case 1: // INTRO
                tempArr = intro;
                break;
            case 2: // CONTROLS
                tempArr = control;
                break;
            case 3: // GUIDE
                tempArr = guide;
                break;
        }

        for (int i = 0; i < tempArr.Length; i++) {
            StartCoroutine(WaitLetters());
            infoText.text = infoText.text + tempArr[i];
        }

        if (msgNum == 1) {
            StartCoroutine(PrintMsg(2));
            yield return new WaitForSeconds(betweenSentencePause);
        } else if (msgNum == 2) {
            StartCoroutine(PrintMsg(3));
            yield return new WaitForSeconds(betweenSentencePause);
        } else {
            infoStart = false;
            yield return new WaitForSeconds(0.0f);
        }*/

        for (int iIntro = 0; iIntro < intro.Length; iIntro++) {
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + intro[iIntro];
        }
        yield return new WaitForSeconds(betweenSentencePause);
        infoText.text = "";

        for (int iControl = 0; iControl < control.Length; iControl++) {
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + control[iControl];
        }
        yield return new WaitForSeconds(betweenSentencePause);
        infoText.text = "";
        
        for (int iGuide = 0; iGuide < guide.Length; iGuide++) {
            yield return new WaitForSeconds(betweenLettersPause);
            infoText.text = infoText.text + guide[iGuide];
        }
        infoStart = false;
    }
}
