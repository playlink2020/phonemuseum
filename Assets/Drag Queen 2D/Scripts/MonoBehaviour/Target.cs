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
using System.Collections.Generic;
using UnityEngine;

namespace ChristopherCreates.DragQueen2D
{
	public abstract class Target : Message
	{
		// Position
		[Tooltip("If true, keep the GameObject's current Z position while dragging.")]
		/// <summary>
		/// If true, keep the GameObject's current Z position while dragging.
		/// </summary>
		public bool UseCurrentZ = true;

		[Tooltip("The Z position to be applied to the GameObject while dragging.")]
		/// <summary>
		/// The Z position to be applied to the GameObject while dragging.  UseCurrentZ must be false.
		/// </summary>
		public float DragPositionZ;

		// Filter targets
		[Tooltip("If true, only GameObjects which match the given filters will be valid.")]
		/// <summary>
		/// If true, only GameObjects which match the given filters will be valid.  UseTargets must be true.
		/// </summary>
		public bool FilterTargets = false;

		[Tooltip("If true, filter targets by their layer.")]
		/// <summary>
		/// If true, filter targets by their layer.  UseTargets and FilterTargets must be true.
		/// </summary>
		public bool ByLayer = false;

		[Tooltip("GameObjects must be on one of these layers to be valid targets.")]
		/// <summary>
		/// GameObjects must be on one of these layers to be valid targets.  UseTargets, FilterTargets, and ByLayer must be true.
		/// </summary>
		public LayerMask ValidLayers = -1;

		[Tooltip("If true, filter targets by their tag.")]
		/// <summary>
		/// If true, filter targets by their tag.  UseTargets and FilterTargets must be true.
		/// </summary>
		public bool ByTag = false;

		[Tooltip("GameObjects must have one of these tags to be valid targets.")]
		/// <summary>
		/// GameObjects must have one of these tags to be valid targets.  UseTargets, FilterTargets, and ByTag must be true.
		/// </summary>
		public string[] ValidTags = new string[] { };

		[Tooltip("If true, use wildcard tag matching.  *string to match any start, *string* to match any middle, string* to match any end.")]
		/// <summary>
		/// If true, use wildcard tag matching.  *string to match any start, *string* to match any middle, string* to match any end.  UseTargets, FilterTargets, and ByTag must be true.
		/// </summary>
		public bool UseTagWildcard = false;

		[Tooltip("If true, filter targets by their name.")]
		/// <summary>
		/// If true, filter targets by their name.  UseTargets and FilterTargets must be true.
		/// </summary>
		public bool ByName = false;

		[Tooltip("GameObjects must have one of these names to be valid targets.")]
		/// <summary>
		/// GameObjects must have one of these names to be valid targets.  UseTargets, FilterTargets, and ByName must be true.
		/// </summary>
		public string[] ValidNames = new string[] { };

		[Tooltip("If true, use wildcard name matching.  *string to match any start, *string* to match any middle, string* to match any end.")]
		/// <summary>
		/// If true, use wildcard name matching.  *string to match any start, *string* to match any middle, string* to match any end.  UseTargets, FilterTargets, and ByName must be true.
		/// </summary>
		public bool UseNameWildcard = false;

		// Target settings
		[Tooltip("If true, target 2D colliders with Is Trigger set to true.")]
		/// <summary>
		/// If true, target 2D colliders with IsTrigger set to true.  UseTargets must be true.
		/// </summary>
		public bool TargetTriggers = true;

		[Tooltip("If true, target 2D colliders with Is Trigger set to false.")]
		/// <summary>
		/// If true, target 2D colliders with IsTrigger set to false.  UseTargets must be true.
		/// </summary>
		public bool TargetCollisions = false;

		[Tooltip("If true, use casting to find targets.")]
		/// <summary>
		/// If true, use casting to find targets.  UseTargets must be true.
		/// </summary>
		public bool TargetCasting = false;

		// No target drop
		[Tooltip("If true, require a valid drop target to keep new position.")]
		/// <summary>
		/// If true, require a valid drop target to keep new position.  UseTargets must be true.
		/// </summary>
		public bool RequireDropTarget = true;

		[Tooltip("The type of return to apply to the GameObject if it lacks a valid drop target.")]
		/// <summary>
		/// The type of return to apply to the GameObject if it lacks a valid drop target.  UseTargets and RequireDropTarget must be true.
		/// </summary>
		public Return ReturnType = Return.Lerp;

		[Tooltip("The type of lerp return to use.")]
		/// <summary>
		/// The type of lerp return to use.  UseTargets and RequireDropTarget must be true, and ReturnType must be Return.Lerp.
		/// </summary>
		public Lerp ReturnLerpType = Lerp.Time;

		[Tooltip("The speed of the return lerp in distance per second.")]
		/// <summary>
		/// The speed of the return lerp in distance per second.  UseTargets and RequireDropTarget must be true, ReturnType must be Return.Lerp, and ReturnLerpType must be Lerp.Speed.
		/// </summary>
		public float ReturnLerpSpeed = 20.0f;

		[Tooltip("The space that the return lerp speed is measured in.")]
		/// <summary>
		/// The space that the return lerp speed is measured in.  UseTargets and RequireDropTarget must be true, ReturnType must be Return.Lerp, and ReturnLerpType must be Lerp.Speed.
		/// </summary>
		public Space ReturnLerpSpace = Space.World;

		[Tooltip("The duration in seconds for the return lerp.")]
		/// <summary>
		/// The duration in seconds for the return lerp.  UseTargets and RequireDropTarget must be true, ReturnType must be Return.Lerp, and ReturnLerpType must be Lerp.Time.
		/// </summary>
		public float ReturnLerpDuration = 0.25f;

		[Tooltip("The message to send for the return.  The GameObject start position will be sent as the message value.")]
		/// <summary>
		/// The message to send for the return.  The GameObject start position will be sent as the message value.  UseTargets and RequireDropTarget must be true, and ReturnType must be Return.Message.
		/// </summary>
		public string DropNoTargetMessage = "OnDropNoTarget";

		[Tooltip("If true, the return message will be sent upwards through the parent hierarchy.")]
		/// <summary>
		/// If true, the return message will be sent upwards through the parent hierarchy.  UseTargets and RequireDropTarget must be true, and ReturnType must be Return.Message.
		/// </summary>
		public bool SendDropNoTargetUpwards = false;

		[Tooltip("The space that the start position return message value will be measured in.")]
		/// <summary>
		/// The space that the start position return message value will be measured in.  UseTargets and RequireDropTarget must be true, and ReturnType must be Return.Message.
		/// </summary>
		public Space DropNoTargetValueSpace = Space.World;

		// Cast directions
		[Tooltip("If true, cast for targets in the selected cardinal directions.")]
		/// <summary>
		/// If true, cast for targets in the selected cardinal directions.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool CastCardinal = false;

		[Tooltip("If true, cast up (+y) for targets.")]
		/// <summary>
		/// If true, cast up (+y) for targets.  UseTargets, TargetCasting, and CastCardinal must be true.
		/// </summary>
		public bool CastUp = true;

		[Tooltip("If true, cast down (-y) for targets.")]
		/// <summary>
		/// If true, cast down (-y) for targets.  UseTargets, TargetCasting, and CastCardinal must be true.
		/// </summary>
		public bool CastDown = true;

		[Tooltip("If true, cast left (-x) for targets.")]
		/// <summary>
		/// If true, cast left (-x) for targets.  UseTargets, TargetCasting, and CastCardinal must be true.
		/// </summary>
		public bool CastLeft = true;

		[Tooltip("If true, cast right (+x) for targets.")]
		/// <summary>
		/// If true, cast right (+x) for targets.  UseTargets, TargetCasting, and CastCardinal must be true.
		/// </summary>
		public bool CastRight = true;

		[Tooltip("If true, cast for targets in the selected diagonal directions.")]
		/// <summary>
		/// If true, cast for targets in the selected diagonal directions.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool CastDiagonal = false;

		[Tooltip("If true, cast up and left (-x,+y) for targets.")]
		/// <summary>
		/// If true, cast up and left (-x,+y) for targets.  UseTargets, TargetCasting, and CastDiagonal must be true.
		/// </summary>
		public bool CastUpLeft = true;

		[Tooltip("If true, cast up and right (+x,+y) for targets.")]
		/// <summary>
		/// If true, cast up and right (+x,+y) for targets.  UseTargets, TargetCasting, and CastDiagonal must be true.
		/// </summary>
		public bool CastUpRight = true;

		[Tooltip("If true, cast down and left (-x,-y) for targets.")]
		/// <summary>
		/// If true, cast down and left (-x,-y) for targets.  UseTargets, TargetCasting, and CastDiagonal must be true.
		/// </summary>
		public bool CastDownLeft = true;

		[Tooltip("If true, cast down and right (+x,-y) for targets.")]
		/// <summary>
		/// If true, cast down and right (+x,-y) for targets.  UseTargets, TargetCasting, and CastDiagonal must be true.
		/// </summary>
		public bool CastDownRight = true;

		[Tooltip("If true, cast for targets in the given directions.")]
		/// <summary>
		/// If true, cast for targets in the given directions.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool CastCustom = false;

		[Tooltip("The custom directions to cast for targets.")]
		/// <summary>
		/// The custom directions to cast for targets.  UseTargets, TargetCasting, and CastCustom must be true.
		/// </summary>
		public Vector2[] CustomCasts = new Vector2[] { };

		// Cast settings
		[Tooltip("The position to begin the casting.")]
		/// <summary>
		/// The position to begin the casting from.  UseTargets and TargetCasting must be true.
		/// </summary>
		public Origin CastFrom = Origin.GameObjectCenter;

		[Tooltip("If true, add the given distance to the cast from position.")]
		/// <summary>
		/// If true, add the given distance to the cast from position.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool AddFromDistance = false;

		[Tooltip("The distance to add to the cast from position.")]
		/// <summary>
		/// The distance to add to the cast from position.  UseTargets, TargetCasting, and AddFromDistance must be true.
		/// </summary>
		public float CastFromDistance = 1.0f;

		[Tooltip("The space that the cast from distance is measured in.")]
		/// <summary>
		/// The space that the cast from distance is measured in.  UseTargets, TargetCasting, and AddFromDistance must be true.
		/// </summary>
		public Space FromDistanceSpace = Space.World;

		[Tooltip("The shape to use when casting for targets.")]
		/// <summary>
		/// The shape to use when casting for targets.  UseTargets and TargetCasting must be true.
		/// </summary>
		public Shape CastShape = Shape.Ray;

		[Tooltip("The angle to apply to the box when casting for targets.")]
		/// <summary>
		/// The angle to apply to the box when casting for targets.  UseTargets and TargetCasting must be true, and CastShape must be Shape.Box.
		/// </summary>
		public float BoxAngle = 0;

		[Tooltip("The type of size to apply to the cast shape.")]
		/// <summary>
		/// The type of size to apply to the cast shape.  UseTargets and TargetCasting must be true.
		/// </summary>
		public Size ShapeSizeType = Size.Normalized;

		[Tooltip("The size of the box to cast for targets.")]
		/// <summary>
		/// The size of the box to cast for targets.  UseTargets and TargetCasting must be true, and CastShape must be Shape.Box.
		/// </summary>
		public Vector2 BoxSize = new Vector2(1, 1);

		[Tooltip("The radius of the circle to cast for targets.")]
		/// <summary>
		/// The radius of the circle to cast for targets.  UseTargets and TargetCasting must be true, and CastShape must be Shape.Circle.
		/// </summary>
		public float CircleRadius = 0.5f;

		[Tooltip("The space that the cast shape size is measured in.")]
		/// <summary>
		/// The space that the cast shape size is measured in.  UseTargets and TargetCasting must be true, and ShapeSizeType must be Size.Fixed.
		/// </summary>
		public Space ShapeSpace = Space.World;

		[Tooltip("If true, cast directions are relative to the GameObject's local rotation.  If false, cast directions are fixed in world space.")]
		/// <summary>
		/// If true, cast directions are relative to the GameObject's local rotation.  If false, cast directions are fixed in world space.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool CastLocalSpace = true;

		[Tooltip("If true, offset the cast origin by the given amount.")]
		/// <summary>
		/// If true, offset the cast origin by the given distance.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool OffsetCast = false;

		[Tooltip("The distance to offset the cast origin by.")]
		/// <summary>
		/// The distance to offset the cast origin by.  UseTargets, TargetCasting, and OffsetCast must be true.
		/// </summary>
		public Vector2 CastOffset = new Vector2();

		[Tooltip("The space to measure the cast offset in.")]
		/// <summary>
		/// The space to measure the cast offset in.  UseTargets, TargetCasting, and OffsetCast must be true.
		/// </summary>
		public Space CastOffsetSpace = Space.World;

		[Tooltip("If true, limit the distance that targets are cast for.")]
		/// <summary>
		/// If true, limit the distance that targets are cast for.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool LimitDistance;

		[Tooltip("The distance to cast for targets.")]
		/// <summary>
		/// The distance to cast for targets.  UseTargets, TargetCasting, and LimitDistance must be true.
		/// </summary>
		public float TargetDistance = 10.0f;

		[Tooltip("The space to measure the cast distance in.")]
		/// <summary>
		/// The space to measure the cast distance in.  UseTargets, TargetCasting, and LimitDistance must be true.
		/// </summary>
		public Space DistanceSpace = Space.World;


		[Tooltip("If true, draw debug lines in the scene view to show the target casting.")]
		/// <summary>
		/// If true, draw debug lines in the scene view to show the target casting.  UseTargets and TargetCasting must be true.
		/// </summary>
		public bool DrawDebugLines = false;


		[Tooltip("If true, send messages to targets.")]
		/// <summary>
		/// If true, send messages to targets.  UseTargets must be true.
		/// </summary>
		public bool SendMessages = true;


		protected const string _logPrefix = "Drag Queen 2D: ";


		protected Vector3 _pointerPositionWorld;
		protected float _positionZStart;
		protected Rigidbody2D _rigidbody2D;

		RigidbodySleepMode2D _rigidbody2DSleepMode;

		TargetCast[] _targetCasts;
		RaycastHit2D[] _targetsHit;
		int _targetsCastingCount;
		Vector3 _positionWorldStart;
		float _toDistanceWorld;
		LayerMask _targetLayerMask;
		bool _colliderState;
		int _indexCast;
		int _indexTarget;
		protected Collider2D _collider;

		bool _isReturning = false;
		Vector3 _lerpPositionStart;
		Vector3 _lerpPositionEnd;
		float _lerpTimeStart;
		float _lerpTimeDuration;


		// Target Start
		protected void TargetStart()
		{
			// Init target lists
			_targets = new GameObject[MaximumTargets];
			_targetsHit = new RaycastHit2D[MaximumTargets];

			if (SendMessages)
				MessageStart();
		}


		// Target FixedUpdate
		protected void TargetFixedUpdate()
		{
			// Init targets
			_targetCount = 0;
		}


		// Target OnTriggerEnter2D
		protected void TargetOnTriggerEnter2D(Collider2D triggering)
		{
			if (TargetTriggers)
				AddTarget(triggering.gameObject);
		}


		// Target OnTriggerStay2D
		protected void TargetOnTriggerStay2D(Collider2D triggering)
		{
			if (TargetTriggers)
				TargetOnTriggerEnter2D(triggering);
		}


		// Target OnCollisionEnter2D
		protected void TargetOnCollisionEnter2D(Collision2D colliding)
		{
			if (TargetCollisions)
				if (TargetCollisions)
					AddTarget(colliding.gameObject);
		}


		// Target OnCollisionStay2D
		protected void TargetOnCollisionStay2D(Collision2D colliding)
		{
			if (TargetCollisions)
				TargetOnCollisionEnter2D(colliding);
		}


		// Target OnMouseDown
		protected void TargetOnMouseDown()
		{
			// Keep rigidbody awake
			if (TargetTriggers || TargetCollisions)
			{
				_rigidbody2DSleepMode = _rigidbody2D.sleepMode;
				_rigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
			}

			// Cache pointer position start
			_positionWorldStart = gameObject.transform.position;

			// Set up casting
			if (TargetCasting)
				CastingSetup();

			if (SendMessages)
				MessageOnMouseDown();
		}


		// Target OnMouseDrag
		protected void TargetOnMouseDrag()
		{
			// Cast for message targets
			if (TargetCasting)
				CastForTargets();

			if (SendMessages)
				MessageOnMouseDrag();
		}


		// Target OnMouseUp
		protected void TargetOnMouseUp()
		{
			// Cast for drop targets
			if (TargetCasting)
				CastForTargets();

			// Send messages
			if (SendMessages)
				MessageOnMouseUp();

			// No target return
			if (_targetCount == 0 && RequireDropTarget)
				NoTargetReturn();

			// Restore rigidbody sleep state
			if (TargetTriggers || TargetCollisions)
				_rigidbody2D.sleepMode = _rigidbody2DSleepMode;

			// Reset target counter
			_targetCount = 0;
		}


		// Target Update
		protected void TargetUpdate()
		{
			if (_isReturning)
				LerpReturn();
		}


		// Get world position from space position
		protected Vector3 GetWorldPosition(Vector2 spacePosition, Space spaceType)
		{
			switch (spaceType)
			{
				case Space.Screen:
					return Camera.main.ScreenToWorldPoint(spacePosition);
				case Space.Viewport:
					return Camera.main.ViewportToWorldPoint(spacePosition);
				case Space.World:
					return spacePosition;
			}
			throw new NotSupportedException();
		}


		// Add a target
		void AddTarget(GameObject target)
		{
			// Check if target already present
			if (FindTarget(target) != -1)
				return;

			// Filter target
			if (FilterTargets)
			{
				if (ByLayer && (_targetLayerMask.value & (1 << target.layer)) <= 0)
					return;
				if (ByTag && !CheckTargetString(target, target.tag, ValidTags, UseTagWildcard))
					return;
				if (ByName && !CheckTargetString(target, target.name, ValidNames, UseNameWildcard))
					return;
			}

			// Add target
			if (_targetCount > _targets.Length)
				throw new InvalidOperationException(_logPrefix + "Targets exceeded \"Maximum Targets\"");
			_targets[_targetCount] = target;
			_targetCount++;
		}


		// Build cast list
		void BuildCastList(Vector2 offset, float toDistance, LayerMask layerMask, Origin from, float fromDistance, float circleRadius, Vector2 boxSize, float boxAngle)
		{
			// Build directions
			var directions = new List<Vector2>();

			// Add cardinal
			if (CastCardinal)
			{
				if (CastUp)
					directions.Add(Vector2.up);
				if (CastDown)
					directions.Add(new Vector2(0, -1));
				if (CastLeft)
					directions.Add(new Vector2(-1, 0));
				if (CastRight)
					directions.Add(Vector2.right);
			}

			// Add diagonal
			if (CastDiagonal)
			{
				if (CastUpLeft)
					directions.Add(Vector2.up + new Vector2(-1, 0));
				if (CastUpRight)
					directions.Add(Vector2.up + Vector2.right);
				if (CastDownLeft)
					directions.Add(new Vector2(0, -1) + new Vector2(-1, 0));
				if (CastDownRight)
					directions.Add(new Vector2(0, -1) + Vector2.right);
			}

			// Add custom
			if (CustomCasts.Length > 0)
				directions.AddRange(CustomCasts);

			// Build casts
			var targetCasts = new List<TargetCast>();
			switch (CastShape)
			{
				case Shape.Box:
					foreach (var direction in directions)
						targetCasts.Add(new TargetCast(gameObject, offset, CastLocalSpace, direction, toDistance, layerMask, from, _collider, MaximumTargets, AddFromDistance, fromDistance, boxSize, boxAngle));
					break;
				case Shape.Circle:
					foreach (var direction in directions)
						targetCasts.Add(new TargetCast(gameObject, offset, CastLocalSpace, direction, toDistance, layerMask, from, _collider, MaximumTargets, AddFromDistance, fromDistance, circleRadius));
					break;
				case Shape.Ray:
					foreach (var direction in directions)
						targetCasts.Add(new TargetCast(gameObject, offset, CastLocalSpace, direction, toDistance, layerMask, from, _collider, MaximumTargets, AddFromDistance, fromDistance));
					break;
				default:
					throw new NotSupportedException();
			}
			_targetCasts = targetCasts.ToArray();
		}


		// Find casting targets
		void CastForTargets()
		{
			// Check casting
			if (!TargetCasting)
				return;

			// Disable the local collider
			_colliderState = _collider.enabled;
			_collider.enabled = false;

			// Cast
			for (_indexCast = 0; _indexCast < _targetCasts.Length; _indexCast++)
			{
				_targetsCastingCount = _targetCasts[_indexCast].Cast(_targetsHit, DrawDebugLines);

				// Get targets
				for (_indexTarget = 0; _indexTarget < _targetsCastingCount; _indexTarget++)
					AddTarget(_targetsHit[_indexTarget].transform.gameObject);
			}

			// Restore the local collider state
			_collider.enabled = _colliderState;
		}


		// Set up casting values
		void CastingSetup()
		{
			// Check casting
			if (!TargetCasting)
				return;

			// Get offset
			Vector2 offsetWorld;
			if (OffsetCast)
				offsetWorld = GetWorldPosition(CastOffset, CastOffsetSpace);
			else
				offsetWorld = new Vector2(0, 0);

			// Get to distance
			if (LimitDistance)
				_toDistanceWorld = GetWorldPosition(new Vector2(TargetDistance, 0), DistanceSpace).x;
			else
				_toDistanceWorld = Mathf.Infinity;

			// Get from distance
			float fromDistanceWorld = 0.0f;
			if (AddFromDistance)
				fromDistanceWorld = GetWorldPosition(new Vector2(CastFromDistance, 0), FromDistanceSpace).x;

			// Get layer mask
			if (ByLayer)
				_targetLayerMask = ValidLayers;
			else
				_targetLayerMask = -1;

			// Get shape sizes
			Vector2 boxSize = new Vector2();
			float circleRadius = -1.0f;
			Vector3 boundsSize = new Vector3();
			if (CastShape != Shape.Ray)
				boundsSize = GetComponent<Renderer>().bounds.size;

			switch (CastShape)
			{
				// Get box size
				case Shape.Box:
					if (ShapeSizeType == Size.Fixed)
						boxSize = GetWorldPosition(BoxSize, ShapeSpace);
					else
						boxSize = new Vector2(boundsSize.x * BoxSize.x, boundsSize.y * BoxSize.y);
					break;

				// Get circle radius
				case Shape.Circle:
					if (ShapeSizeType == Size.Fixed)
						circleRadius = GetWorldPosition(new Vector2(CircleRadius, 0), ShapeSpace).x;
					else
					{
						var _boundsX = boundsSize.x * BoxSize.x;
						var _boundsY = boundsSize.y * BoxSize.y;
						if (_boundsX > _boundsY)
							circleRadius = _boundsX / 2;
						else
							circleRadius = _boundsY / 2;
					}
					break;

				// Nothing needed for ray
				case Shape.Ray:
					break;

				default:
					throw new NotSupportedException();
			}

			// Build raycast list
			BuildCastList(offsetWorld, _toDistanceWorld, _targetLayerMask, CastFrom, fromDistanceWorld, circleRadius, boxSize, BoxAngle);
		}


		// Check a string
		bool CheckTargetString(GameObject target, string property, string[] validStrings, bool useWildcard)
		{
			if (useWildcard)
			{
				foreach (var validString in validStrings)
					if (MatchWildcard(property, validString))
						return true;
			}
			else
			{
				foreach (var validString in validStrings)
					if (property == validString)
						return true;
			}
			return false;
		}


		// Get position in a specified space from world space
		Vector3 GetUnworldPosition(Vector3 worldPosition, Space space)
		{
			switch (space)
			{
				case Space.Screen:
					return Camera.main.WorldToScreenPoint(worldPosition);
				case Space.World:
					return worldPosition;
				case Space.Viewport:
					return Camera.main.WorldToViewportPoint(worldPosition);
			}
			throw new NotSupportedException();
		}


		// Lerp return
		void LerpReturn()
		{
			// Update position
			gameObject.transform.position = Vector3.Lerp(_lerpPositionStart, _lerpPositionEnd, (Time.time - _lerpTimeStart) / _lerpTimeDuration);

			// Finish return
			if (gameObject.transform.position == _lerpPositionEnd)
			{
				_isReturning = false;
				_collider.enabled = _colliderState;
				transform.position = _positionWorldStart;
			}
		}


		// Match a string with a filter
		bool MatchWildcard(string target, string filter)
		{
			// If empty target, no match
			if (string.IsNullOrEmpty(target))
				return false;

			// If empty filter, always match
			if (string.IsNullOrEmpty(filter))
				return true;

			// Search with start and end * wildcard
			if (filter.StartsWith("*"))
			{
				if (filter.EndsWith("*"))
					return target.Contains(filter.Trim('*'));
				else
					return target.EndsWith(filter.Trim('*'));
			}
			else
			{
				if (filter.EndsWith("*"))
					return target.StartsWith(filter.Trim('*'));
				else
					return target.Contains(filter);
			}
		}


		// Return to origin if no drop target
		void NoTargetReturn()
		{
			switch (ReturnType)
			{
				case Return.Snap:
					gameObject.transform.position = _positionWorldStart;
					break;

				case Return.Lerp:
					_isReturning = true;
					_colliderState = _collider.enabled;
					_collider.enabled = false;
					_lerpTimeStart = Time.time;
					_lerpPositionStart = gameObject.transform.position;

					if (UseCurrentZ)
						_lerpPositionEnd = _positionWorldStart;
					else
						_lerpPositionEnd = new Vector3(_positionWorldStart.x, _positionWorldStart.y, DragPositionZ);

					if (ReturnLerpType == Lerp.Speed)
						_lerpTimeDuration = Vector2.Distance(GetUnworldPosition(_lerpPositionStart, ReturnLerpSpace), GetUnworldPosition(_lerpPositionEnd, ReturnLerpSpace)) / ReturnLerpSpeed;
					else
						_lerpTimeDuration = ReturnLerpDuration;
					break;

				case Return.Message:
					var startPosition = GetUnworldPosition(_positionWorldStart, DropNoTargetValueSpace);
					if (SendDropNoTargetUpwards)
						SendMessageUpwards(DropNoTargetMessage, startPosition);
					else
						SendMessage(DropNoTargetMessage, startPosition);
					break;
			}
		}
	}
}
