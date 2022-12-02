using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPanelControl : MonoBehaviour
{
    private UIControl uiControl;

    public CartControl[] carts;


    private void Awake()
    {
        uiControl = GetComponentInParent<UIControl>();
    }


    private void OnEnable()
    {
        uiControl.OnLoadButton += OnLoadImage;
        uiControl.OnCancelButton += OnCancelImage;
    }

    private void OnDisable()
    {
        uiControl.OnLoadButton -= OnLoadImage;
        uiControl.OnCancelButton -= OnCancelImage;
    }

    private void OnLoadImage(int mod)
    {
        Debug.Log("OnLoadImage(int mod)");

        //CloseCartShow();
    }

    private void OnCancelImage()
    {

    }



}
