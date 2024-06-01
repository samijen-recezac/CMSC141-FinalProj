using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour{

    struct DialogueLine{
        public string name;
        public string content;
        public int pose;
        public string position;
        public string[] options;

        public DialogueLine(string Name, string Content, int Pose, string Position){
            name = Name;
            content = Content;
            pose = Pose;
            position = Position;
            options = new string[0];
        }
    }

    List<DialogueLine> lines;

        // Start is called before the first frame update
        void Start(){
        
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
