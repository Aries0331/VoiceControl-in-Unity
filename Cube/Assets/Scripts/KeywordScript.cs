﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;


public class KeywordScript : MonoBehaviour {

	[SerializeField]
	private string[] m_Keywords;

	private KeywordRecognizer m_Recognizer;

	// Use this for initialization
	void Start () {
		
		m_Recognizer = new KeywordRecognizer(m_Keywords);
		m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
		m_Recognizer.Start();

		mat = GetComponent<MeshRenderer> ().material;
	}

	private void OnPhraseRecognized (PhraseRecognizedEventArgs args) {
		
		StringBuilder builder = new StringBuilder();
		builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
		builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
		builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
		Debug.Log(builder.ToString());

		ApplyColor (args.text);
	}


	public Material mat;

	void ApplyColor (string color) {
		if (color == "red") {
			mat.color = Color.red;
		}
		if (color == "blue") {
			mat.color = Color.blue;
		}
		if (color == "black") {
			mat.color = Color.black;
		}
		if (color == "yellow") {
		mat.color = Color.yellow;
		}
	}
}
