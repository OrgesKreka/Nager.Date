using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cyprus HolidayProvider
    /// </summary>
    internal sealed class CyprusHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Cyprus HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public CyprusHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CY;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Πρωτοχρονιά",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Θεοφάνεια",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 25),
                    EnglishName = "Greek Independence Day",
                    LocalName = "Επέτειος Ελληνικής Ανεξαρτησίας",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 1),
                    EnglishName = "Cyprus National Day",
                    LocalName = "Κυπριακή Εθνική Επέτειος",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Πρωτομαγιά",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption of the Virgin Mary",
                    LocalName = "Η Κοίμησις της Θεοτόκου",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "Cyprus Independence Day",
                    LocalName = "Επέτειος Κυπριακής Ανεξαρτησίας",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 28),
                    EnglishName = "Ohi Day",
                    LocalName = "Το Όχι",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Παραμονή Χριστουγέννων",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Χριστούγεννα",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Δεύτερη μέρα των Χριστουγέννων",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Green Monday",
                    LocalName = "Καθαρή Δευτέρα",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(2),
                    EnglishName = "Easter Tuesday",
                    LocalName = "Τρίτη της Διακαινησίμου",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year),
                this._orthodoxProvider.EasterMonday("Δευτέρα της Διακαινησίμου", year),
                this._orthodoxProvider.Pentecost("Αγίου Πνεύματος", year),
                this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Πρωτοχρονιά", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Θεοφάνεια", "Epiphany", countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(-48), "Καθαρή Δευτέρα", "Green Monday", countryCode));
            //items.Add(new Holiday(year, 3, 25, "Επέτειος Ελληνικής Ανεξαρτησίας", "Greek Independence Day", countryCode));
            //items.Add(new Holiday(year, 4, 1, "Κυπριακή Εθνική Επέτειος", "Cyprus National Day", countryCode));
            //items.Add(this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year, countryCode));
            //Holy Saturday // Μεγάλο Σάββατο??
            //items.Add(this._orthodoxProvider.EasterMonday("Δευτέρα της Διακαινησίμου", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(2), "Τρίτη της Διακαινησίμου", "Easter Tuesday", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Πρωτομαγιά", "Labour Day", countryCode));
            //items.Add(this._orthodoxProvider.Pentecost("Αγίου Πνεύματος", year, countryCode));
            //items.Add(this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "Η Κοίμησις της Θεοτόκου", "Assumption of the Virgin Mary", countryCode));
            //items.Add(new Holiday(year, 10, 1, "Επέτειος Κυπριακής Ανεξαρτησίας", "Cyprus Independence Day", countryCode));
            //items.Add(new Holiday(year, 10, 28, "Το Όχι", "Ohi Day", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Παραμονή Χριστουγέννων", "Christmas Eve", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Χριστούγεννα", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Δεύτερη μέρα των Χριστουγέννων", "St. Stephen's Day", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cyprus",
            };
        }
    }
}
