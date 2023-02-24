namespace Extensions
{
    public static class Double
    {
        static Double()
        {

        }

        public static double ToMillionRials(this double value)
        {
            
            return (double)value/1000000;
        }
    }
}
