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
	public abstract class Position : Target
	{
		[Tooltip("A multiplier applied to the pointer movement while dragging.")]
		/// <summary>
		/// A multiplier applied to the pointer movement while dragging.
		/// </summary>
		public float DragSensitivity = 1.0f;

		[Tooltip("If true, the GameObject is centered on the pointer while dragging.")]
		/// <summary>
		/// If true, the GameObject is centered on the pointer while dragging.
		/// </summary>
		public bool CenterOnPointer = true;

		[Tooltip("If true, apply an offset to the GameObject's position while dragging.")]
		/// <summary>
		/// If true, apply an offset to the GameObject's position while dragging.
		/// </summary>
		public bool OffsetPosition = false;

		[Tooltip("The offset to apply to the GameObject's position while dragging.")]
		/// <summary>
		/// The offset to apply to the GameObject's position while dragging.  OffsetPosition must be true.
		/// </summary>
		public Vector2 PositionOffset;

		[Tooltip("The space that the position offset is measured in.")]
		/// <summary>
		/// The space that the position offset is measured in.  OffsetPosition must be true.
		/// </summary>
		public Space PositionOffsetSpace = Space.World;

		[Tooltip("If true, the GameObject's position will be clamped between minimum and maximum values.")]
		/// <summary>
		/// If true, the GameObject's position will be clamped between minimum and maximum values.
		/// </summary>
		public bool ClampPosition = false;

		[Tooltip("The minimum position of the GameObject.")]
		/// <summary>
		/// The minimum position of the GameObject.  ClampPosition must be true.
		/// </summary>
		public Vector2 PositionMinimum;

		[Tooltip("The maximum position of the GameObject.")]
		/// <summary>
		/// The maximum position of the GameObject.  ClampPosition must be true.
		/// </summary>
		public Vector2 PositionMaximum;

		[Tooltip("The space that the clamped position is measured in.")]
		/// <summary>
		/// The space that the clamped position is measured in.  ClampPosition must be true.
		/// </summary>
		public Space ClampSpace = Space.World;

		[Tooltip("If true, use target tracking for messages or drop validation.")]
		/// <summary>
		/// If true, use target tracking for messages or drop validation.
		/// </summary>
		public bool UseTargets = true;


		float _positionX;
		float _positionY;
		float _positionZ;
		Vector2 _positionOffset;
		Vector2 _positionClampMin;
		Vector2 _positionClampMax;
		Vector2 _pointerOffset;


		// Postion Start
		protected void PositionStart()
		{
			TargetStart();
		}


		// Position FixedUpdate
		protected void PositionFixedUpdate()
		{
			if (UseTargets)
				TargetFixedUpdate();
		}


		// Postion OnTriggerEnter2D
		protected void PositionOnTriggerEnter2D(Collider2D triggering)
		{
			if (UseTargets)
				TargetOnTriggerEnter2D(triggering);
		}


		// Postion OnTriggerStay2D
		protected void PositionOnTriggerStay2D(Collider2D triggering)
		{
			if (UseTargets)
				TargetOnTriggerStay2D(triggering);
		}


		// Position OnCollisionEnter2D
		protected void PositionOnCollisionEnter2D(Collision2D colliding)
		{
			if (UseTargets)
				TargetOnCollisionEnter2D(colliding);
		}


		// Position OnCollisionStay2D
		protected void PositionOnCollisionStay2D(Collision2D colliding)
		{
			if (UseTargets)
				TargetOnCollisionStay2D(colliding);
		}


		// Init drag position
		protected void PositionOnMouseDown()
		{
			// Get pointer offset for not centering on pointer
			if (!CenterOnPointer)
				_pointerOffset = transform.position - (Vector3)_pointerPositionWorld;

			// Get the position offset in world space
			if (OffsetPosition)
				_positionOffset = GetWorldPosition(new Vector2(PositionOffset.x, PositionOffset.y), PositionOffsetSpace);

			// Get the clamp limits in world space
			if (ClampPosition)
			{
				_positionClampMin = GetWorldPosition(new Vector2(PositionMinimum.x, PositionMinimum.y), ClampSpace);
				_positionClampMax = GetWorldPosition(new Vector2(PositionMaximum.x, PositionMaximum.y), ClampSpace);
			}

			// Save old position z
			if (!UseCurrentZ)
				_positionZStart = transform.position.z;

			if (UseTargets)
				TargetOnMouseDown();
		}


		// Process drag position
		protected void PositionOnMouseDrag()
		{
			// Get base coordinates
			_positionX = _pointerPositionWorld.x * DragSensitivity;
			_positionY = _pointerPositionWorld.y * DragSensitivity;

			// Set offset
			if (OffsetPosition)
			{
				_positionX += _positionOffset.x;
				_positionY += _positionOffset.y;
			}

			// Un-center from pointer
			if (!CenterOnPointer)
			{
				_positionX += _pointerOffset.x;
				_positionY += _pointerOffset.y;
			}

			// Clamp position
			if (ClampPosition)
			{
				_positionX = Mathf.Clamp(_positionX, _positionClampMin.x, _positionClampMax.x);
				_positionY = Mathf.Clamp(_positionY, _positionClampMin.y, _positionClampMax.y);
			}

			// Set Z
			if (UseCurrentZ)
				_positionZ = transform.position.z;
			else
				_positionZ = DragPositionZ;

			// Set positions
			transform.position = new Vector3(_positionX, _positionY, _positionZ);

			if (UseTargets)
				TargetOnMouseDrag();
		}


		// Complete drag position
		protected void PositionOnMouseUp()
		{
			if (UseTargets)
				TargetOnMouseUp();

			// Restore position z
			if (!UseCurrentZ)
				transform.position = new Vector3(transform.position.x, transform.position.y, _positionZStart);
		}


		// Position Update
		protected void PositionUpdate()
		{
			TargetUpdate();
		}
	}
}
