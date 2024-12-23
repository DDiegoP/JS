using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDisplayManager : MonoBehaviour
{
    private ResponseGroup responses;

    [SerializeField]
    private ResponseController twoResponses;
    [SerializeField]
    private ResponseController threeResponses;
    [SerializeField]
    private ResponseController fourResponses;
    [SerializeField]
    private ResponseController emotionsResponses;

    void ActivateTwoResponses() {
        twoResponses.gameObject.SetActive(true);
        twoResponses.SetResponses(responses);
    }
    void ActivateThreeResponses() {
        threeResponses.gameObject.SetActive(true);
        threeResponses.SetResponses(responses);
    }
    void ActivateFourResponses() {
        fourResponses.gameObject.SetActive(true);
        fourResponses.SetResponses(responses);
    }

    private void ActivateEmotionsResponses() {
        emotionsResponses.gameObject.SetActive(true);
        emotionsResponses.SetResponses(responses);
    }

    public void SetResponses(ResponseGroup responseGroup, bool emotions) {
        responses = responseGroup;
        if (emotions) {
            ActivateEmotionsResponses();
            return;
        }

        switch (responseGroup.responses.Length) {
            case 2:
                ActivateTwoResponses();
                break;
            case 3:
                ActivateThreeResponses();
                break;
            case 4:
                ActivateFourResponses();
                break;
        }
    }

    public void HideResponses() {
        twoResponses.gameObject.SetActive(false);
        threeResponses.gameObject.SetActive(false);
        fourResponses.gameObject.SetActive(false);
        emotionsResponses.gameObject.SetActive(false);
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
