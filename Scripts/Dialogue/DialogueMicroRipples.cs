using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
[CreateAssetMenu(menuName = "DialogueMicroRipples")]

public class DialogueMicroRipples : ScriptableObject
{
    public LocalizedString[] text;
    public string[][] predicates;
    public string[][] prohibates;

}
