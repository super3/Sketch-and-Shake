using System;
using System.Windows.Media;
using System.IO.IsolatedStorage;

/* This class stores the states of the brushSize and brushColor so that the data
 * can be communicated between the separate windows.
 */



namespace SketchApp01
{
    //got this code from an answer on StackOverflow
    //found here: http://stackoverflow.com/questions/3145803/windows-phone-7-config-appsettings
    public class AppSettings
    {
        public AppSettings()
        {
            // TODO: Complete member initialization
        }

        private  IsolatedStorageSettings Settings = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;

        public void setBrushColor(Color inputColor)
        {
            StoreSetting<Color>("brushColor", inputColor);
        }

        public void setBrushSize(int inputSize)
        {
            StoreSetting<int>("brushSize", inputSize);
        }

        public Color getBrushColor()
        {
            Color outputColor;

            TryGetSetting<Color>("brushColor", out outputColor);

            return outputColor;
        }

        public int getBrushSize()
        {
            int outputSize;

            TryGetSetting<int>("brushSize", out outputSize);

            return outputSize;
        }

        //Example StoreSetting function
        //public static void StoreSetting(string settingName, string value)
        //{
        //    StoreSetting<string>(settingName, value);
        //}

        private void StoreSetting<TValue>(string settingName, TValue value)
        {
            if (!Settings.Contains(settingName))
                Settings.Add(settingName, value);
            else
                Settings[settingName] = value;

            // EDIT: if you don't call Save then WP7 will corrupt your memory!
            Settings.Save();
        }

        private bool TryGetSetting<TValue>(string settingName, out TValue value)
        {            
            if (Settings.Contains(settingName))
            {
                value = (TValue)Settings[settingName];
                return true;
            }

            value = default(TValue);
            return false;
        }
    }
}