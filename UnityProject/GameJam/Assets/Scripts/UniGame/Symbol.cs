using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Symbol : MonoBehaviour
{
    //    Tiny canvas with a single symbol inside.    Will be instantiated elsewhere.
    //    Will have collision, so when the mouse hovers over the symbol, it's color will change, and it will be 'marked'
    //    Will positioning work with the instantiating?
    
    public Text symbolText;
    
    public string symbol;

    public Vector2 symbolPosition;
    
    void Start()
    {
        
    }

    public void SetSymbol(string sym)
    {
        symbolText.GetComponent<UnityEngine.UI.Text>().text = sym;
    }

    void Update()
    {
        //symbolText.GetComponent<UnityEngine.UI.Text>().text = symbol;
        this.transform.position = symbolPosition;
        //RectTransform = symbolPosition;
        Debug.Log(symbolPosition.x + ", " + symbolPosition.y);
        Debug.Log(transform.position.x + ", " + transform.position.y);
    }
}
