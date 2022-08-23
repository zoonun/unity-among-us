using System;
using UnityEngine;
using UnityEngine.UIElements;

public class OnlineManager : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;

    private Button _backBtn;
    
    [SerializeField]
    private GameObject _menuObj;
    [SerializeField]
    private GameObject _onlineObj;

    private void OnEnable()
    {
        try
        {
            _doc = GetComponent<UIDocument>();
            _root = _doc.rootVisualElement;

            _backBtn = _root.Q<Button>("btn__back");
            _backBtn.clicked += OnClickBack;
        }
        catch (Exception e)
        {
            Debug.LogError(e + " " + e.Message);
        }
    }

    private void OnClickBack()
    {
        if (_menuObj != null && _onlineObj != null)
        {
            _menuObj.SetActive(true);
            _onlineObj.SetActive(false);
        }
    }
}