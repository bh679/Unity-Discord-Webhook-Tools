/*
Brennan Hatton 18-01-2023

Sends formatted message to discord webhooks with device info.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Discord
{
	
	public delegate string GetString();

	[System.Serializable]
	public class KnownIds
	{
		public string id, name, contact;
		public bool debug = true;
	}
	
	public class DiscordLogManager : MonoBehaviour
	{
		//Public and private webhooks
		public DiscordWebhook webhook, debugWebHook;
		
		List<GetString> externalStringsForEnd = new List<GetString>();
		public void AddToStringAtEnd(GetString stringFunc)
		{
			externalStringsForEnd.Add(stringFunc);
		}
		
		public string GetAllExternalStringsAtEnd()
		{
			string ret = "";
			for(int  i = 0; i < externalStringsForEnd.Count; i++)
			{
				ret += externalStringsForEnd[i];
			}
			
			return ret;
		}
		
		//Singlton
		public static DiscordLogManager Instance { get; private set; }
		private void Awake() 
		{ 
			// If there is an instance, and it's not me, delete myself.
	    
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
			} 
		}
		
		//names of known devices
		public List<KnownIds> ids;
		
		//formatted information of this device and application
		string deviceData;
		public string DeviceData{
			get{return deviceData;}
		}
		
		int id = -2;
		public int Id { get; set; }
		
		public string USER_STR = "Learner";
		
		void Start()
		{
			//set formatted information of this device and application
			deviceData = "   ``Platform: "+Application.platform.ToString() +".   App V: "+ Application.version+"`` ";
		}
		
		//get id id device in known ids
		public int GetId(string _id)
		{
			for(int i =0; i < ids.Count; i++)
			{
				if(ids[i].id == _id)
					return i;
			}
			
			return -1;
		}
		
		//get name from known ids
		public string GetName()
		{
			if(id <= -1)
				return "A "+USER_STR;
			else if(ids.Count > 0)
				return "**"+ids[id].name + "**";
			else
				return "id not found";
		}
		
		
		public void SendWebhook(string message)
		{
			SendMessage(message);
		}
		
		//send a message
		//it auto adds device info
		public void SendMessage(string message, bool raw = false)
		{
			//if device info is saved, and marked as debug device
			if(id >= 0 && ids[id].debug)
				debugWebHook.SendMessage((raw?"":GetName() + " ") + message + (raw?"":deviceData + GetAllExternalStringsAtEnd()/*GetClassData()*/));
			else //send as public hook
				webhook.SendMessage((raw?"":GetName() + " ") + message + (raw?"":deviceData + GetAllExternalStringsAtEnd()/*GetClassData()*/));
		}
		
	}
}