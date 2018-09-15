using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
	English
}

public class Localization : BaseSingleton<Localization> 
{
	public Language currentLanguage { get; private set; }

	public string GetTranslation(string key)
	{
		//TODO
		return key;
	}
}
