﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Input;


namespace FreeSCADA.Designer.SchemaEditor.Manipulators.Controlls
{
    /// <summary>
    /// Drag controll for DragResizeRotateManipulator
    /// </summary>
    class PointDragThumb: Thumb
    {

        
        public PointDragThumb()
        {
        
            
        }
     
        
        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement item = this.DataContext as FrameworkElement;

            if (item != null)
            {
                Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);

                dragDelta = RenderTransform.Transform(dragDelta);

                double left = Canvas.GetLeft(item);
                double top = Canvas.GetTop(item);

                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                Canvas.SetLeft(item, left + dragDelta.X);
                Canvas.SetTop(item, top + dragDelta.Y);
                
            }
            e.Handled = false;
        }
    }
}

