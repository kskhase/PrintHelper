using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintHelper
{
    class PrinterHelper:PrintDocument 
    {
        public TableLayoutPanel HeaderContents { get; set; }
        public TableLayoutPanel FooterContents { get; set; }
        /// <summary>
        /// 印刷時の単位：初期値はミリメートル
        /// </summary>
        public GraphicsUnit PageUnit { get; set; } = GraphicsUnit.Millimeter;
        public bool UseColorPrint { get; set; } = true;

        /// <summary>
        /// ドキュメントの印刷プロセスを開始します。
        /// </summary>
        public new void Print()
        {
            base.Print();
            
        }

        public void ShowPreviewDialog()
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.PrintPreviewControl.Zoom = 1;
            dlg.Document = this;
            ((System.Windows.Forms.Form)dlg).WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
        }


        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            //e.Graphics.PageUnit = this.PageUnit;
            PointF drawStartPoint = new PointF(10, 10);

            var height = PrintHeader(e);
            drawStartPoint.Y += height;

            PrintFooter(e);

            base.OnPrintPage(e);

        }

        int PrintHeader(PrintPageEventArgs e)
        {
            if (HeaderContents is null) { return 0; }
            int drawHeight = 0;

            PrintPanel(e.Graphics, HeaderContents);

            return drawHeight;
        }

        int PrintFooter(PrintPageEventArgs e)
        {
            if (FooterContents is null) { return 0; }

            int drawHeight = 0;


            return drawHeight;
        }

        private void PrintPanel(Graphics graphics, TableLayoutPanel panel)
        {
            Control control = panel.GetControlFromPosition(0, 0);
            var brush = new SolidBrush(control.ForeColor);

            graphics.DrawString(control.Text, control.Font, brush , new PointF(0, 0));


        }



    }
}
