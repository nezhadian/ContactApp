using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ContactApp.Controls
{
    class IconicTextBox : TextBox
    {

        public object IconContent
        {
            get { return GetValue(IconContentProperty); }
            set { SetValue(IconContentProperty, value); }
        }
        public static readonly DependencyProperty IconContentProperty =
            DependencyProperty.Register("IconContent", typeof(object), typeof(IconicTextBox), new PropertyMetadata());

        public object Placeholder
        {
            get { return GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(object), typeof(IconicTextBox), new PropertyMetadata());

        public Brush PlaceholderBrush
        {
            get { return (Brush)GetValue(PlaceholderBrushProperty); }
            set { SetValue(PlaceholderBrushProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderBrushProperty =
            DependencyProperty.Register("PlaceholderBrush", typeof(Brush), typeof(IconicTextBox), new PropertyMetadata());

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(IconicTextBox), new PropertyMetadata());

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(IconicTextBox), new PropertyMetadata());

        public ICommand EnterCommand
        {
            get { return (ICommand)GetValue(EnterCommandProperty); }
            set { SetValue(EnterCommandProperty, value); }
        }
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register("EnterCommand", typeof(ICommand), typeof(IconicTextBox), new PropertyMetadata());

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.Key == Key.Return)
            {
                if (EnterCommand is null)
                    return;

                if (EnterCommand.CanExecute(Text))
                    EnterCommand.Execute(Text);
            }
        }


    }
}
