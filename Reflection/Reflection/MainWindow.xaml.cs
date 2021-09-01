using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {        
            string assemblyPath = assemblyPathTextBox.Text;

            var assembly = Assembly.LoadFrom(assemblyPath);

            foreach (var type in assembly.GetTypes())
            {
                WriteFullNameInfo(type);
                WritePropertiesInfo(type);
                WriteMethodsInfo(type);
            }
        }

        private void WriteFullNameInfo(Type type)
        {
            listForFullName.Items.Add(type.FullName);
        }

        private void WritePropertiesInfo(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string className=string.Format("Class name: {0}", type.Name);
                string info = string.Format("  Properties: {0}, {1}", property.Name, property.PropertyType);

                listForProperties.Items.Add(className);
                listForProperties.Items.Add(info);
            }
        }

        private void WriteMethodsInfo(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                string className = string.Format("Class name: {0}", type.Name);
                string info = string.Format("  Method: {0}", method);

                listForMethods.Items.Add(className);
                listForMethods.Items.Add(info);
            }       
        }
    }
}
