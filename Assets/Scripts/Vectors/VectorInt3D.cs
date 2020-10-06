namespace Vectors
{
    public struct VectorInt3D
    {
        public int x;
        public int y;
        public int z;

        public VectorInt3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3D vector && Equals(vector);
        }

        public bool Equals(Vector3D vector)
        {
            return x.Equals(vector.x) && y.Equals(vector.y) && z.Equals(vector.z);
        }
        
        public override int GetHashCode()
        {
            int hashcode = (x * 6).GetHashCode();
            hashcode = hashcode + (y * 10).GetHashCode();
            hashcode = hashcode + (z * 2020).GetHashCode();
            
            return hashcode;
        }
    }
}