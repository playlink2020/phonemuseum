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
	public abstract class MessageEditor : Editor
	{
		// Messages
		SerializedProperty _sendHoverEnter;
		MessageValueEditor _hoverEnterMessageValue = new MessageValueEditor();
		SerializedProperty _sendHoverStay;
		MessageValueEditor _hoverStayMessageValue = new MessageValueEditor();
		SerializedProperty _sendHoverExit;
		MessageValueEditor _hoverExitMessageValue = new MessageValueEditor();
		SerializedProperty _sendDrop;
		MessageValueEditor _dropMessageValue = new MessageValueEditor();


		protected GUIStyle _styleSection = new GUIStyle();


		// Get target message serialized properties
		protected void MessageOnEnable()
		{
			// Enter settings
			_sendHoverEnter = serializedObject.FindProperty("SendHoverEnter");
			_hoverEnterMessageValue.Message = serializedObject.FindProperty("HoverEnterMessage.Message");
			_hoverEnterMessageValue.SendValue = serializedObject.FindProperty("HoverEnterMessage.SendValue");
			_hoverEnterMessageValue.Type = serializedObject.FindProperty("HoverEnterMessage.Type");
			_hoverEnterMessageValue.AnimationCurve = serializedObject.FindProperty("HoverEnterMessage.AnimationCurve");
			_hoverEnterMessageValue.Bool = serializedObject.FindProperty("HoverEnterMessage.Bool");
			_hoverEnterMessageValue.Bounds = serializedObject.FindProperty("HoverEnterMessage.Bounds");
			_hoverEnterMessageValue.Color = serializedObject.FindProperty("HoverEnterMessage.Color");
			_hoverEnterMessageValue.Double = serializedObject.FindProperty("HoverEnterMessage.Double");
			_hoverEnterMessageValue.Float = serializedObject.FindProperty("HoverEnterMessage.Float");
			_hoverEnterMessageValue.Int = serializedObject.FindProperty("HoverEnterMessage.Int");
			_hoverEnterMessageValue.Long = serializedObject.FindProperty("HoverEnterMessage.Long");
			_hoverEnterMessageValue.Rect = serializedObject.FindProperty("HoverEnterMessage.Rect");
			_hoverEnterMessageValue.String = serializedObject.FindProperty("HoverEnterMessage.String");
			_hoverEnterMessageValue.Vector2 = serializedObject.FindProperty("HoverEnterMessage.Vector2");
			_hoverEnterMessageValue.Vector3 = serializedObject.FindProperty("HoverEnterMessage.Vector3");
			_hoverEnterMessageValue.Vector4 = serializedObject.FindProperty("HoverEnterMessage.Vector4");
			_hoverEnterMessageValue.SendTo = serializedObject.FindProperty("HoverEnterMessage.SendTo");
			_hoverEnterMessageValue.SendUpwards = serializedObject.FindProperty("HoverEnterMessage.SendUpwards");

			// Stay settings
			_sendHoverStay = serializedObject.FindProperty("SendHoverStay");
			_hoverStayMessageValue.Message = serializedObject.FindProperty("HoverStayMessage.Message");
			_hoverStayMessageValue.SendValue = serializedObject.FindProperty("HoverStayMessage.SendValue");
			_hoverStayMessageValue.Type = serializedObject.FindProperty("HoverStayMessage.Type");
			_hoverStayMessageValue.AnimationCurve = serializedObject.FindProperty("HoverStayMessage.AnimationCurve");
			_hoverStayMessageValue.Bool = serializedObject.FindProperty("HoverStayMessage.Bool");
			_hoverStayMessageValue.Bounds = serializedObject.FindProperty("HoverStayMessage.Bounds");
			_hoverStayMessageValue.Color = serializedObject.FindProperty("HoverStayMessage.Color");
			_hoverStayMessageValue.Double = serializedObject.FindProperty("HoverStayMessage.Double");
			_hoverStayMessageValue.Float = serializedObject.FindProperty("HoverStayMessage.Float");
			_hoverStayMessageValue.Int = serializedObject.FindProperty("HoverStayMessage.Int");
			_hoverStayMessageValue.Long = serializedObject.FindProperty("HoverStayMessage.Long");
			_hoverStayMessageValue.Rect = serializedObject.FindProperty("HoverStayMessage.Rect");
			_hoverStayMessageValue.String = serializedObject.FindProperty("HoverStayMessage.String");
			_hoverStayMessageValue.Vector2 = serializedObject.FindProperty("HoverStayMessage.Vector2");
			_hoverStayMessageValue.Vector3 = serializedObject.FindProperty("HoverStayMessage.Vector3");
			_hoverStayMessageValue.Vector4 = serializedObject.FindProperty("HoverStayMessage.Vector4");
			_hoverStayMessageValue.SendTo = serializedObject.FindProperty("HoverStayMessage.SendTo");
			_hoverStayMessageValue.SendUpwards = serializedObject.FindProperty("HoverStayMessage.SendUpwards");

			// Exit settings
			_sendHoverExit = serializedObject.FindProperty("SendHoverExit");
			_hoverExitMessageValue.Message = serializedObject.FindProperty("HoverExitMessage.Message");
			_hoverExitMessageValue.SendValue = serializedObject.FindProperty("HoverExitMessage.SendValue");
			_hoverExitMessageValue.Type = serializedObject.FindProperty("HoverExitMessage.Type");
			_hoverExitMessageValue.AnimationCurve = serializedObject.FindProperty("HoverExitMessage.AnimationCurve");
			_hoverExitMessageValue.Bool = serializedObject.FindProperty("HoverExitMessage.Bool");
			_hoverExitMessageValue.Bounds = serializedObject.FindProperty("HoverExitMessage.Bounds");
			_hoverExitMessageValue.Color = serializedObject.FindProperty("HoverExitMessage.Color");
			_hoverExitMessageValue.Double = serializedObject.FindProperty("HoverExitMessage.Double");
			_hoverExitMessageValue.Float = serializedObject.FindProperty("HoverExitMessage.Float");
			_hoverExitMessageValue.Int = serializedObject.FindProperty("HoverExitMessage.Int");
			_hoverExitMessageValue.Long = serializedObject.FindProperty("HoverExitMessage.Long");
			_hoverExitMessageValue.Rect = serializedObject.FindProperty("HoverExitMessage.Rect");
			_hoverExitMessageValue.String = serializedObject.FindProperty("HoverExitMessage.String");
			_hoverExitMessageValue.Vector2 = serializedObject.FindProperty("HoverExitMessage.Vector2");
			_hoverExitMessageValue.Vector3 = serializedObject.FindProperty("HoverExitMessage.Vector3");
			_hoverExitMessageValue.Vector4 = serializedObject.FindProperty("HoverExitMessage.Vector4");
			_hoverExitMessageValue.SendTo = serializedObject.FindProperty("HoverExitMessage.SendTo");
			_hoverExitMessageValue.SendUpwards = serializedObject.FindProperty("HoverExitMessage.SendUpwards");

			// Drop settings
			_sendDrop = serializedObject.FindProperty("SendDrop");
			_dropMessageValue.Message = serializedObject.FindProperty("DropMessage.Message");
			_dropMessageValue.SendValue = serializedObject.FindProperty("DropMessage.SendValue");
			_dropMessageValue.Type = serializedObject.FindProperty("DropMessage.Type");
			_dropMessageValue.AnimationCurve = serializedObject.FindProperty("DropMessage.AnimationCurve");
			_dropMessageValue.Bool = serializedObject.FindProperty("DropMessage.Bool");
			_dropMessageValue.Bounds = serializedObject.FindProperty("DropMessage.Bounds");
			_dropMessageValue.Color = serializedObject.FindProperty("DropMessage.Color");
			_dropMessageValue.Double = serializedObject.FindProperty("DropMessage.Double");
			_dropMessageValue.Float = serializedObject.FindProperty("DropMessage.Float");
			_dropMessageValue.Int = serializedObject.FindProperty("DropMessage.Int");
			_dropMessageValue.Long = serializedObject.FindProperty("DropMessage.Long");
			_dropMessageValue.Rect = serializedObject.FindProperty("DropMessage.Rect");
			_dropMessageValue.String = serializedObject.FindProperty("DropMessage.String");
			_dropMessageValue.Vector2 = serializedObject.FindProperty("DropMessage.Vector2");
			_dropMessageValue.Vector3 = serializedObject.FindProperty("DropMessage.Vector3");
			_dropMessageValue.Vector4 = serializedObject.FindProperty("DropMessage.Vector4");
			_dropMessageValue.SendTo = serializedObject.FindProperty("DropMessage.SendTo");
			_dropMessageValue.SendUpwards = serializedObject.FindProperty("DropMessage.SendUpwards");
		}


		// Display message settings
		protected void MessageOnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Messages", _styleSection);
			DisplaySendSettings(_sendHoverEnter, _hoverEnterMessageValue);
			DisplaySendSettings(_sendHoverStay, _hoverStayMessageValue);
			DisplaySendSettings(_sendHoverExit, _hoverExitMessageValue);
			DisplaySendSettings(_sendDrop, _dropMessageValue);
		}


		// Display send settings
		void DisplaySendSettings(SerializedProperty sendToggle, MessageValueEditor messageValue)
		{
			var valueLabel = new GUIContent("Value");
			EditorGUILayout.PropertyField(sendToggle);
			if (sendToggle.boolValue)
			{
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField(messageValue.Message);
				EditorGUILayout.PropertyField(messageValue.SendValue);
				if (messageValue.SendValue.boolValue)
				{
					EditorGUI.indentLevel++;
					EditorGUILayout.PropertyField(messageValue.Type, new GUIContent("Type"));
					switch ((ValueType)messageValue.Type.enumValueIndex)
					{
						case ValueType.AnimationCurve:
							EditorGUILayout.PropertyField(messageValue.AnimationCurve, valueLabel);
							EditorGUILayout.Space();
							break;
						case ValueType.Bool:
							EditorGUILayout.PropertyField(messageValue.Bool, valueLabel);
							break;
						case ValueType.Bounds:
							EditorGUI.indentLevel -= 3;
							EditorGUILayout.PropertyField(messageValue.Bounds, valueLabel);
							EditorGUILayout.Space();
							EditorGUI.indentLevel += 3;
							break;
						case ValueType.Color:
							EditorGUILayout.PropertyField(messageValue.Color, valueLabel);
							break;
						case ValueType.Double:
							EditorGUILayout.PropertyField(messageValue.Double, valueLabel);
							break;
						case ValueType.Float:
							EditorGUILayout.PropertyField(messageValue.Float, valueLabel);
							break;
						case ValueType.Int:
							EditorGUILayout.PropertyField(messageValue.Int, valueLabel);
							break;
						case ValueType.Long:
							EditorGUILayout.PropertyField(messageValue.Long, valueLabel);
							break;
						case ValueType.Rect:
							EditorGUILayout.PropertyField(messageValue.Rect, valueLabel);
							break;
						case ValueType.String:
							EditorGUILayout.PropertyField(messageValue.String, valueLabel);
							break;
						case ValueType.Vector2:
							EditorGUILayout.PropertyField(messageValue.Vector2, valueLabel);
							break;
						case ValueType.Vector3:
							EditorGUILayout.PropertyField(messageValue.Vector3, valueLabel);
							break;
						case ValueType.Vector4:
							EditorGUILayout.PropertyField(messageValue.Vector4, valueLabel, true);
							break;
					}
					EditorGUI.indentLevel--;
				}
				EditorGUILayout.PropertyField(messageValue.SendTo, new GUIContent("Send To"));
				EditorGUILayout.PropertyField(messageValue.SendUpwards, new GUIContent("Send Upwards"));
				EditorGUI.indentLevel--;
			}
		}
	}
}
