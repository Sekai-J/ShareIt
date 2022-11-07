using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public class GameManager : NetworkBehaviour
{
    //Level1
    public bool purpleButton = false;
    public bool blueButton = false;
    public bool redButton = false;
    public GameObject buttonsDoor;
    public float buttonsDoorSpeed = 4f;

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if(redButton && blueButton && purpleButton)
        {
            OpenButtonsDoor();
        }
    }

    public void RedButtonPressed()
    {
        redButton = true;
        StartCoroutine(ResetButtons());
        Debug.Log("RedButtonPressedGM");
    }

    public void BlueButtonPressed()
    {
        blueButton = true;
        StartCoroutine(ResetButtons());
        Debug.Log("BlueButtonPressedGM");
    }

    public void PurpleButtonPressed()
    {
        purpleButton = true;
        StartCoroutine(ResetButtons());
        Debug.Log("PurpleButtonPressedGM");
    }

    public void YellowButtonPressed()
    {
        redButton = false;
        blueButton = false;        
    }

    public void OpenButtonsDoor()
    {
        buttonsDoor.transform.Translate(new Vector3(0, 5, 0) * 4 * Time.deltaTime);
    }

    private IEnumerator ResetButtons()
    {
        yield return new WaitForSeconds(5);
        redButton = false;
        blueButton = false;
        purpleButton = false;

        Debug.Log("ButtonsReset");
    }
}
