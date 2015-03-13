
namespace Student_Assistant_Application.Animations
{
    public class UpDownAnimation
    {
        public UpDownAnimation(System.Windows.Forms.Control firstControl,System.Windows.Forms.Control secondControl)
        {
            Speed = 1000000;
            FirstControl = firstControl;
            SecondControl = secondControl;
        }



        private void DecreaseValue(int value)
        {
            FirstControl.Size = new System.Drawing.Size(FirstControl.Size.Width, FirstControl.Height - value);
            FirstControl.Location = new System.Drawing.Point(FirstControl.Location.X, FirstControl.Location.Y + value);
            SecondControl.Size = new System.Drawing.Size(SecondControl.Width, SecondControl.Height + (value - 1));
        }
        private void IncreaseValue(int value)
        {
            SecondControl.Size = new System.Drawing.Size(SecondControl.Size.Width, SecondControl.Height - value);
            FirstControl.Location = new System.Drawing.Point(FirstControl.Location.X, FirstControl.Location.Y - (value - 1));
            FirstControl.Size = new System.Drawing.Size(FirstControl.Width, FirstControl.Height + value);
        }
        private void GetStarted()
        {
            System.Drawing.Point p = FirstControl.Location;
            System.Drawing.Size s = FirstControl.Size;
            int ratio = FirstControl.Width / 10;
            SecondControl.Size = new System.Drawing.Size(FirstControl.Size.Width, 0);
            SecondControl.Visible = true;

            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            DecreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;

            FirstControl.Visible = false;
            SecondControl.Size = s;
            SecondControl.Location = p;
        }
        private void GetStartedHide()
        {
            System.Drawing.Size s = SecondControl.Size;
            System.Drawing.Point p = SecondControl.Location;
            int ratio = SecondControl.Width / 10;
            FirstControl.Location = new System.Drawing.Point(FirstControl.Location.X, SecondControl.Location.Y + SecondControl.Height);
            FirstControl.Size = new System.Drawing.Size(SecondControl.Size.Width, 0);
            FirstControl.Visible = true;

            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;
            IncreaseValue(ratio);
            for (int i = 0; i < Speed; i++) ;

            SecondControl.Visible = false;
            FirstControl.Size = s;
            FirstControl.Location = p;
        }
        bool show = false;

        public void PerformAnimation()
        {
            if (!show)
            {
                show = true;
                SecondControl.Visible = true;
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(GetStarted));
                th.Start();

            }
            else
            {
                show = false;
                FirstControl.Visible = true;
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(GetStartedHide));
                th.Start();
            }

        }





        public int Speed { get; set; }
        public System.Windows.Forms.Control FirstControl { get; set; }
        public System.Windows.Forms.Control SecondControl { get; set; }
    }
}
