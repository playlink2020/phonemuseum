/*
 *	Drag Queen 2D
 *
 *	Copyright 2016 Christopher Stanley
 *
 *	Documentation: "Drag Queen 2D Manual.pdf"
 *
 *	Support: support@ChristopherCreates.com
 */


using UnityEngine;
using UnityEditor;

namespace ChristopherCreates.DragQueen2D
{
	[CustomEditor(typeof(DragQueen2D))]
	public class DragQueenEditor : RotationEditor
	{
		SerializedProperty _dragType;
		SerializedProperty _dragSensitivity;

		SerializedProperty _useDragThreshold;
		SerializedProperty _dragThreshold;
		SerializedProperty _dragThresholdSpace;


		const float _labelWidth = 160;


		GameObject gameObject;
		bool _hasCollider2D;
		bool _hasRigidbody2D;
		GUIStyle _styleError = new GUIStyle();


		// Set up inspector
		void OnEnable()
		{
			// Init
			gameObject = ((MonoBehaviour)target).gameObject;

			// Label styles
			_styleError.normal.textColor = Color.red;
			_styleError.fontStyle = FontStyle.Bold;
			_styleError.wordWrap = true;

			_styleSection.fontStyle = FontStyle.Bold;

			// Verify components
			if (gameObject.GetComponent<Collider2D>() == null)
				_hasCollider2D = false;
			else
				_hasCollider2D = true;

			if (gameObject.GetComponent<Rigidbody2D>() == null)
				_hasRigidbody2D = false;
			else
				_hasRigidbody2D = true;

			// Get serialized properties
			_dragType = serializedObject.FindProperty("DragType");
			_dragSensitivity = serializedObject.FindProperty("DragSensitivity");

			_useDragThreshold = serializedObject.FindProperty("UseDragThreshold");
			_dragThreshold = serializedObject.FindProperty("DragThreshold");
			_dragThresholdSpace = serializedObject.FindProperty("ThresholdSpace");

			PositionOnEnable();
			RotationOnEnable();
		}


		// Main inspector display
		public override void OnInspectorGUI()
		{
			// Update properties
			serializedObject.Update();

			// Set label width
			EditorGUIUtility.labelWidth = _labelWidth;

			// Check components
			DisplayComponentError(_hasCollider2D, DragQueen2D.ErrorCollider2D);
			DisplayComponentError(_hasRigidbody2D, DragQueen2D.ErrorRigidbody2D);

			// Display main settings
			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(_dragType);
			EditorGUILayout.PropertyField(_dragSensitivity);
			DisplayOptional(_useDragThreshold, _useDragThreshold.displayName, new SerializedProperty[] { _dragThreshold, _dragThresholdSpace }, new string[] { "Threshold", "Space" });
			EditorGUILayout.Space();

			// Display drag type settings
			switch ((Drag)_dragType.enumValueIndex)
			{
				case Drag.Position:
					PositionOnInspectorGUI();
					break;
				case Drag.Rotation:
					RotationOnInspectorGUI();
					break;
			}
			EditorGUILayout.Space();

			// Save properties
			serializedObject.ApplyModifiedProperties();
		}


		// Display component error
		void DisplayComponentError(bool hasComponent, string error)
		{
			if (!hasComponent)
			{
				EditorGUILayout.Space();
				EditorGUILayout.LabelField(error, _styleError);
			}
		}
	}
}
