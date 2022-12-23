/*
 *	Drag Queen 2D
 *
 *	Copyright 2016 Christopher Stanley
 *
 *	Documentation: "Drag Queen 2D Manual.pdf"
 *
 *	Support: support@ChristopherCreates.com
 */


using System;
using UnityEngine;

namespace ChristopherCreates.DragQueen2D
{
	[Serializable]
	public class MessageValue
	{
		[Tooltip("The message to send.")]
		/// <summary>
		/// The message to send.  UseTargets, SendMessages, and Send{MessageType} must be true.
		/// </summary>
		public string Message = "";

		[Tooltip("If true, send a value with the message.")]
		/// <summary>
		/// If true, send a value with the message.  UseTargets, SendMessages, and Send{MessageType} must be true.
		/// </summary>
		public bool SendValue = false;

		[Tooltip("The type of value to send.")]
		/// <summary>
		/// The type of value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public ValueType Type = ValueType.SelfGameObject;

		[Tooltip("The AnimationCurve value to send.")]
		/// <summary>
		/// The AnimationCurve value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public AnimationCurve AnimationCurve = new AnimationCurve();

		[Tooltip("The bool value to send.")]
		/// <summary>
		/// The bool value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public bool Bool = false;

		[Tooltip("The Bounds value to send.")]
		/// <summary>
		/// The Bounds value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Bounds Bounds = new Bounds();

		[Tooltip("The Color value to send.")]
		/// <summary>
		/// The Color value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Color Color = new Color();

		[Tooltip("The double value to send.")]
		/// <summary>
		/// The double value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public double Double = 0;

		[Tooltip("The float value to send.")]
		/// <summary>
		/// The float value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public float Float = 0;

		[Tooltip("The int value to send.")]
		/// <summary>
		/// The int value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public int Int = 0;

		[Tooltip("The long value to send.")]
		/// <summary>
		/// The long value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public long Long = 0;

		[Tooltip("The Rect value to send.")]
		/// <summary>
		/// The Rect value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Rect Rect = new Rect();

		[Tooltip("The string value to send.")]
		/// <summary>
		/// The string value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public string String = "";

		[Tooltip("The Vector2 value to send.")]
		/// <summary>
		/// The Vector2 value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Vector2 Vector2 = new Vector2();

		[Tooltip("The Vector3 value to send.")]
		/// <summary>
		/// The Vector3 value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Vector3 Vector3 = new Vector3();

		[Tooltip("The Vector4 value to send.")]
		/// <summary>
		/// The Vector4 value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Vector4 Vector4 = new Vector4();

		/// <summary>
		/// The object value to send.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public object Value = null;

		[Tooltip("The target(s) to send the message to.")]
		/// <summary>
		/// The target(s) to send the message to.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public Recipient SendTo = Recipient.Target;

		[Tooltip("If true, the message will be sent upwards through the parent hierarchy.")]
		/// <summary>
		/// If true, the message will be sent upwards through the parent hierarchy.  UseTargets, SendMessages, Send{MessageType}, and {MessageType}.SendValue must be true.
		/// </summary>
		public bool SendUpwards = false;
	}
}
