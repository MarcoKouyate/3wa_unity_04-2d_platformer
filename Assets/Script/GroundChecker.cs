using UnityEngine;

namespace Dwarf
{
    public class GroundChecker : MonoBehaviour
    {
        #region Show in inspector

        [SerializeField] private Transform _topLeft;
        [SerializeField] private Transform _bottomRight;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Color _gizmosColor;

        #endregion


        #region Public

        public bool IsGrounded()
        {
            return _isGrounded;
        }

        #endregion


        #region Ground check

        private void Update()
        {
            CheckGround();
        }

        private void CheckGround()
        {
            _isGrounded = Physics2D.OverlapArea(_topLeft.position, _bottomRight.position, _whatIsGround) != null;
        }

        #endregion


        #region Gizmos

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;

            Vector2 topLeft = _topLeft.position;
            Vector2 topRight = new Vector2(_bottomRight.position.x, _topLeft.position.y);
            Vector2 bottomRight = _bottomRight.position;
            Vector2 bottomLeft = new Vector2(_topLeft.position.x, _bottomRight.position.y);

            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }


        #endregion


        #region Private

        private bool _isGrounded;

        #endregion
    }
}

