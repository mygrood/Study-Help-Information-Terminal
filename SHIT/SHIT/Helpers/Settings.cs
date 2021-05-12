using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace SHIT.Helpers
{/// <summary>
 /// This is the Settings static class that can be used in your Core solution or in any
 /// of your client applications. All settings are laid out the same exact way with getters
 /// and setters. 
 /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SpecializationKey = "SpecializationKey";
        private static readonly int SpecializationDefault = 0;

        #endregion

        /* 1 - банковское дело
         * 2 - логистика
         * 3 - право
         * 4 - экономика
         * 5 - архивоведение
         * 6 - товароведение
         * 7 - прикладная информатика и прогр
         * 8 - коммерция
         * 9 - дошкольное обр
         * 10 - преподавание в нач классах
         * 11 - музыкальное обр
         * 12 - страховое дело
         */
        public static int Specialization
        {
            get
            {
                return AppSettings.GetValueOrDefault(SpecializationKey, SpecializationDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SpecializationKey, value);
            }
        }

        #region Setting Constants

        private const string GroupKey = "GroupKey";
        private static string  GroupDefault = string.Empty;

        #endregion


        public static string Group
        {
            get
            {
                return AppSettings.GetValueOrDefault(GroupKey, GroupDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(GroupKey, value);
            }
        }
    }
}
