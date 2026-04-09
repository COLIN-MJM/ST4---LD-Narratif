using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

[Serializable]
public struct VoiceLines
{
    [SerializeField]public string mainText;
    [SerializeField]public string talkerText;
    [SerializeField]public string choice1Text;
    [SerializeField]public string choice2Text;
    [SerializeField]public AudioClip voice;
    [SerializeField] public Vector3 talkerPos;
    [SerializeField]public Vector3 mainPos;
    [SerializeField]public Vector3 choice1Pos;
    [SerializeField]public Vector3 choice2Pos;
    public bool haveAChoice1;
    public bool haveAChoice2;
    public bool haveAChoice3;
    public bool haveAChoice4;
}
public class PlayerTalk : MonoBehaviour
{
    [SerializeField] private VoiceLines[] allVoiceLines = new VoiceLines[] { };
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI talkerName;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI choiceText1;
    [SerializeField] private TextMeshProUGUI choiceText2;
    [SerializeField] private AudioSource playerVoice;

    [HideInInspector]public NpcTalk currentNpc;
    [HideInInspector] public bool isInConversation=false;

    public float conversatioCutOff=1;
    
    private bool canAChoice1;
    private bool canAChoice2;
    private bool canAChoice3;
    private bool canAChoice4;


    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if(currentNpc is  null) return;
        if (Vector3.Distance(transform.position, currentNpc.transform.position) >= conversatioCutOff)
        {
            EndCoversation();
        }

        if(currentNpc is null) return;
        int choice = ChooseDialogOption();
        if (choice != -1)
        {
            PlayDialogue(currentNpc.TalkTo(choice),currentNpc.thisNpcVoice);
        }
        
    }

    public void StartConversation(NpcTalk npcTalk)
    {
        currentNpc = npcTalk;
        isInConversation = true;
        PlayDialogue(npcTalk.TalkTo(),npcTalk.thisNpcVoice);
    }

    public void EndCoversation()
    {
       
        dialogueBox.SetActive(false);
        isInConversation = false;
    }

    public void PlayDialogue(int index, AudioSource voice = null)
    {
       
        if (index == -1)
        {
            EndCoversation();
            return;
        }
        voice ??= playerVoice;

        VoiceLines voiceLineToPlay = allVoiceLines[index];
        
        voice.PlayOneShot(voiceLineToPlay.voice);
        dialogueBox.SetActive(true);
        
        talkerName.rectTransform.anchoredPosition3D = voiceLineToPlay.talkerPos;
        mainText.rectTransform.anchoredPosition3D = voiceLineToPlay.mainPos;
        choiceText1.rectTransform.anchoredPosition3D = voiceLineToPlay.choice1Pos;
        choiceText2.rectTransform.anchoredPosition3D = voiceLineToPlay.choice2Pos;

        talkerName.text = voiceLineToPlay.talkerText;
        mainText.text = voiceLineToPlay.mainText;
        choiceText1.text = voiceLineToPlay.choice1Text;
        choiceText2.text = voiceLineToPlay.choice2Text;

        canAChoice1 = voiceLineToPlay.haveAChoice1;
        canAChoice2 = voiceLineToPlay.haveAChoice2;
        canAChoice3 = voiceLineToPlay.haveAChoice3;
        canAChoice4 = voiceLineToPlay.haveAChoice4;
    }

    public int ChooseDialogOption()
    {
        if      (canAChoice1 && Input.GetKeyDown(KeyCode.O)) return 1;
        else if (canAChoice2 && Input.GetKeyDown(KeyCode.P)) return 2;
        else if (canAChoice3 && Input.GetKeyDown(KeyCode.L)) return 3;
        else if (canAChoice4 && Input.GetKeyDown(KeyCode.M)) return 4;
        else if ( Input.GetKeyDown(KeyCode.E)) return 0;

        return -1;
    }
}
