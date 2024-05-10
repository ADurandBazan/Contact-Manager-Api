using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Common.Utilities
{
    /// <summary>
    /// A static class containing common helper methods.
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Calculates the age of a person given their date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth of the person.</param>
        /// <returns>The age of the person.</returns>
        public static int GetAge(DateTime dateOfBirth)
        {
            // Get the current date as a DateOnly object
            var today = DateOnly.FromDateTime(DateTime.Today);

            // Calculate the age based on the difference between the current year and the year of birth
            var age = today.Year - dateOfBirth.Year;

            // If the current month and day are before the month and day of birth, subtract one from the age
            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Checks if a given date is a valid date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the date is valid, false otherwise.</returns>
        public static bool IsAValidDate(DateTime date)
        {
            // Check if the date is not the default value and has a year between 1 and 9999
            return date != default(DateTime) && date.Year >= 1 && date.Year <= 9999;
        }
    }
}
