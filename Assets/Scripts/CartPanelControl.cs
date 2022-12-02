using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class CartPanelControl : MonoBehaviour
{
    private UIControl uiControl;
    private int contCarts;
    public CartControl[] carts;

    private void Awake()
    {
        contCarts = 0;
        uiControl = GetComponentInParent<UIControl>();
    }


    /*
    public void SetNewSprite(int ind, Sprite spite)
    {
        carts[ind].SetNewImage(spite);
        carts[ind].OpenCartShow();
    }
    */

    /*
    public async UniTask OlpenAllCart()
    {
        foreach (var cc in carts)
        {
            await cc.OpenCartShow();
        }
    }


    public async UniTask CloseAllCart(float dd) 
    {
        foreach (var cc in carts) 
        { 
            await cc.CloseCartShow(dd);
        }
    }
    */
    /*
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
        //for (int i = 0; i < carts.Length; i++)
        //{
        //    carts[i].CloseCartShow();
        //}
    }

    public void UnLockUIButtons()
    {
        contCarts++;
        if (contCarts >= carts.Length) {
            contCarts = 0;
            uiControl.UnLockButtons();
        }
    }


    private void OnCancelImage()
    {

    }

    */

}
