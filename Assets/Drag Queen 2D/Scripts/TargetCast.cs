using System;
using UnityEngine;

namespace ChristopherCreates.DragQueen2D
{
	public class TargetCast
	{
		GameObject _source;
		Vector2 _offset;
		Vector2 _direction;
		float _toDistance;
		LayerMask _layerMask;
		Origin _from;
		Collider2D _collider2D;
		bool _addFromDistance;
		float _fromDistance;

		Shape _shape;
		Vector2 _origin;

		Vector2 _boxSize;
		float _boxAngle;
		float _circleRadius;

		Vector2 _colliderCenter;
		Vector2 _castStart;
		RaycastHit2D[] _edgeHits;
		int _index;
		Ray2D _ray2D;

		float _debugDistance;


		public TargetCast(GameObject source, Vector2 offset, bool castLocalSpace, Vector2 direction, float toDistance, LayerMask layerMask, Origin from, Collider2D collider2D, int maximumTargets, bool addFromDistance, float fromDistance)
		{
			_source = source;
			_offset = offset;
			if (castLocalSpace)
				_direction = _source.transform.TransformDirection(direction);
			else
				_direction = direction;
			_toDistance = toDistance;
			_layerMask = layerMask;
			_from = from;
			_collider2D = collider2D;
			_addFromDistance = addFromDistance;
			_fromDistance = fromDistance;

			_edgeHits = new RaycastHit2D[maximumTargets];

			_shape = Shape.Ray;
		}


		public TargetCast(GameObject source, Vector2 offset, bool castLocalSpace, Vector2 direction, float toDistance, LayerMask layerMask, Origin from, Collider2D collider2D, int maximumTargets, bool addFromDistance, float fromDistance, Vector2 boxSize, float boxAngle) :
			this(source, offset, castLocalSpace, direction, toDistance, layerMask, from, collider2D, maximumTargets, addFromDistance, fromDistance)
		{
			_shape = Shape.Box;
			_boxSize = boxSize;
			_boxAngle = boxAngle;
		}


		public TargetCast(GameObject source, Vector2 offset, bool castLocalSpace, Vector2 direction, float toDistance, LayerMask layerMask, Origin from, Collider2D collider2D, int maximumTargets, bool addFromDistance, float fromDistance, float circleRadius) :
			this(source, offset, castLocalSpace, direction, toDistance, layerMask, from, collider2D, maximumTargets, addFromDistance, fromDistance)
		{
			_shape = Shape.Circle;
			_circleRadius = circleRadius;
		}


		public int Cast(RaycastHit2D[] hits, bool debug)
		{
			// Get origin
			_origin = _offset;
			switch (_from)
			{
				case Origin.GameObjectCenter:
					_origin += (Vector2)_source.transform.position;
					break;

				case Origin.ColliderCenter:
					_origin += (Vector2)_collider2D.transform.position + _collider2D.offset;
					break;

				case Origin.ColliderEdge:
					_collider2D.enabled = true;
					_colliderCenter = (Vector2)_collider2D.transform.position + _collider2D.offset;
					_ray2D = new Ray2D(_colliderCenter, _direction);
					_castStart = _ray2D.GetPoint(_collider2D.bounds.size.x + _collider2D.bounds.size.y);
					_edgeHits = Physics2D.RaycastAll(_castStart, _colliderCenter - _castStart, Vector2.Distance(_castStart, _colliderCenter));
					for (_index = 0; _index < _edgeHits.Length; _index++)
						if (_edgeHits[_index].collider.gameObject == _source)
						{
							_origin += _edgeHits[_index].point;
							break;
						}
					_collider2D.enabled = false;
					break;

				default:
					throw new NotSupportedException();
			}
			if (_addFromDistance)
			{
				_ray2D = new Ray2D(_origin, _direction);
				_origin = _ray2D.GetPoint(_fromDistance);
			}

			// Debug
			if (debug)
			{
				if (_toDistance == Mathf.Infinity)
					_debugDistance = 9999;
				else
					_debugDistance = _toDistance;
				_ray2D = new Ray2D(_origin, _direction);
				Debug.DrawLine(_origin, _ray2D.GetPoint(_debugDistance), Color.yellow);
			}

			// Cast
			switch (_shape)
			{
				case Shape.Box:
					return Physics2D.BoxCastNonAlloc(_origin, _boxSize, _boxAngle, _direction, hits, _toDistance, _layerMask);
				case Shape.Circle:
					return Physics2D.CircleCastNonAlloc(_origin, _circleRadius, _direction, hits, _toDistance, _layerMask);
				case Shape.Ray:
					return Physics2D.RaycastNonAlloc(_origin, _direction, hits, _toDistance, _layerMask);
			}
			throw new NotSupportedException();
		}
	}
}
