using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class EmojiHandler : NetworkBehaviour
{
    public bool isEmojiActive = false;

    public GameObject emojiYes;
    public GameObject emojiNo;
    public GameObject emojiHappy;
    public GameObject emojiSad;
    public GameObject emojiIdea;
    public GameObject emojiAngry;

    public override void FixedUpdateNetwork()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isEmojiActive)
                return;

            emojiYes.SetActive(true);
            StartCoroutine(emojiReset());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isEmojiActive)
                return;

            emojiNo.SetActive(true);
            StartCoroutine(emojiReset());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (isEmojiActive)
                return;

            emojiHappy.SetActive(true);
            StartCoroutine(emojiReset());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (isEmojiActive)
                return;

            emojiSad.SetActive(true);
            StartCoroutine(emojiReset());
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (isEmojiActive)
                return;

            emojiIdea.SetActive(true);
            StartCoroutine(emojiReset());
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (isEmojiActive)
                return;

            emojiAngry.SetActive(true);
            StartCoroutine(emojiReset());
        }

    }

    IEnumerator emojiReset()
    {
        isEmojiActive = true;

        yield return new WaitForSeconds(3);

        emojiYes.SetActive(false);
        emojiSad.SetActive(false);
        emojiNo.SetActive(false);
        emojiIdea.SetActive(false);
        emojiHappy.SetActive(false);
        emojiAngry.SetActive(false);

        isEmojiActive = false;
    }
}
