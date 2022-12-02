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

    public CartPanelControl cartPanel;

    public void UnLockButtons() 
    {
       switchOperations.interactable = true;
       loadButton.interactable = true;
    }

    private void LockButtons() 
    {
        switchOperations.interactable = false;
        loadButton.interactable = false;
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
        LockButtons();
    }

    private void OnButtonCancelNew()
    {
        OnCancelButton?.Invoke();
        UnLockButtons();
    }



}
