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

namespace ChristopherCreates.DragQueen2D
{
	public abstract class Message : MonoBehaviour
	{
		// Messages
		[Tooltip("If true, send messages once when entering hover over targets.")]
		/// <summary>
		/// If true, send messages once when entering hover over targets.  UseTargets and SendMessages must be true.
		/// </summary>
		public bool SendHoverEnter = false;
		public MessageValue HoverEnterMessage = new MessageValue() { Message = "OnHoverEnter" };

		[Tooltip("If true, send messages each update while hovering over targets.")]
		/// <summary>
		/// If true, send messages each update while hovering over targets.  UseTargets and SendMessages must be true.
		/// </summary>
		public bool SendHoverStay = false;
		public MessageValue HoverStayMessage = new MessageValue() { Message = "OnHoverStay" };

		[Tooltip("If true, send messages once when exiting hover over targets.")]
		/// <summary>
		/// If true, send messages once when exiting hover over targets.  UseTargets and SendMessages must be true.
		/// </summary>
		public bool SendHoverExit = false;
		public MessageValue HoverExitMessage = new MessageValue() { Message = "OnHoverExit" };

		[Tooltip("If true, send messages when dropping over targets.")]
		/// <summary>
		/// If true, send messages when dropping over targets.  UseTargets and SendMessages must be true.
		/// </summary>
		public bool SendDrop = true;
		public MessageValue DropMessage = new MessageValue() { Message = "OnDrop" };

		[Tooltip("The maximum number of targets to track.")]
		/// <summary>
		/// The maximum number of targets to track.  UseTargets must be true.
		/// </summary>
		public int MaximumTargets = 100;


		protected GameObject[] _targets;
		protected int _targetCount;


		GameObject[] _targetsOld;
		int _targetsOldCount;
		int _indexMessage;
		int _indexHover;
		object _messageValue;


		// Message Start
		protected void MessageStart()
		{
			// Init old targets
			_targetsOld = new GameObject[MaximumTargets];

			// Get message values
			HoverEnterMessage.Value = GetMessageValue(SendHoverEnter, HoverEnterMessage);
			HoverStayMessage.Value = GetMessageValue(SendHoverStay, HoverStayMessage);
			HoverExitMessage.Value = GetMessageValue(SendHoverExit, HoverExitMessage);
			DropMessage.Value = GetMessageValue(SendHoverExit, DropMessage);
		}


		// Message OnMouseDown
		protected void MessageOnMouseDown()
		{
			// Init old targets
			_targetsOldCount = 0;
		}


		// Message OnMouseDrag
		protected void MessageOnMouseDrag()
		{
			// Send hover enter messages
			SendHoverEnterMessages();

			// Send hover stay messages
			SendHoverStayMessages();

			// Send hover exit messages
			SendHoverExitMessages();

			// Save targets for next check
			SaveTargets();
		}


		// Message OnMouseUp
		protected void MessageOnMouseUp()
		{
			// Send drop messages
			if (SendDrop)
				for (_indexMessage = 0; _indexMessage < _targetCount; _indexMessage++)
					SendDragMessage(DropMessage.SendTo, _targets[_indexMessage], DropMessage.Message, DropMessage.Value, DropMessage.SendUpwards);

			// Send hover exit messages
			SendHoverExitMessages();
		}


		// Find a target
		protected int FindTarget(GameObject target)
		{
			for (_indexMessage = 0; _indexMessage < _targetCount; _indexMessage++)
				if (_targets[_indexMessage] == target)
					return _indexMessage;
			return -1;
		}


		// Find an old target
		int FindTargetOld(GameObject target)
		{
			for (_indexMessage = 0; _indexMessage < _targetsOldCount; _indexMessage++)
				if (_targetsOld[_indexMessage] == target)
					return _indexMessage;
			return -1;
		}


		// Get the value for a message
		object GetMessageValue(bool doSend, MessageValue value)
		{
			object messageValue = null;
			if (doSend)
				switch (value.Type)
				{
					case ValueType.SelfGameObject:
						messageValue = gameObject;
						break;
					case ValueType.AnimationCurve:
						messageValue = value.AnimationCurve;
						break;
					case ValueType.Bool:
						messageValue = value.Bool;
						break;
					case ValueType.Bounds:
						messageValue = value.Bounds;
						break;
					case ValueType.Color:
						messageValue = value.Color;
						break;
					case ValueType.Double:
						messageValue = value.Double;
						break;
					case ValueType.Float:
						messageValue = value.Float;
						break;
					case ValueType.Int:
						messageValue = value.Int;
						break;
					case ValueType.Long:
						messageValue = value.Long;
						break;
					case ValueType.Rect:
						messageValue = value.Rect;
						break;
					case ValueType.String:
						messageValue = value.String;
						break;
					case ValueType.Vector2:
						messageValue = value.Vector2;
						break;
					case ValueType.Vector3:
						messageValue = value.Vector3;
						break;
					case ValueType.Vector4:
						messageValue = value.Vector4;
						break;
				}
			return messageValue;
		}


		// Save targets for next check
		void SaveTargets()
		{
			_targetsOldCount = _targetCount;
			for (int _index = 0; _index < _targetsOldCount; _index++)
				_targetsOld[_index] = _targets[_index];
		}


		// Send a message
		void SendDragMessage(Recipient sendTo, GameObject target, string message, object value, bool sendUpwards)
		{
			if (sendTo == Recipient.Target || sendTo == Recipient.Both)
			{
				if (sendUpwards)
					target.SendMessageUpwards(message, value, SendMessageOptions.DontRequireReceiver);
				else
					target.SendMessage(message, value, SendMessageOptions.DontRequireReceiver);
			}

			if (sendTo == Recipient.Self || sendTo == Recipient.Both)
			{
				if (sendUpwards)
					gameObject.SendMessageUpwards(message, value, SendMessageOptions.DontRequireReceiver);
				else
					gameObject.SendMessage(message, value, SendMessageOptions.DontRequireReceiver);
			}
		}


		// Send hover enter messages
		void SendHoverEnterMessages()
		{
			if (SendHoverEnter)
				for (_indexHover = 0; _indexHover < _targetCount; _indexHover++)
					if (FindTargetOld(_targets[_indexHover]) == -1)
						SendDragMessage(HoverEnterMessage.SendTo, _targets[_indexHover], HoverEnterMessage.Message, HoverEnterMessage.Value, HoverEnterMessage.SendUpwards);
		}


		// Send hover stay messages
		void SendHoverStayMessages()
		{
			if (SendHoverStay)
				for (_indexHover = 0; _indexHover < _targetCount; _indexHover++)
					if (FindTargetOld(_targets[_indexHover]) != -1)
						SendDragMessage(HoverStayMessage.SendTo, _targets[_indexHover], HoverStayMessage.Message, HoverStayMessage.Value, HoverStayMessage.SendUpwards);
		}


		// Send hover exit messages
		void SendHoverExitMessages()
		{
			if (SendHoverExit)
				for (_indexHover = 0; _indexHover < _targetsOldCount; _indexHover++)
					if (FindTarget(_targetsOld[_indexHover]) == -1)
						SendDragMessage(HoverExitMessage.SendTo, _targetsOld[_indexHover], HoverExitMessage.Message, HoverExitMessage.Value, HoverExitMessage.SendUpwards);
		}
	}
}
