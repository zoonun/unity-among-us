using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;

    // Setting
    private VisualElement _settingContainer;
    private Button _settingBtn;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        try
        {
            _doc = GetComponent<UIDocument>();
            _root = _doc.rootVisualElement;
            
            // Settings
            _settingContainer = _root.Q<VisualElement>("setting_container");
            _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(0, 0)));
            _settingBtn = _root.Q<Button>("btn__setting");
            _settingBtn.clicked += SettingClick;
            
        }
        catch (Exception e)
        {
            Debug.LogError(e + " " + e.Message);
        }
    }

    private void SettingClick()
    {
        _settingContainer.style.scale = new StyleScale(new Scale(new Vector2(1, 1)));
    } 
}
