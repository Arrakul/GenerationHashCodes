using UnityEngine;
 
 namespace Vectors
{ 
    public struct Vector2D
    {
        private const float AccuracyForHash = 1E6f + 1;

        public float x;
        public float y;
    
        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector2D vector && Equals(vector);
        }

        public bool Equals(Vector2D vector)
        {
            return x.Equals(vector.x) && y.Equals(vector.y);
        }
    
        public override int GetHashCode()
        {
            int hashcode = ((int)Mathf.Sqrt((x * AccuracyForHash))).GetHashCode();
            hashcode =  hashcode * 1024 + ((int) (Mathf.Sqrt((y * AccuracyForHash)))).GetHashCode();

            return hashcode;
        }
    }
}