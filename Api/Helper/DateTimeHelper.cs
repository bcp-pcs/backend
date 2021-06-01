using System;

namespace Api.Helper {
        class DateTimeHelper {
            public static int GetAge(DateTime dayOfBirth) {
                // TODO (like to have) Add test project
                int _age = DateTime.Today.Year - dayOfBirth.Year;

                // -1 if not birthday yet
                if (new DateTime(DateTime.Today.Year, dayOfBirth.Month, dayOfBirth.Day) > DateTime.Today) {
                    _age--;
                }

                return _age;
            }
        }
}