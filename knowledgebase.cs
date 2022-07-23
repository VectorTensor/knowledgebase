using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
namespace knowledge {
// Player knowledgebase effected by the player choices
  public class PlayerKB{
    public static string go_to_place;

  }

  public class NPCKnowledgebase{
    public static int alliance;


  }

  public class DialogueFrame{
    public int scene;// -1
    public int sequence;
    public int id;
    public string dialogue;
    public string character;
    public int cond_id;
    public int  alliance;
    public DialogueFrame(){

    }
    public DialogueFrame(int s, int sq, int i, string d, string c, int c_i, int al ){
      scene = s;
      sequence = sq;
      id = i;
      dialogue = d;
      character = c;
      cond_id = c_i;
      alliance = al; // 1 -> enemy 4-> Friend
    }
  }

  public class DialogueList{
    public List<DialogueFrame> dialogueframes  = new List<DialogueFrame>();
    public void adddialogue(DialogueFrame d){
      // This function adds the dialogue frame to the dialogue list using the basic list add method
      dialogueframes.Add(d);
    }
    // parameters index and prdicate. Index gives the postion to start the search from and predicate is the condtion that selects the dialogue
    public DialogueFrame getdialogue(int index, Predicate<DialogueFrame> predicate ){
      int i = dialogueframes.FindIndex(index, predicate);
      return dialogueframes[i];

    }

  }


  public class Parser{
    public DialogueList beginParse(string filename, int scene){
      DialogueList dialoguelist = new DialogueList();
      bool next_scene = false; // check if the parser has reached the next scene
      string data ;
      bool prev_scene = false; // Dheck if the parser is not in required scene
      StreamReader fs = new StreamReader(filename );
      using (fs)
      {
          do {
            data= fs.ReadLine();// Read the data
            if ( data !="$$"  )// ending delimiter
            {
              //  Debug.Log("loop");
                string[] data_values = data.Split('|'); // parsing it as string
                DialogueFrame dialogueframe = new DialogueFrame(Int32.Parse(data_values[0]),Int32.Parse(data_values[1]),Int32.Parse(data_values[2]),data_values[3],data_values[4],Int32.Parse(data_values[5]),Int32.Parse(data_values[6])); // Adding the data to the dataframe
                if (dialogueframe.scene == scene +1){ // checking if the data frame is of next scene
                  next_scene= true;
                }
                if (dialogueframe.scene < scene){
                  prev_scene = true;
                }
                if (dialogueframe.scene == scene){
                  prev_scene = false;
                }
                if (!next_scene && !prev_scene){// Only add to the list if the data is of the same scene
                    dialoguelist.adddialogue(dialogueframe);
                }



            }

          }while(data!= "$$" &&  !next_scene);
        }
        return dialoguelist;
    }

  }
  public class knowledgebase : MonoBehaviour
  {
      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }
    }
}
