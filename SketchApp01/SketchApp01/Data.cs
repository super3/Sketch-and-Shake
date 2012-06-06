using System;
using System.Windows.Media;

/* This class stores the states of the brushSize and brushColor so that the data
 * can be communicated between the separate windows.
 */



namespace SketchApp01
{
    public class DataStorage
    {
        private Color brushColor = Colors.Blue;
        private int brushSize = 15;

        private bool resetSampleBrush = false;

        #region getSets

        public Color getBrushColor()
        {
            return brushColor;
        }

        public void setBrushColor(Color inputColor)
        {
            brushColor = inputColor;
        }

        public int getBrushSize()
        {
            return brushSize;
        }

        public void setBrushSize(int inputSize)
        {
            brushSize = inputSize;
        }

        public bool getResetSampleBrush()
        {
            return resetSampleBrush;
        }

        public void setResetSampleBrush(bool inputState)
        {
            resetSampleBrush = inputState;
        }

        #endregion
    }
}