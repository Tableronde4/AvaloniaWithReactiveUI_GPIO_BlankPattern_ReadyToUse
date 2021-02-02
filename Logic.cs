using System.Device.Gpio;
using System.Threading;

namespace TestAvaloniaBinding
{
    public class Logic
    {
        //instanciate Variable
        public Variable variable = new Variable();
        //
        public void Main()
        {
            //creating GPIO instance
            var gpio = new GpioController();
            
            //telling to GPIO each pin in use is a input or a output
            #region
            //input     # pin --- input or output
            gpio.OpenPin(5, PinMode.Input);
            #endregion

            variable.State = 0;
            variable.Pulse = 0;
            
            //this while is used to get a code that work indefinitely up to down
            while (true)
            {
                //reading a pin, so x can be 0 or 1 in this case, according to low or high voltage on the pin
                int x = (int)gpio.Read(13);


                variable.State++;

                if (variable.Pulse == 0)
                {
                    variable.Pulse = 1;
                }
                else
                {
                    variable.Pulse = 0;
                }


                Thread.Sleep(100);
            }
        }

        //each variable used in Logic.cs is declared here
        public class Variable
        {
            public int State { get; set; }
            public int Pulse { get; set; }
        }
    }
}
