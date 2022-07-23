using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace knowledge{


  public class Controller
  {
    // function for making the predicate to check if the alliance requirement is fullfilled by the dialogue
    bool npcAlliance(DialogueFrame df){
      return df.alliance <= NPCKnowledgebase.alliance;
    }
    bool multiplexerPredicate(DialogueFrame df){
      // write the boolean expression for the selection
      return false;
    }
    public DialogueFrame getRequiredDialogue(DialogueFrame df,int index,DialogueList dl){
      int[] def_cond_id = {};// Add the cond ids that are default
      bool contains = def_cond_id.Contains(df.cond_id);
      if (contains){// This is for the default case
        return df;
      }
      int[] alliance_cond_id_npc ={4}; // Add the cond ids for the dialogue that require alliance checking

      if (alliance_cond_id_npc.Contains(df.cond_id)){
        var alliancePredicate = new Predicate<DialogueFrame>(npcAlliance);
        df=dl.getdialogue(index,alliancePredicate);
        return df;
      }
      int[] alliance_cond_pc={};//Add the cond ids for dialogue that require alliance for pc
      if (alliance_cond_pc.Contains(df.cond_id)){
        var alliancePredicatePC = new Predicate<DialogueFrame>(npcAlliance);
        if (alliancePredicatePC(df)){
          return df;// return the same data if the dialogue fulfills the alliance requirements
        }
        else{
          //Create null dialogue DialogueFrame
          DialogueFrame nullDF = new DialogueFrame(-1,0,0,"null","null",0,0);
          return nullDF;
        }



      }
      DialogueFrame x= new DialogueFrame(-1,0,0,"null","null",0,0);
      return x;

    }



  }
}
