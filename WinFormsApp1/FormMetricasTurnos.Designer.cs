namespace WinFormsApp1
{
    partial class FormMetricasTurnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMetricasTurnos));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding3 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding4 = new LiveChartsCore.Drawing.Padding();
            pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            vetTurno = new ComboBox();
            estadoTurno = new ComboBox();
            fechaDesde = new DateTimePicker();
            fechaHasta = new DateTimePicker();
            Limpiar = new Button();
            Buscar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // pieChart1
            // 
            pieChart1.AutoUpdateEnabled = true;
            pieChart1.ChartTheme = null;
            skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend1.Content = null;
            skDefaultLegend1.IsValid = false;
            skDefaultLegend1.Opacity = 1F;
            padding1.Bottom = 0F;
            padding1.Left = 0F;
            padding1.Right = 0F;
            padding1.Top = 0F;
            skDefaultLegend1.Padding = padding1;
            skDefaultLegend1.RemoveOnCompleted = false;
            skDefaultLegend1.RotateTransform = 0F;
            skDefaultLegend1.X = 0F;
            skDefaultLegend1.Y = 0F;
            pieChart1.Legend = skDefaultLegend1;
            pieChart1.Location = new Point(494, 62);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new Size(150, 150);
            pieChart1.TabIndex = 0;
            skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip1.Content = null;
            skDefaultTooltip1.IsValid = false;
            skDefaultTooltip1.Opacity = 1F;
            padding2.Bottom = 0F;
            padding2.Left = 0F;
            padding2.Right = 0F;
            padding2.Top = 0F;
            skDefaultTooltip1.Padding = padding2;
            skDefaultTooltip1.RemoveOnCompleted = false;
            skDefaultTooltip1.RotateTransform = 0F;
            skDefaultTooltip1.Wedge = 10;
            skDefaultTooltip1.X = 0F;
            skDefaultTooltip1.Y = 0F;
            pieChart1.Tooltip = skDefaultTooltip1;
            pieChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // cartesianChart1
            // 
            cartesianChart1.AutoUpdateEnabled = true;
            cartesianChart1.ChartTheme = null;
            skDefaultLegend2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend2.Content = null;
            skDefaultLegend2.IsValid = false;
            skDefaultLegend2.Opacity = 1F;
            padding3.Bottom = 0F;
            padding3.Left = 0F;
            padding3.Right = 0F;
            padding3.Top = 0F;
            skDefaultLegend2.Padding = padding3;
            skDefaultLegend2.RemoveOnCompleted = false;
            skDefaultLegend2.RotateTransform = 0F;
            skDefaultLegend2.X = 0F;
            skDefaultLegend2.Y = 0F;
            cartesianChart1.Legend = skDefaultLegend2;
            cartesianChart1.Location = new Point(129, 62);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(150, 150);
            cartesianChart1.TabIndex = 2;
            skDefaultTooltip2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip2.Content = null;
            skDefaultTooltip2.IsValid = false;
            skDefaultTooltip2.Opacity = 1F;
            padding4.Bottom = 0F;
            padding4.Left = 0F;
            padding4.Right = 0F;
            padding4.Top = 0F;
            skDefaultTooltip2.Padding = padding4;
            skDefaultTooltip2.RemoveOnCompleted = false;
            skDefaultTooltip2.RotateTransform = 0F;
            skDefaultTooltip2.Wedge = 10;
            skDefaultTooltip2.X = 0F;
            skDefaultTooltip2.Y = 0F;
            cartesianChart1.Tooltip = skDefaultTooltip2;
            cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // vetTurno
            // 
            vetTurno.FormattingEnabled = true;
            vetTurno.Location = new Point(12, 33);
            vetTurno.Name = "vetTurno";
            vetTurno.Size = new Size(121, 23);
            vetTurno.TabIndex = 3;
            // 
            // estadoTurno
            // 
            estadoTurno.FormattingEnabled = true;
            estadoTurno.Location = new Point(139, 33);
            estadoTurno.Name = "estadoTurno";
            estadoTurno.Size = new Size(121, 23);
            estadoTurno.TabIndex = 4;
            // 
            // fechaDesde
            // 
            fechaDesde.Location = new Point(266, 33);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.ShowCheckBox = true;
            fechaDesde.Size = new Size(128, 23);
            fechaDesde.TabIndex = 5;
            // 
            // fechaHasta
            // 
            fechaHasta.Location = new Point(400, 33);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.ShowCheckBox = true;
            fechaHasta.Size = new Size(128, 23);
            fechaHasta.TabIndex = 6;
            // 
            // Limpiar
            // 
            Limpiar.BackColor = SystemColors.ControlDark;
            Limpiar.Location = new Point(534, 34);
            Limpiar.Name = "Limpiar";
            Limpiar.Size = new Size(75, 23);
            Limpiar.TabIndex = 7;
            Limpiar.Text = "Limpiar";
            Limpiar.UseVisualStyleBackColor = false;
            // 
            // Buscar
            // 
            Buscar.BackColor = Color.CornflowerBlue;
            Buscar.Location = new Point(615, 34);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(75, 23);
            Buscar.TabIndex = 8;
            Buscar.Text = "Buscar";
            Buscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 9;
            label1.Text = "Veterinario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 15);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 10;
            label2.Text = "Estado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 15);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 11;
            label3.Text = "Fecha desde:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(400, 15);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 12;
            label4.Text = "Fecha hasta:";
            // 
            // FormMetricasTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Buscar);
            Controls.Add(Limpiar);
            Controls.Add(fechaHasta);
            Controls.Add(fechaDesde);
            Controls.Add(estadoTurno);
            Controls.Add(vetTurno);
            Controls.Add(cartesianChart1);
            Controls.Add(pieChart1);
            Name = "FormMetricasTurnos";
            Text = "Métricas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private ComboBox vetTurno;
        private ComboBox estadoTurno;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private Button Limpiar;
        private Button Buscar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}