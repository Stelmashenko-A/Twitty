namespace Twitty.Utility
{
    class InputBox:Kernel.IDataReader
    {
        public string Data 
        { 
            get; set;
        }

        public void Show()
        {
            Data = Microsoft.VisualBasic.Interaction.InputBox("Введите Pin", "Ввод Pin", "", 100, 100);
        }
    }
}
