using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Win32;

namespace ExampleApp.WPF.Infra
{
    public class SaveFileDialogBehaviour : Behavior<System.Windows.Controls.Button>
    {
        public string FileName
        {
            get => (string)GetValue(FileNameProperty);
            set => SetValue(FileNameProperty, value);
        }
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(SaveFileDialogBehaviour), new PropertyMetadata(""));

        public string FileTypesFilter
        {
            get => (string)GetValue(FileTypesFilterProperty);
            set => SetValue(FileTypesFilterProperty, value);
        }
        public static readonly DependencyProperty FileTypesFilterProperty =
            DependencyProperty.Register("FileTypesFilter", typeof(string), typeof(SaveFileDialogBehaviour), new PropertyMetadata(""));


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnClick;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnClick;
            base.OnDetaching();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FileTypesFilter ?? ""
            };

            var showDialogResult = saveFileDialog.ShowDialog();

            if (showDialogResult.GetValueOrDefault() == false)
                return;

            FileName = saveFileDialog.FileName;
            
        }
    }
}
