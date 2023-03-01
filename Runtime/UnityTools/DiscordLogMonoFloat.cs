using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrennanHatton.UnityTools.MonoFloat;

namespace BrennanHatton.Discord
{
	public class DiscordLogMonoFloat : MonoBehaviour
	{
		public string preMessage, postMessage;
		
		public void ClassStarted(string _message)
		{
			DiscordLogManager.Instance.SendMessage(preMessage + _message + postMessage);
		}
    }
}
