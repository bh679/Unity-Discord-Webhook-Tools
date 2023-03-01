using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Discord
{
	[AddComponentMenu("Brennan Hatton/Discord Logger")]
	public class DiscordLogger : MonoBehaviour
	{
		const string defaultName = "no name provided";
		public void ClassStarted(string name = defaultName)
		{
			DiscordLogManager.Instance.SendMessage("started class '" + name);
		}
    
		public void SceneStarted(string sceneName)
		{
			DiscordLogManager.Instance.SendMessage("started '" +sceneName+"'");
		}
		
		public void ReviewStarted(string name = defaultName)
		{
			DiscordLogManager.Instance.SendMessage("started review for '"+name+"'.");
		}
			
		public void ClassEnded(string name = defaultName)
		{
			DiscordLogManager.Instance.SendMessage("reached final review for '"+name+"'.");
		}
	}
}