using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtonsChangeAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject[] Buttons;
    int RandomNum;
    GameObject CurrentWorkingButton;
    bool isReady = false;

    private void Start()
    {
        RandomNum = Random.Range(0, 3);
        for (int i = 0; i < Buttons.Length; i++)
            if (Buttons[i].activeInHierarchy) CurrentWorkingButton = Buttons[i];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(StartChangeButtonAnimation());
    }

    IEnumerator StartChangeButtonAnimation()
    {
        for (int i = 0; i < Buttons.Length; i++)
            if (Buttons[i].activeInHierarchy) CurrentWorkingButton = Buttons[i];

        while(true)
        {
            if (isReady)
                break;
            RandomNum = Random.Range(0, 3);
            Debug.Log(RandomNum);
            Buttons[RandomNum].SetActive(true);
            CurrentWorkingButton.SetActive(false);
            CurrentWorkingButton = Buttons[RandomNum];
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
