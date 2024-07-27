using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Localization;
[CreateAssetMenu(menuName = "DialogueTree")]
public class DialogueTree : ScriptableObject
{


    [Serializable]
    public class DialogueResponse
    {
        public int index;
        public bool waitPlayerResponse;
        public int[] playerResponses;
        public LocalizedString text;
        public int nextResponse;
        public bool autoNext;
        public string[][] nextResponsePredicates;
        public int[] nextResponseOutcomes;
    }
    [SerializeField] public DialogueResponse[] dialogueResponses;
}
