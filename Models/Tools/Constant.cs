using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Constant
    {
		public static class Length
		{
			static Length()
			{
			}

			public const int IP = 45;

			public const int GUID = 36;

			public const int TOKEN = 512;

			/// <summary>
			/// SHA-256
			/// </summary>
			public const int PASSWORD = 64;

			public const int USERNAME = 20;

			public const int FULL_NAME = 50;

			public const int SESSION_ID = 80;

			public const int SMALL_STRING = 25;

			public const int MEDIOM_STRING = 50;

			public const int LARGE_STRING = 100;

			public const int ECONOMIC_CODE = 25;

			public const int REGISTRATION_NUMBER = 25;

			public const int DOMAIN_NAME = 100;

			public const int DESCRIPTION = 300;

			public const int DISPLAY_NAME = 200;

			public const int GENERAL_NAME = 100;

			public const int NATIONAL_CODE = 10;

			public const int EMAIL_ADDRESS = 254;

			public const int WEBSITE = 100;

			public const int CAPTCHA_IMAGE_TEXT = 6;

			public const int SITE_ABSOLUTE_PATH = 200;

			public const int MIN_PHONE_NUMBER = 8;

			public const int MAX_PHONE_NUMBER = 14;

			public const int MIN_CELL_PHONE_NUMBER = 11;

			public const int MAX_CELL_PHONE_NUMBER = 14;

			public const int CELL_PHONE_NUMBER_VERIFICATION_KEY = 10;
		}

		public static class CultureName
		{

			static CultureName()
			{

			}
			public const string English_UnitedStates_en_US = "en-US";
			public const string Persian_Iran_fa_IR = "fa-IR";
			public const string Spanish_Spain_es_ES = "es-ES";
		}
	}
}
