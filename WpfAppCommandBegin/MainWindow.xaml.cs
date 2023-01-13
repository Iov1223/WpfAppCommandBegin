using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCommandBegin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding commandBindingHelp = new CommandBinding();
            // устанавливаем команду
            commandBindingHelp.Command = ApplicationCommands.Help;
            // добавляем метод
            commandBindingHelp.Executed += CommandBinding_Executed;
            // добавляем привязку к коллекции привязок элемента textBoxDemo
            textBoxDemo.CommandBindings.Add(commandBindingHelp);

            CommandBinding commandBindingClose = new CommandBinding();
            // устанавливаем команду
            commandBindingClose.Command = ApplicationCommands.Close;
            // добавляем метод
            commandBindingClose.Executed += CommandBinding_Close;
            // добавляем привязку к коллекции привязок элемента 
            textBoxDemo.CommandBindings.Add(commandBindingClose);

            
            btnClose.CommandBindings.Add(commandBindingClose);
            //btnClose.Command = ApplicationCommands.Close;
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            //MessageBox.Show("В одной далёкой-далёкой галактике... \nЗдесь будет справка по приложению");
            if (!textBoxDemo.Selection.IsEmpty)
            {
                string tmp = textBoxDemo.Selection.Text;
                Class2.ReadTaskFile(tmp);
                MessageBox.Show(Class2.ResultToString());
            }
            
        }
        private void CommandBinding_Close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
       
    }
}
