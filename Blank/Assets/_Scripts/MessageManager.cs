using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour {
	public static MessageManager instance =  null;
	public Button fake_button;
	public Text text_ui;
	public List<MessageList> list;

	int sequence_index = 0;
	int message_index = 0;
	List<string> actual_sequence;

	public int delete_fake_b_count = 0;

	public Transform spawnPoint;  
	public GameObject player_prefab;
	void Awake(){
		if (!instance)
			instance = this;
		else if (instance)
			Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		StartNewSecuence ();
		if (delete_fake_b_count >= 4)
			fake_button.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawnPoint)
			spawnPoint = FindObjectOfType<SpawnPoint> ().transform;
		
		if (Input.GetMouseButtonUp (0)) {
			if (text_ui.transform.parent.gameObject.activeSelf) {
				ShowNextMessage ();
				delete_fake_b_count++;
			}
		}

		if (delete_fake_b_count > 4)
			fake_button.gameObject.SetActive (false);
	}
	void StartNewSecuence(){
		actual_sequence = list [sequence_index].message_list; 
		text_ui.text = actual_sequence[message_index]; 
		message_index++; 
	}
	void ShowNextMessage(){
		if (message_index < actual_sequence.Count) {
			text_ui.text = actual_sequence [message_index];
			message_index++;
		} else {
			text_ui.transform.parent.gameObject.SetActive (false);
			GameObject go = (GameObject) Instantiate (player_prefab) as GameObject; 
			go.transform.position = spawnPoint.position;
		}
	}


}

[System.Serializable]
public class MessageList : System.Object
{
	public List<string> message_list;
}
