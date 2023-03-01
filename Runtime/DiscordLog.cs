using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Discord
{
    public class DiscordLog : MonoBehaviour
	{
		public string preMessage, postMessage;
		
		public void ClassStarted(string _message)
		{
			DiscordLogManager.Instance.SendMessage(preMessage + _message + postMessage);
		}
    }
}
