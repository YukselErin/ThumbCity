using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "DialogueCreator")]

public class DialogueCreator : ScriptableObject
{


    [Serializable]
    public class Entry
    {
        public string text = "Watch where you are going bitch!";
        public string[] predicates = new string[] { };
        public string[] prohibates = new string[] { "diag2" };
        public string[] setsPredicates = new string[] { "diag1" };
        public string[] setsProhibates = new string[] { };
    }


    [Serializable]
    public class Response
    {
        public string text = "Watch where you are going nigga!";
        public string[] predicates = new string[] { "officerBlack" };
        public string[] prohibates = new string[] { "diag2" };
        public string[] setsPredicates = new string[] { "diag1" };
        public string[] setsProhibates = new string[] { };
    }

    [SerializeField] public Entry[] entries;
    [SerializeField] public Response[] responses;
}
