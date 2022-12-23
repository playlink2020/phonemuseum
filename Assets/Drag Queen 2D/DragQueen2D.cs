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
	[DisallowMultipleComponent]
	public class DragQueen2D : Rotation
	{
		[Tooltip("The type of drag action to perform.")]
		/// <summary>
		/// The type of drag action to perform.
		/// </summary>
		public Drag DragType = Drag.Position;

		[Tooltip("If true, don't begin drag action until the pointer has moved a certain distance.")]
		/// <summary>
		/// If true, don't begin drag action until the pointer has moved a certain distance.
		/// </summary>
		public bool UseDragThreshold = true;

		[Tooltip("The distance the pointer must move before a drag action will begin.")]
		/// <summary>
		/// The distance the pointer must move before a drag action will begin.  UseDragThreshold must be true.
		/// </summary>
		public float DragThreshold = 20.0f;

		[Tooltip("The space that the drag threshold is measured in.")]
		/// <summary>
		/// The space that the drag threshold is measured in.  UseDragThreshold must be true.
		/// </summary>
		public Space ThresholdSpace = Space.Screen;

		/// <summary>
		/// The currently hovered-over group of GameObjects that are valid targets.  UseTargets must be true.
		/// </summary>
		public GameObject[] Targets { get { return _targets; } }


		public const string ErrorCollider2D = "This GameObject needs a Collider2D component!";
		public const string ErrorRigidbody2D = "This GameObject needs a Rigidbody2D component!";


		bool _thresholdPassed;
		Vector2 _pointerThreshold;
		Vector2 _pointerThresholdStart;
		bool _hasRunPhysics = false;
		bool _hasRunDrag = true;


		void Start()
		{
			// Verify components
			_collider = GetComponent<Collider2D>();
			if (_collider == null)
				throw new InvalidOperationException(_logPrefix + ErrorCollider2D);

			_rigidbody2D = GetComponent<Rigidbody2D>();
			if (_rigidbody2D == null)
				throw new InvalidOperationException(_logPrefix + ErrorRigidbody2D);

			switch (DragType)
			{
				case Drag.Position:
					PositionStart();
					break;
			}
		}


		void FixedUpdate()
		{
			switch (DragType)
			{
				case Drag.Position:
					// Keep physics and drag in sync
					if (!IsInSync(ref _hasRunPhysics, ref _hasRunDrag))
						return;

					PositionFixedUpdate();
					break;
			}
		}


		void OnTriggerEnter2D(Collider2D triggering)
		{
			switch (DragType)
			{
				case Drag.Position:
					// Add target
					PositionOnTriggerEnter2D(triggering);
					break;
			}
		}


		void OnTriggerStay2D(Collider2D triggering)
		{
			switch (DragType)
			{
				case Drag.Position:
					// Add target
					PositionOnTriggerStay2D(triggering);
					break;
			}
		}


		void OnCollisionEnter2D(Collision2D colliding)
		{
			switch (DragType)
			{
				case Drag.Position:
					// Add target
					PositionOnCollisionEnter2D(colliding);
					break;
			}
		}


		void OnCollisionStay2D(Collision2D colliding)
		{
			switch (DragType)
			{
				case Drag.Position:
					// Add target
					PositionOnCollisionStay2D(colliding);
					break;
			}
		}


		void OnMouseDown()
		{
			// Get pointer
			_pointerPositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// Check threshold
			if (UseDragThreshold)
			{
				_thresholdPassed = false;
				_pointerThresholdStart = GetPointerThreshold();
			}

			// Do drag
			switch (DragType)
			{
				case Drag.Position:
					PositionOnMouseDown();
					break;
				case Drag.Rotation:
					RotationOnMouseDown();
					break;
			}
		}


		void OnMouseDrag()
		{
			// Update pointer position
			_pointerPositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// Check drag threshold
			if (!PassedDragThreshold())
				return;

			// Process drag
			switch (DragType)
			{
				case Drag.Position:
					// Keep drag and physics in sync
					if (!IsInSync(ref _hasRunDrag, ref _hasRunPhysics))
						return;
					PositionOnMouseDrag();
					break;
				case Drag.Rotation:
					RotationOnMouseDrag();
					break;
			}
		}


		void OnMouseUp()
		{
			switch (DragType)
			{
				case Drag.Position:
					PositionOnMouseUp();
					break;
			}
		}


		void Update()
		{
			switch (DragType)
			{
				case Drag.Position:
					PositionUpdate();
					break;
			}
		}


		// Get pointer position in threshold space
		Vector2 GetPointerThreshold()
		{
			switch (ThresholdSpace)
			{
				case Space.World:
					return Camera.main.ScreenToWorldPoint(Input.mousePosition);
				case Space.Screen:
					return Input.mousePosition;
				case Space.Viewport:
					return Camera.main.ScreenToViewportPoint(Input.mousePosition);
			}
			throw new NotSupportedException();
		}


		// Check drag threshold
		bool PassedDragThreshold()
		{
			_pointerThreshold = GetPointerThreshold();
			if
			(
				UseDragThreshold && !_thresholdPassed
				&&
				(Mathf.Abs(_pointerThreshold.x - _pointerThresholdStart.x) < DragThreshold)
				&&
				(Mathf.Abs(_pointerThreshold.y - _pointerThresholdStart.y) < DragThreshold)
			)
				return false;
			else
			{
				_thresholdPassed = true;
				return true;
			}
		}


		// Keep physics and drag in sync
		bool IsInSync(ref bool currentFlag, ref bool otherFlag)
		{
			if (!otherFlag)
				return false;

			currentFlag = true;
			otherFlag = false;
			return true;
		}
	}
}
