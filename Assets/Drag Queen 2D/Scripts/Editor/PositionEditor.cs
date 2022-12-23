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
	public abstract class PositionEditor : TargetEditor
	{
		SerializedProperty _centerOnPointer;

		SerializedProperty _useCurrentZ;
		SerializedProperty _dragPositionZ;

		SerializedProperty _offsetPosition;
		SerializedProperty _positionOffset;
		SerializedProperty _positionOffsetSpace;

		SerializedProperty _clampPosition;
		SerializedProperty _positionMinimum;
		SerializedProperty _positionMaximum;
		SerializedProperty _clampPositionSpace;

		SerializedProperty _useTargets;


		// Position OnEnable
		protected void PositionOnEnable()
		{
			_centerOnPointer = serializedObject.FindProperty("CenterOnPointer");

			_useCurrentZ = serializedObject.FindProperty("UseCurrentZ");
			_dragPositionZ = serializedObject.FindProperty("DragPositionZ");

			_offsetPosition = serializedObject.FindProperty("OffsetPosition");
			_positionOffset = serializedObject.FindProperty("PositionOffset");
			_positionOffsetSpace = serializedObject.FindProperty("PositionOffsetSpace");

			_clampPosition = serializedObject.FindProperty("ClampPosition");
			_positionMinimum = serializedObject.FindProperty("PositionMinimum");
			_positionMaximum = serializedObject.FindProperty("PositionMaximum");
			_clampPositionSpace = serializedObject.FindProperty("ClampSpace");

			_useTargets = serializedObject.FindProperty("UseTargets");

			TargetOnEnable();
		}


		// Position OnInspectorGUI
		protected void PositionOnInspectorGUI()
		{
			EditorGUILayout.LabelField("Position", _styleSection);
			EditorGUILayout.PropertyField(_centerOnPointer);
			DisplayOptional(_useCurrentZ, _useCurrentZ.displayName, new SerializedProperty[] { _dragPositionZ }, new string[] { _dragPositionZ.displayName }, true);
			DisplayOptional(_offsetPosition, _offsetPosition.displayName, new SerializedProperty[] { _positionOffset, _positionOffsetSpace }, new string[] { "Offset", "Space" });
			DisplayOptional(_clampPosition, _clampPosition.displayName, new SerializedProperty[] { _positionMinimum, _positionMaximum, _clampPositionSpace }, new string[] { "Minimum", "Maximum", "Space" });
			EditorGUILayout.PropertyField(_useTargets);
			if (_useTargets.boolValue)
				TargetOnInspectorGUI();
		}
	}
}
