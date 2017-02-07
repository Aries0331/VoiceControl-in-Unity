﻿// Video tutorial from https://www.youtube.com/watch?v=HwT6QyOA80E

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Recognition : MonoBehaviour {

	// create an object called keywordRecognizer
	KeywordRecognizer keywordRecognizer;
	// use string for recognition and action for call back
	// create a dictionary coutaing words and actions according to the words
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// create keywordrecognition and set it up 
	// Use this for initialization
	void Start () {
		//initialize stuff
		keywords.Add("go", () =>
			{
				GoCalled();
			} );

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray ());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPharseRecognized;
		keywordRecognizer.Start ();
	}

	void KeywordRecognizerOnPharseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;

		if(keywords.TryGetValue(args.text, out keywordAction)) // args.text is the word we just said
		{
			keywordAction.Invoke ();
		}
	}

	void GoCalled() {
		print ("You just said GO");
	}

	// Update is called once per frame
	void Update () {

	}

}
