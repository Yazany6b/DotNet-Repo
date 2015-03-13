using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_Assistant_Application.Animations
{
    public class SizingAnimation
    {
        private bool show = false;

        public SizingAnimation(System.Windows.Forms.Control control, System.Drawing.Size size)
        {
            Speed = 1000000;
            AnimatedControl = control;
            ControlSize = size;
        }

        public SizingAnimation(System.Windows.Forms.Form form, System.Drawing.Size size)
        {
            Speed = 1000000;
            AnimatedForm = form;
            ControlSize = size;
        }


        private void SelectFirstAnimations()
        {
            if ((AnimatedControl.Width * AnimatedControl.Height) < (ControlSize.Height * ControlSize.Height))
            {

            }
        }

        private void DecreaseValue(int xvalue,int yvalue)
        {
        }
        private void IncreaseValue(int xvalue, int yvalue)
        {
        }
        private void GetStarted()
        {
            int xratio = AnimatedControl.Width / 10;
            int yratio = AnimatedControl.Width / 10;

            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
        }
        private void GetStartedHide()
        {
            int xratio= AnimatedControl.Width / 10;
            int yratio = AnimatedControl.Width / 10;

            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(xratio,yratio);
            for (int i = 0; i < Speed; i++) ;
        }

        public void PerformAnimation()
        {
            if (!show)
            {
                show = true;
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(GetStarted));
                th.Start();

            }
            else
            {
                show = false;
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(GetStartedHide));
                th.Start();
            }

        }





        public int Speed { get; set; }
        public System.Windows.Forms.Control AnimatedControl { get; set; }
        public System.Windows.Forms.Form AnimatedForm { get; set; }
        public System.Drawing.Size ControlSize { get; set; }
    }
}
