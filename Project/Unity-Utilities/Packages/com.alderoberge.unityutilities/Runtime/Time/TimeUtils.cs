using System.Text;

namespace AldeRoberge.UnityUtilities.Time
{
    public static class TimeUtils
    {
        public static string ToHumanReadableTime(this float seconds)
        {
            return ConvertToTime(seconds);
        }

        public static string ConvertToTime(float inputValue)
        {
            if (inputValue == 0)
                return "Now";

            int totalMilliseconds = (int)(inputValue * 1000);
            int minutes = totalMilliseconds / 60000;
            int seconds = totalMilliseconds % 60000 / 1000;
            int milliseconds = totalMilliseconds % 1000;

            StringBuilder resultBuilder = new StringBuilder();

            if (minutes > 0) resultBuilder.Append($"{minutes} minutes ");
            if (seconds > 0) resultBuilder.Append($"{seconds} seconds ");
            if (milliseconds > 0) resultBuilder.Append($"{milliseconds} milliseconds");

            return resultBuilder.ToString().Trim();
        }
    }
}