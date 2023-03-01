using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace BrennanHatton.Discord
{
    public class DiscordPUNConnection : MonoBehaviourPunCallbacks
	{
		
		public string JOINED_MESSAGE = "joined the metaverse.";
		bool connected = false;
		public bool Connected {get {return connected;}}
		
		//get information about current players
	    public string GetClassData()
	    {
		    if(connected == false)
			    return "";
				
		    string returnData = "```"+PhotonNetwork.PlayerList.Length.ToString() + " "+ClassDiscordConnection.Instance.USER_STR+"s:";
			
		    for(int i = 0 ; i < PhotonNetwork.PlayerList.Length; i++)
		    {
					
			    returnData += "\n"+PhotonNetwork.PlayerList[i].ActorNumber
				    +" : "+PhotonNetwork.PlayerList[i].NickName;
					
			    if(PhotonNetwork.PlayerList[i].IsLocal)
				    returnData += " - id:" + SystemInfo.deviceUniqueIdentifier;
		    }
			
		    return returnData+"```";
	    }
		
	    public override void OnJoinedRoom()
	    {
		    base.OnJoinedRoom();
			
		    connected = true;
			
		    if(ClassDiscordConnection.Instance.Id == -2)
			    ClassDiscordConnection.Instance.Id = ClassDiscordConnection.Instance.GetId(SystemInfo.deviceUniqueIdentifier);
			
		    SendMessage(JOINED_MESSAGE);
			
	    }
    }
}
