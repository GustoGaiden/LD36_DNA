// Copyright (c) Rotorz Limited. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using Rotorz.ReorderableList;
using UnityEditor;

[CustomEditor(typeof(HumanGenomeConfig))]
public class HumanGenomeConfigDrawer : Editor
{

	private SerializedProperty _genome;
	
	private void OnEnable()
	{
		_genome = serializedObject.FindProperty("HumanGenome");
		
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		ReorderableListGUI.Title("Human Genome");
		ReorderableListGUI.ListField(_genome);

		
		serializedObject.ApplyModifiedProperties();
	}

}