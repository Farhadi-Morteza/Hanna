using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public static class Utility
	{
		static Utility()
		{
		}

		//=================================================================================================
		public static System.DateTime Now
		{
			get
			{
				//string currentCultureName =
				//	System.Threading.Thread.CurrentThread.CurrentCulture.Name;

				//System.Threading.Thread.CurrentThread.CurrentCulture =  EnglishCulture;

				//System.DateTime now = System.DateTime.Now;

				System.Threading.Thread.CurrentThread.CurrentCulture = PersianCulture;
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
	
				System.DateTime now = System.DateTime.Now;
				return now;
			}
		}
		//=================================================================================================
		public static System.Globalization.CultureInfo CurrentCulture
		{
			get
			{
				System.Globalization.CultureInfo currentCulture =
						System.Threading.Thread.CurrentThread.CurrentCulture;

				return currentCulture;
			}
		}
		//=================================================================================================
		public static System.Globalization.CultureInfo EnglishCulture
		{
			get
			{
				System.Globalization.CultureInfo englishCulture =
					new System.Globalization.CultureInfo(name:  Constant.CultureName.English_UnitedStates_en_US);

				return englishCulture;
			}
		}
		//=================================================================================================
		public static System.Globalization.CultureInfo PersianCulture
		{
			get
			{
				System.Globalization.CultureInfo persianCulture =
					new System.Globalization.CultureInfo(name: Constant.CultureName.Persian_Iran_fa_IR);

				return persianCulture;
			}
		}
		//=================================================================================================
	}
}
