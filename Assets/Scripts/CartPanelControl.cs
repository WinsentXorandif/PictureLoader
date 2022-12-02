using UnityEngine;

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

    public void UnLockUIButtons()
    {
        contCarts++;
        if (contCarts >= carts.Length)
        {
            contCarts = 0;
            uiControl.UnLockButtons();
        }
    }
}
