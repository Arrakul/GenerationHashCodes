namespace Vectors
{
    public struct VectorInt2D
    {
        public int x;
        public int y;

        public VectorInt2D(int x, int y)
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
            int hashcode = (x * 6 + 10).GetHashCode(); 
            hashcode = hashcode + (y * 2020).GetHashCode();

            return hashcode;
        }
    }
}