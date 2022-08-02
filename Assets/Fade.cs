using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    [SerializeField] public Image image;

    [Header("Fade In")]
    [SerializeField] public float hold;
    [SerializeField] public float targetTime = 1;
    [SerializeField] float target;

    [Header("Ping Pong")]
    [SerializeField] float pingpongTime;
    [SerializeField] float pingpongTarget;

    bool fadeIn = false;
    bool fadeOut = false;
    bool pingpong = false;

    bool fadeInOut = false;

    float timeLerped;

    private void Update()
    {
        timeLerped += Time.deltaTime;
        if (fadeIn)
        {
            Color32 colour = image.color;
            colour.a = (byte)Mathf.Lerp(colour.a, target, timeLerped / targetTime);
            image.color = colour;

            /*if (colour.a == 255 && fadeInOut)
            {
                FadeOut();
                fadeInOut = false;
            }*/
        }
        else if (fadeOut)
        {
            Color32 colour = image.color;
            colour.a = (byte)Mathf.Lerp(colour.a, 0, timeLerped / targetTime);
            image.color = colour;
        }
        else if (pingpong)
        {
            Color32 colour = image.color;
            colour.a = (byte)Mathf.PingPong(Time.time * pingpongTime, pingpongTarget);
            image.color = colour;
        }
    }

    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
        pingpong = false;
        timeLerped = 0;
    }

    public void FadeIn()
    {
        fadeIn = true;
        pingpong = false;
        fadeOut = false; timeLerped = 0;
    }

    public void FadeInOut()
    {
        StartCoroutine(_FadeInOut());
    }

    IEnumerator _FadeInOut()
    {
        FadeIn();
        yield return new WaitForSeconds(hold);

        //fadeInOut = true;
        FadeOut();
    }

    public void PingPong()
    {
        fadeIn = false;
        pingpong = true;
        fadeOut = false;
    }
}
