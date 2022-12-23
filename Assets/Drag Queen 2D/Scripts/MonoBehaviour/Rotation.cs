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
	public abstract class Rotation : Position
	{
		[Tooltip("If true, clamp the rotation between given minimum and maximum values.")]
		/// <summary>
		/// If true, clamp the rotation between given minimum and maximum values.
		/// </summary>
		public bool ClampRotation = false;

		[Tooltip("The minimum allowed rotation.")]
		/// <summary>
		/// The minimum allowed rotation.  ClampRotation must be true.
		/// </summary>
		public float RotationMinimum;

		[Tooltip("The maximum allowed rotation.")]
		/// <summary>
		/// The maximum allowed rotation.  ClampRotation must be true.
		/// </summary>
		public float RotationMaximum;


		float _rotation;
		float _rotationStart;
		float _rotationClampOpposite;


		// Rotation OnMouseDown
		protected void RotationOnMouseDown()
		{
			_rotationStart = GetPointerRotation(transform.eulerAngles.z);

			if (ClampRotation)
				_rotationClampOpposite = Mathf.Repeat((Mathf.Repeat(RotationMaximum - RotationMinimum, 360) / 2) + RotationMinimum + 180, 360);
		}


		// Rotation OnMouseDrag
		protected void RotationOnMouseDrag()
		{
			// Get base rotation
			_rotation = GetPointerRotation(_rotationStart);

			// Clamp rotation
			if (ClampRotation && !InAngleRange(_rotation, RotationMinimum, RotationMaximum))
			{
				if (!InAngleRange(_rotation, RotationMinimum, _rotationClampOpposite))
					_rotation = RotationMinimum;
				else
					_rotation = RotationMaximum;
			}

			// Set rotation
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _rotation);
		}


		// Get the current rotation relative to the pointer position
		float GetPointerRotation(float offset)
		{
			return (Quaternion.LookRotation(transform.position - _pointerPositionWorld, Vector3.forward).eulerAngles.z * DragSensitivity) - offset;
		}


		// Tests angle in range
		bool InAngleRange(float angle, float minimum, float maximum)
		{
			if (maximum > minimum)
			{
				if (angle >= minimum && angle <= maximum)
					return true;
				else
					return false;
			}
			else
			{
				if (angle <= maximum || angle >= minimum)
					return true;
				else
					return false;
			}
		}
	}
}
