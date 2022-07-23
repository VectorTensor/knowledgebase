using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using knowledge;
using System;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    bool canDoQuest(DialogueFrame df){
      return true ;//alliance  >= df.alliance;
    }

    bool inSlub(DialogueFrame df){
      return false;
    }

    void Start()
    {
      PlayerKB.go_to_place = "club";
      NPCKnowledgebase.alliance = 2;
    //  Debug.Log(PlayerKB.go_to_place);
      Parser parser = new Parser();
      DialogueList dl = parser.beginParse("Assets/Dialouge/quest1.txt",2);
      Controller controller = new Controller();
      DialogueFrame sample = dl.dialogueframes[1];
      DialogueFrame df = controller.getRequiredDialogue(sample,1,dl);// dialogue of scene 2 which dialogue has the required alliance is returned
      Debug.Log(df.dialogue);




    }

    // Update is called once per frame
    void Update()
    {

    }
}
