namespace AldeRoberge.UnityUtilities
{
    public static class DebugColorUtil
    {
        public static string Colorize(this string text, string color = "orange", bool bold = true, bool italic = false)
        {
            return
                "<color=" + color + ">" + Stylise(text, bold, italic) + "</color>";
        }
        
        public static string Bold(this string text)
        {
            return Stylise(text, true, false);
        }

        public static string Italic(this string text)
        {
            return Stylise(text, false, true);
        }

        public static string Stylise(this string text, bool bold = false, bool italic = false)
        {
            return
                (bold ? "<b>" : "") +
                (italic ? "<i>" : "") +
                text +
                (bold ? "</b>" : "") +
                (italic ? "</i>" : "");
        }
    }
}