using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Action<int> OnLoadButton;
    public Action OnCancelButton;

    [SerializeField]
    private TMP_Dropdown switchOperations;
    [SerializeField]
    private Button loadButton;
    [SerializeField]
    private Button cancelButton;

    //public CartControl[] carts;
    public CartPanelControl cartPanel;

    private int cartCount = 0;

    public void UnLockButtons() 
    {
     //   cartCount++;
     //   if (cartCount >= carts.Length) {
     //       cartCount = 0;
     //       switchOperations.interactable = true;
     //       loadButton.interactable = true;
     //   }
    }


    private void OnEnable()
    {
        loadButton.onClick.AddListener(() => OnButtonLoadNew());
        cancelButton.onClick.AddListener(() => OnButtonCancelNew());
    }

    private void OnDisable()
    {
        loadButton.onClick.RemoveListener(OnButtonLoadNew);
        cancelButton.onClick.RemoveListener(OnButtonCancelNew);
    }

    private void OnButtonLoadNew()
    {
        OnLoadButton?.Invoke(switchOperations.value);
        switchOperations.interactable = false;
        loadButton.interactable = false;
    }

    private void OnButtonCancelNew()
    {
        OnCancelButton?.Invoke();
    }



}
