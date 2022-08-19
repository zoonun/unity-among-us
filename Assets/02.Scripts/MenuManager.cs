using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;
    // Start is called before the first frame update
    void OnEnable()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;

        Button btn = new Button();
        btn.text = "Banana";
        _root.Add(btn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
