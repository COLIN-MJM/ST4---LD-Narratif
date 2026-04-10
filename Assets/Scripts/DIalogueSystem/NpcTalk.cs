using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;


public class NpcTalk : MonoBehaviour
{
    [HideInInspector]public AudioSource thisNpcVoice;
    public SerializedDictionary<List<int>, int> dialogueTree = new SerializedDictionary<List<int>, int>(new CustomComparator());
  
    public List<int> curentDialogKey = new List<int>();

    protected virtual void Start()
    {
        thisNpcVoice=GetComponent<AudioSource>();
    }

    public virtual int TalkTo(int choice=0)
    {
        List<int> key;
        if (choice!=0 )
        {
            curentDialogKey.Add(choice);
            curentDialogKey[0] = 0;
            key= dialogueTree.Keys.ToList().Find(x => x.SequenceEqual(curentDialogKey));
            if (key is null||!dialogueTree.ContainsKey(key)) return -1;
            return dialogueTree[key];
        }
        curentDialogKey[0]+=1;
         key = dialogueTree.Keys.ToList().Find(x => x.SequenceEqual(curentDialogKey));
        if (key is null||!dialogueTree.ContainsKey(key)) return -1;
        return dialogueTree[key];
    }
}
class CustomComparator : IEqualityComparer<List<int>>
{
    public bool Equals(List<int> x, List<int> y)
    {
        return y != null && x != null && x.SequenceEqual(y) ;
    }

    public int GetHashCode(List<int> obj)
    {
        return obj.GetHashCode();
    }
}

