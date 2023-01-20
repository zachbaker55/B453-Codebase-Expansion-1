using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MooseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action MouseAction;
    public Action OverAction;
    public Action OutAction;
    public Action DownAction;
    public Action UpAction;
    public AudioClip MouseOverClip;
    public AudioClip MouseClickClip;
    public AudioSource buttonSource;

    // Start is called before the first frame update
    void Start()
    {
        //MouseOverClip = Resources.Load<AudioClip>("Sounds/MouseOver");
        //MouseClickClip = Resources.Load<AudioClip>("Sounds/MouseClick");
        if (buttonSource == null)
        {
            buttonSource = this.gameObject.AddComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("MouseDown");
        if (MouseClickClip != null)
        {
            buttonSource.clip = MouseClickClip;
            buttonSource.Play();
        }
        if (DownAction != null)
        {
            DownAction();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Pointerdown");
        if (MouseClickClip != null)
        {
            buttonSource.clip = MouseClickClip;
            buttonSource.Play();
        }
        if (DownAction != null)
        {
            DownAction();
        }
    }

    void OnMouseExit()
    {
        //Debug.Log("MouseExit");
        if (OutAction != null)
        {
            OutAction();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("PointerExit");
        if (OutAction != null)
        {
            OutAction();
        }
    }

    void OnMouseUp()
    {
        //Debug.Log("mouseUP");
        if (MouseAction != null)
        {
            MouseAction();
        }
        if (UpAction != null)
        {
            UpAction();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("PointerUp");
        if (MouseAction != null)
        {
            MouseAction();
        }
        if (UpAction != null)
        {
            UpAction();
        }
    }
    void OnMouseEnter()
    {
        //Debug.Log("MouseEnter");
        if (MouseOverClip != null)
        {
            buttonSource.clip = MouseOverClip;
            buttonSource.Play();
        }
        if (OverAction != null)
        {
            OverAction();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("PointerEnter");
        if (MouseOverClip != null)
        {
            buttonSource.clip = MouseOverClip;
            buttonSource.Play();
        }
        if (OverAction != null)
        {
            OverAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
