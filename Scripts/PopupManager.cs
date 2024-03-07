using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    public CanvasGroup Cg;
    public TextMeshProUGUI text;
    public RectTransform textHolder;

    public Queue<string> PopupQueue = new Queue<string>();

    public float AnimationFadeTime = 0.5f;
    public float AnimationDisplayTime = 1.5f;

    private bool popupActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        AddToQueue("TOBY INCOMING!");
        AddToQueue("LOOK OUT!");
        AddToQueue("HE'S GAINING ON YOU!");
        AddToQueue("HE'S RIGHT BEHIND YOU!");
        AddToQueue("HE'S GONNA GET YOU!");
        AddToQueue("RUN!!!!");
    }

    public void AddToQueue(string val)
    {
        PopupQueue.Enqueue(val);
    }

    public void ExecuteQueue()
    {
        var value = PopupQueue.Dequeue();
        text.text = value;

        StartCoroutine(_ExecuteQueue());
    }

    private IEnumerator _ExecuteQueue()
    {
        popupActive = true;

        textHolder.anchoredPosition = new Vector2( - Screen.width, 0);

        LeanTween.alphaCanvas(Cg, 1, AnimationFadeTime);
        LeanTween.moveX(textHolder, 0, AnimationFadeTime);

        yield return new WaitForSeconds(AnimationDisplayTime);

        LeanTween.alphaCanvas(Cg, 0, AnimationFadeTime);
        LeanTween.moveX(textHolder, Screen.width, AnimationFadeTime);

        yield return new WaitForSeconds(AnimationFadeTime);

        popupActive = false;
    }

    public void Update()
    {
        if (popupActive || PopupQueue.Count <= 0)
        {
            return;
        }
        else
        {
            ExecuteQueue();
        }
    }
}
