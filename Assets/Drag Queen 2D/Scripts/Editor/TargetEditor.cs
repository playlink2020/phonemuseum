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
using UnityEngine;

namespace ChristopherCreates.DragQueen2D
{
	public abstract class TargetEditor : MessageEditor
	{
		// Target filter settings
		SerializedProperty _filterTargets;

		SerializedProperty _byLayer;
		SerializedProperty _validLayers;

		SerializedProperty _byTag;
		SerializedProperty _validTags;
		SerializedProperty _useTagWildcard;

		SerializedProperty _byName;
		SerializedProperty _validNames;
		SerializedProperty _useNameWildcard;

		// Target type
		SerializedProperty _targetTriggers;
		SerializedProperty _targetCollisions;
		SerializedProperty _targetCasting;
		SerializedProperty _maximumTargets;

		// No target drop
		SerializedProperty _requireDropTarget;
		SerializedProperty _returnType;
		SerializedProperty _returnLerpType;
		SerializedProperty _returnLerpDuration;
		SerializedProperty _returnLerpSpeed;
		SerializedProperty _returnLerpSpace;
		SerializedProperty _dropNoTargetMessage;
		SerializedProperty _sendDropNoTargetUpwards;
		SerializedProperty _dropNoTargetValueSpace;

		// Cast direction settings
		SerializedProperty _castCardinal;
		SerializedProperty _castUp;
		SerializedProperty _castDown;
		SerializedProperty _castLeft;
		SerializedProperty _castRight;

		SerializedProperty _castDiagonal;
		SerializedProperty _castUpLeft;
		SerializedProperty _castUpRight;
		SerializedProperty _castDownLeft;
		SerializedProperty _castDownRight;

		SerializedProperty _castCustom;
		SerializedProperty _customCasts;

		// Cast settings
		SerializedProperty _castFrom;
		SerializedProperty _addFromDistance;
		SerializedProperty _castFromDistance;
		SerializedProperty _fromDistanceSpace;

		SerializedProperty _castShape;
		SerializedProperty _boxAngle;

		SerializedProperty _shapeSizeType;
		SerializedProperty _boxSize;
		SerializedProperty _circleRadius;
		SerializedProperty _shapeSpace;

		SerializedProperty _castLocalSpace;
		SerializedProperty _offsetCast;
		SerializedProperty _castOffset;
		SerializedProperty _castOffsetSpace;

		SerializedProperty _limitDistance;
		SerializedProperty _targetDistance;
		SerializedProperty _distanceSpace;

		SerializedProperty _drawDebugLines;

		SerializedProperty _sendMessages;


		// Get drop serialized properties
		protected void TargetOnEnable()
		{
			MessageOnEnable();
			GetFilterProperties();
			GetDirectionProperties();
			GetTargetProperties();
		}


		// Display message target settings
		protected void TargetOnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Targets", _styleSection);

			DisplayFilterSettings();
			EditorGUILayout.PropertyField(_targetTriggers);
			EditorGUILayout.PropertyField(_targetCollisions);
			EditorGUILayout.PropertyField(_targetCasting);
			EditorGUILayout.PropertyField(_maximumTargets);

			EditorGUILayout.PropertyField(_requireDropTarget);
			if (_requireDropTarget.boolValue)
			{
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField(_returnType);
				switch ((Return)_returnType.enumValueIndex)
				{
					case Return.Lerp:
						EditorGUILayout.PropertyField(_returnLerpType, new GUIContent("Lerp Type"));
						if ((Lerp)_returnLerpType.enumValueIndex == Lerp.Speed)
						{
							EditorGUILayout.PropertyField(_returnLerpSpeed, new GUIContent("Distance/Second"));
							EditorGUILayout.PropertyField(_returnLerpSpace, new GUIContent("Space"));
						}
						else
							EditorGUILayout.PropertyField(_returnLerpDuration, new GUIContent("Duration"));
						break;

					case Return.Message:
						EditorGUILayout.PropertyField(_dropNoTargetMessage, new GUIContent("No Target Message"));
						EditorGUILayout.PropertyField(_dropNoTargetValueSpace, new GUIContent("Space"));
						EditorGUILayout.PropertyField(_sendDropNoTargetUpwards, new GUIContent("Send Upwards"));
						break;
				}
				EditorGUI.indentLevel--;
			}

			EditorGUILayout.PropertyField(_sendMessages);

			if (_targetCasting.boolValue)
				DisplayCastSettings();

			if (_sendMessages.boolValue)
				MessageOnInspectorGUI();
		}


		// Display an optional section
		protected void DisplayOptional(SerializedProperty useOptions, string toggleLabel, SerializedProperty[] options, string[] optionLabels, bool useReverse = false)
		{
			EditorGUILayout.PropertyField(useOptions, new GUIContent(toggleLabel));
			if ((!useReverse && useOptions.boolValue) || (useReverse && !useOptions.boolValue))
			{
				EditorGUI.indentLevel++;
				for (int index = 0; index < options.Length; index++)
					EditorGUILayout.PropertyField(options[index], new GUIContent(optionLabels[index]), true);
				EditorGUI.indentLevel--;
			}
		}


		// Display custom casting settings
		void DisplayCastSettings()
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Casting", _styleSection);

			DisplayOptional(_castCardinal, _castCardinal.displayName, new SerializedProperty[] { _castUp, _castDown, _castLeft, _castRight }, new string[] { "Up", "Down", "Left", "Right" });
			DisplayOptional(_castDiagonal, _castDiagonal.displayName, new SerializedProperty[] { _castUpLeft, _castUpRight, _castDownLeft, _castDownRight }, new string[] { "Up Left", "Up Right", "Down Left", "Down Right" });
			DisplayOptional(_castCustom, _castCustom.displayName, new SerializedProperty[] { _customCasts }, new string[] { "Directions" });

			EditorGUILayout.PropertyField(_castFrom);
			DisplayOptional(_addFromDistance, _addFromDistance.displayName, new SerializedProperty[] { _castFromDistance, _fromDistanceSpace }, new string[] { "Distance", "Space" });

			EditorGUILayout.PropertyField(_castShape);
			if ((Shape)_castShape.enumValueIndex != Shape.Ray)
			{
				EditorGUI.indentLevel++;

				if ((Shape)_castShape.enumValueIndex == Shape.Box)
				{
					EditorGUILayout.PropertyField(_boxAngle, new GUIContent("Angle"));
					EditorGUILayout.PropertyField(_boxSize, new GUIContent("Size"));
				}
				else
					EditorGUILayout.PropertyField(_circleRadius, new GUIContent("Radius"));

				EditorGUILayout.PropertyField(_shapeSizeType, new GUIContent("Size Type"));
				if ((Size)_shapeSizeType.enumValueIndex == Size.Fixed)
					EditorGUILayout.PropertyField(_shapeSpace, new GUIContent("Space"));

				EditorGUI.indentLevel--;
			}

			EditorGUILayout.PropertyField(_castLocalSpace);
			DisplayOptional(_offsetCast, _offsetCast.displayName, new SerializedProperty[] { _castOffset, _castOffsetSpace }, new string[] { "Offset", "Space" });
			DisplayOptional(_limitDistance, _limitDistance.displayName, new SerializedProperty[] { _targetDistance, _distanceSpace }, new string[] { "Distance", "Space" });
			EditorGUILayout.PropertyField(_drawDebugLines);
		}


		// Display filter settings
		void DisplayFilterSettings()
		{
			EditorGUILayout.PropertyField(_filterTargets);
			if (_filterTargets.boolValue)
			{
				EditorGUI.indentLevel++;
				DisplayOptional(_byLayer, _byLayer.displayName, new SerializedProperty[] { _validLayers }, new string[] { _validLayers.displayName });
				DisplayOptional(_byTag, _byTag.displayName, new SerializedProperty[] { _validTags, _useTagWildcard }, new string[] { _validTags.displayName, _useTagWildcard.displayName });
				DisplayOptional(_byName, _byName.displayName, new SerializedProperty[] { _validNames, _useNameWildcard }, new string[] { _validNames.displayName, _useNameWildcard.displayName });
				EditorGUI.indentLevel--;
			}
		}


		// Get target direction serialized properties
		void GetDirectionProperties()
		{
			_castCardinal = serializedObject.FindProperty("CastCardinal");
			_castUp = serializedObject.FindProperty("CastUp");
			_castDown = serializedObject.FindProperty("CastDown");
			_castLeft = serializedObject.FindProperty("CastLeft");
			_castRight = serializedObject.FindProperty("CastRight");

			_castDiagonal = serializedObject.FindProperty("CastDiagonal");
			_castUpLeft = serializedObject.FindProperty("CastUpLeft");
			_castUpRight = serializedObject.FindProperty("CastUpRight");
			_castDownLeft = serializedObject.FindProperty("CastDownLeft");
			_castDownRight = serializedObject.FindProperty("CastDownRight");

			_castCustom = serializedObject.FindProperty("CastCustom");
			_customCasts = serializedObject.FindProperty("CustomCasts");
		}


		// Get filter target serialized properties
		void GetFilterProperties()
		{
			_filterTargets = serializedObject.FindProperty("FilterTargets");

			_byLayer = serializedObject.FindProperty("ByLayer");
			_validLayers = serializedObject.FindProperty("ValidLayers");

			_byTag = serializedObject.FindProperty("ByTag");
			_validTags = serializedObject.FindProperty("ValidTags");
			_useTagWildcard = serializedObject.FindProperty("UseTagWildcard");

			_byName = serializedObject.FindProperty("ByName");
			_validNames = serializedObject.FindProperty("ValidNames");
			_useNameWildcard = serializedObject.FindProperty("UseNameWildcard");
		}


		// Get target and casting serialized properties
		void GetTargetProperties()
		{
			_targetTriggers = serializedObject.FindProperty("TargetTriggers");
			_targetCollisions = serializedObject.FindProperty("TargetCollisions");
			_targetCasting = serializedObject.FindProperty("TargetCasting");

			_maximumTargets = serializedObject.FindProperty("MaximumTargets");

			_requireDropTarget = serializedObject.FindProperty("RequireDropTarget");
			_returnType = serializedObject.FindProperty("ReturnType");
			_returnLerpType = serializedObject.FindProperty("ReturnLerpType");
			_returnLerpDuration = serializedObject.FindProperty("ReturnLerpDuration");
			_returnLerpSpeed = serializedObject.FindProperty("ReturnLerpSpeed");
			_returnLerpSpace = serializedObject.FindProperty("ReturnLerpSpace");
			_dropNoTargetMessage = serializedObject.FindProperty("DropNoTargetMessage");
			_sendDropNoTargetUpwards = serializedObject.FindProperty("SendDropNoTargetUpwards");
			_dropNoTargetValueSpace = serializedObject.FindProperty("DropNoTargetValueSpace");

			_castFrom = serializedObject.FindProperty("CastFrom");
			_addFromDistance = serializedObject.FindProperty("AddFromDistance");
			_castFromDistance = serializedObject.FindProperty("CastFromDistance");
			_fromDistanceSpace = serializedObject.FindProperty("FromDistanceSpace");

			_castShape = serializedObject.FindProperty("CastShape");
			_boxAngle = serializedObject.FindProperty("BoxAngle");
			_shapeSizeType = serializedObject.FindProperty("ShapeSizeType");
			_boxSize = serializedObject.FindProperty("BoxSize");
			_circleRadius = serializedObject.FindProperty("CircleRadius");
			_shapeSpace = serializedObject.FindProperty("ShapeSpace");

			_castLocalSpace = serializedObject.FindProperty("CastLocalSpace");
			_offsetCast = serializedObject.FindProperty("OffsetCast");
			_castOffset = serializedObject.FindProperty("CastOffset");
			_castOffsetSpace = serializedObject.FindProperty("CastOffsetSpace");

			_limitDistance = serializedObject.FindProperty("LimitDistance");

			_targetDistance = serializedObject.FindProperty("TargetDistance");
			_distanceSpace = serializedObject.FindProperty("DistanceSpace");

			_drawDebugLines = serializedObject.FindProperty("DrawDebugLines");

			_sendMessages = serializedObject.FindProperty("SendMessages");
		}
	}
}
