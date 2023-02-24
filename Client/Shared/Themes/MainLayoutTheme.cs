using MudBlazor;

namespace Client.Shared
{
    public class MainLayoutTheme : MudTheme
    {
        public MainLayoutTheme()
        {
            Palette = new Palette()
            {
                Primary = Colors.Purple.Default,
                Secondary = Colors.Green.Accent4,
                AppbarBackground = Colors.Amber.Darken3,
                DrawerBackground = "#FFF",
                DrawerText = "rgba(0,0,0, 0.7)",
                Success = "#06d79c",
                Background = Colors.BlueGrey.Darken1,
                TextPrimary = Colors.BlueGrey.Darken2,

                //Background = Colors.BlueGrey.Lighten5,

                //TextSecondary = Colors.Grey.Darken4,
                //PrimaryContrastText = Colors.Pink.Darken4,

                //Primary = Colors.Teal.Darken3,
                //Secondary = Colors.LightBlue.Darken3,
                //AppbarBackground = Colors.Green.Default,
                //DrawerBackground = "#FFF",
                //DrawerText = "rgba(0,0,0, 0.7)",
                //Success = "#06d79c",
                //Background = Colors.BlueGrey.Lighten5,

                //Black = Colors.Red.Darken3,
                //Background = Colors.Red.Darken4,
                //BackgroundGrey = "#27272f",
                //Surface = Colors.Yellow.Darken4,
                //DrawerBackground = Colors.Pink.Darken4,
                //DrawerText = Colors.LightBlue.Darken4,
                //DrawerIcon = "rgba(255,255,255, 0.50)",
                //AppbarBackground = "#27272f",
                //AppbarText = Colors.Cyan.Darken2,
                //TextPrimary = Colors.Teal.Darken3,// "rgba(255,255,255, 0.70)",
                //TextSecondary = Colors.Orange.Accent3,// "rgba(255,255,255, 0.50)",
                //ActionDefault = Colors.Amber.Darken2,
                //ActionDisabled = "rgba(255,255,255, 0.26)",
                //ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                //Divider = Colors.Brown.Darken2,
                //DividerLight = Colors.Indigo.Darken3,
                //TableLines = Colors.LightGreen.Darken3,
                //LinesDefault = Colors.Green.Darken2,
                //LinesInputs = Colors.Purple.Darken3,
                //TextDisabled = Colors.Orange.Darken3

            };

            LayoutProperties = new LayoutProperties()
            {
                DefaultBorderRadius = "6px",
            };

            Typography = new Typography()
            {
                Default = new Default()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = ".775rem",
                    FontWeight = 400,
                    LineHeight = 1.43,
                    LetterSpacing = ".01071em"
                },
                H1 = new H1()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = "6rem",
                    FontWeight = 300,
                    LineHeight = 1.167,
                    LetterSpacing = "-.01562em"
                },
                H2 = new H2()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = "3.75rem",
                    FontWeight = 300,
                    LineHeight = 1.2,
                    LetterSpacing = "-.00833em"
                },
                H3 = new H3()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = "3rem",
                    FontWeight = 400,
                    LineHeight = 1.167,
                    LetterSpacing = "0"
                },
                H4 = new H4()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },

                    FontSize = "2.125rem",
                    FontWeight = 400,
                    LineHeight = 1.235,
                    LetterSpacing = ".00735em"
                },
                H5 = new H5()
                {
                    //FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },

                    FontSize = "1.5rem",
                    FontWeight = 400,
                    LineHeight = 1.334,
                    LetterSpacing = "0"
                },
                H6 = new H6()
                {
                    //FontFamily = new[] { "webYekan", "koodak" , "Tahoma"},
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },

                    FontSize = "1.25rem",
                    FontWeight = 400,
                    LineHeight = 1.6,
                    LetterSpacing = ".0075em"
                },
                Button = new Button()
                {
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = ".875rem",
                    FontWeight = 500,
                    LineHeight = 1.75,
                    LetterSpacing = ".02857em"
                },
                Body1 = new Body1()
                {
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = "1rem",
                    FontWeight = 400,
                    LineHeight = 1.5,
                    LetterSpacing = ".00938em"
                },
                Body2 = new Body2()
                {
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = ".875rem",
                    FontWeight = 400,
                    LineHeight = 1.43,
                    LetterSpacing = ".01071em"
                },
                Caption = new Caption()
                {
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = ".75rem",
                    FontWeight = 400,
                    LineHeight = 1.66,
                    LetterSpacing = ".03333em"
                },
                Subtitle2 = new Subtitle2()
                {
                    FontFamily = new[] { "Koodak", "Tahoma", "Arial" },
                    FontSize = ".875rem",
                    FontWeight = 500,
                    LineHeight = 1.57,
                    LetterSpacing = ".00714em"
                }
            };
            Shadows = new Shadow();
            ZIndex = new ZIndex();
        }
    }
}
