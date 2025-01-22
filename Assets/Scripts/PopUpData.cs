using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PopUpData
{
    [TextArea(1,5)]public List<string> messages = new List<string>();    
    public List<UnityEvent> unityEvents = new List<UnityEvent>();
    public List<Sprite> sprites = new List<Sprite>();//No se muestran por el momento
}
