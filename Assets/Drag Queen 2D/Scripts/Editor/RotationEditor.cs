/*
 *	Drag Queen 2D
 *
 *	Copyright 2016 Christopher Stanley
 *
 *	Documentation: "Drag Queen 2D Manual.pdf"
 *
 *	Support: support@ChristopherCreates.com
 */


using UnityEditor;

namespace ChristopherCreates.DragQueen2D
{
	public abstract class RotationEditor : PositionEditor
	{
		SerializedProperty _clampRotation;
		SerializedProperty _rotationMin;
		SerializedProperty _rotationMax;


		// Rotation OnEnable
		protected void RotationOnEnable()
		{
			_clampRotation = serializedObject.FindProperty("ClampRotation");
			_rotationMin = serializedObject.FindProperty("RotationMinimum");
			_rotationMax = serializedObject.FindProperty("RotationMaximum");
		}


		// Rotation OnInspectorGUI
		protected void RotationOnInspectorGUI()
		{
			EditorGUILayout.LabelField("Rotation", _styleSection);
			DisplayOptional(_clampRotation, _clampRotation.displayName, new SerializedProperty[] { _rotationMin, _rotationMax }, new string[] { "Minimum", "Maximum" });
		}
	}
}
