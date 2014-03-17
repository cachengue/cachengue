namespace System
{
    /// <summary>
    /// This class is used to round the time to X minutes.
    /// For example, 1:06:05 would be rounded to 1:00:00 if the rounding factor were 15 mins,
    /// and 1:16:05 would be rounded to 1:15:00.
    /// </summary>
    internal static class RoundTime
    {
        /// <summary>
        /// Rounds the specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="roundingInterval">The rounding interval.</param>
        /// <param name="roundingType">Type of the rounding.</param>
        /// <returns>A rounded TimeSpan</returns>
        public static TimeSpan Round(this TimeSpan time, TimeSpan roundingInterval, MidpointRounding roundingType)
        {
            return new TimeSpan(Convert.ToInt64(Math.Round(time.Ticks / (decimal)roundingInterval.Ticks, roundingType)) * roundingInterval.Ticks);
        }

        /// <summary>
        /// Rounds the specified time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="roundingInterval">The rounding interval.</param>
        /// <returns>A rounded TimeSpan</returns>
        public static TimeSpan Round(this TimeSpan time, TimeSpan roundingInterval)
        {
            return Round(time, roundingInterval, MidpointRounding.ToEven);
        }

        /// <summary>
        /// Rounds the specified datetime.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <param name="roundingInterval">The rounding interval.</param>
        /// <returns>A rounded DateTime</returns>
        public static DateTime Round(this DateTime datetime, TimeSpan roundingInterval)
        {
            if (datetime == null || datetime.Equals(DateTime.MinValue) || datetime.Equals(DateTime.MaxValue))
            {
                return datetime;
            }

            return new DateTime((datetime - DateTime.MinValue).Round(roundingInterval).Ticks);
        }
    }
}
