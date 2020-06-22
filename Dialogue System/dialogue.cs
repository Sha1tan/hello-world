using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.FirstPerson
{
    public class dialogue : MonoBehaviour
    {
        public GameObject player;

        public GameObject playerCamera;

        [Header("Ветки диалога")]
        public DialogueTopic[] topic;

        [Header("Тякущая ветка")]
        public int _currentTopic;

        public bool ShowDialogue = true;
         

        private void OnTriggerStay(Collider other)
        {
            var script = player.GetComponent<Character_move>();
            var script_1 = playerCamera.GetComponent<Character_look>();

            if (other.tag == "Npc" && !ShowDialogue && Input.GetKeyDown(KeyCode.E))
            {                
                ShowDialogue = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                script.enabled = false;
                script_1.enabled = false;
            }
            else if(!ShowDialogue)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                script.enabled = true;
                script_1.enabled = true;
                
            }
           
        }




        private void OnGUI()
        {
            if (ShowDialogue == true)
            {
                GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
                GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), topic[_currentTopic].NpcText);
                for (int i = 0; i < topic[_currentTopic].PlayerAnswer.Length; i++)
                {
                    if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), topic[_currentTopic].PlayerAnswer[i].Text))
                    {
                        if (topic[_currentTopic].PlayerAnswer[i].TalkEnd)
                        {
                            ShowDialogue = false;                            
                        }
                        else
                            _currentTopic = topic[_currentTopic].PlayerAnswer[i].ToTopic;
                    }
                }
            }
        }


        [System.Serializable]
        public class DialogueTopic
        {
            public string NpcText;
            public Answer[] PlayerAnswer;
        }

        [System.Serializable]
        public class Answer
        {
            public string Text;
            public int ToTopic;
            public bool TalkEnd;
        }


        private void Start()
        {
            ShowDialogue = false;
        }
    }
}