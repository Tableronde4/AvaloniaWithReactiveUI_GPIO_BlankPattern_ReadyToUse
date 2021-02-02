using ReactiveUI;
using System.Threading.Tasks;

namespace TestAvaloniaBinding
{
    public class ViewModel : ReactiveObject
    {
        //creating instance of Logic.cs
        public Logic logic = new Logic();

        //declaration of each variable used in UI
        #region        
        int state = 0;
        public int State { get => state; set => this.RaiseAndSetIfChanged(ref state, value); }

        int pulse = 0;
        public int Pulse { get => pulse; set => this.RaiseAndSetIfChanged(ref pulse, value); }
        #endregion

        //call this function in MainWindow in MainWindow.axaml.cs
        public void Start()
        {
            //creating a task of logic to not freeze UI
            Task task = new Task(() => logic.Main());
            task.Start();
        }

        //bind each variable that use the UI to another variable in Logic
        public void UpdateLiveValues()
        {                                 //                                                                  name of variable --- not needed : text before value      
            State = logic.variable.State; //need to bind with this in MainWindow.axaml : for example : Text="{Binding State, StringFormat=State: {0}}"
            Pulse = logic.variable.Pulse;
        }
    }
}
