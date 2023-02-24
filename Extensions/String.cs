namespace Extensions
{
    public static class String
    {
        static String()
        {

        }
        //
        // Summary:
        //     Returns this instance of System.String; Fix format of String.
        //
        // Returns:
        //     Fix format of String.
        public static string Fix(this string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            text = text.Trim();

            if (text == string.Empty)
            {
                return string.Empty;
            }

            while (text.Contains("  "))
            {
                text =
                    text.Replace("  ", " ");
            }

            return text;
        }
    }
}
